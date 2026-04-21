using ButopiaMysteries.Logic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A window tha allows to select/create mysteries/characters.
    /// </summary>
    public partial class CharacterSelect : Form
    {
        private Roster Roster { get; init; }
        private Point referencePoint = Point.Empty;
        private readonly List<CharacterView> views = [];
        private CharacterView? persoDépacer = null;
        private bool deplacement = false;
        private Rectangle zoneAuto = new Rectangle(500, 50, 250, 100);
        private Rectangle zoneExamen = new Rectangle(500, 170, 250, 100);
        private Rectangle zoneEntrainement = new Rectangle(500, 290, 250, 100);
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public CharacterSelect()
        {
            InitializeComponent();
            Roster = new();
            MysterySheet charOne = new(Names.RandomName);
            charOne.RandomGeneration();
            Roster.Sheets.Add(charOne.Name, charOne);
            referencePoint = new Point(10, 10);
            CreateCharacterViews();
        }


        private void ShowSheetViewFor(string text)
        {
            new SheetView(Roster.Sheets[text]).ShowDialog();
        }

        private void CharacterSelect_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen zonePen = new Pen(Color.Black, 2);
            g.DrawRectangle(zonePen, zoneAuto);
            g.DrawRectangle(zonePen, zoneExamen);
            g.DrawRectangle(zonePen, zoneEntrainement);
            Font font = SystemFonts.DefaultFont;
            g.DrawString("Salle d'auto-évaluation", font, Brushes.Black, 505, 55);
            g.DrawString("Salle d'examen", font, Brushes.Black, 505, 175);
            g.DrawString("Salle d'entraînement", font, Brushes.Black, 505, 295);

            foreach (CharacterView view in views)
            {
                if (view != persoDépacer)
                {
                    view.Draw(e.Graphics);
                }
            }
            if (persoDépacer != null)
            {
                persoDépacer.Draw(e.Graphics);
            }
        }
        private void CreateCharacterViews()
        {
            views.Clear();
            int x = 10; 
            int y = 10 + ViewSettings.DefaultPawnSide; 
            foreach (string name in Roster.Sheets.Keys)
            {
                views.Add(new CharacterView(Roster.Sheets[name], new Point(x, y))); 
                y += ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Height;
                if (y + ViewSettings.DefaultPawnFrame.Height > Height - 40)
                {
                    y = ViewSettings.DefaultPawnSide + 10;
                    x += ViewSettings.DefaultPawnFrame.Width + 20;
                }
            }
            createButton.Enabled = Roster.Sheets.Count < 12;
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreationDialog();
        }


        private void CreationDialog()
        {
            NewCharacterDialog dialog = new();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Rules regleChoisie = dialog.SelectedRules;
                string nomChoisi = dialog.CharacterName;
                if (string.IsNullOrWhiteSpace(nomChoisi))
                {
                    nomChoisi = Names.RandomName;
                }
                CreateCharacter(nomChoisi, regleChoisie);
            }
        }
        private void CreateCharacter(string name, Rules rule)
        {
            if (Roster.Sheets.ContainsKey(name))
            {
                MessageBox.Show("Erreur : " + name + " déjà présent !");
            }
            else
            {
                MysterySheet sheet = new(name);
                sheet.RandomGeneration(rule);
                Roster.Sheets.Add(sheet.Name, sheet);
                CreateCharacterViews();
                Refresh();
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        
        private void CharacterSelect_MouseDown(object sender, MouseEventArgs e)
        {

            CharacterView perso = null;
            bool trouve = false;
            
                foreach (CharacterView view in views)
                {
                    if (view.Contains(e.Location))
                    {
                        perso = view;
                        trouve = true;
                        break;
                    }
                }
                if (trouve == true)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        persoDépacer = perso;
                        deplacement = true;
                    }

                    else if (e.Button == MouseButtons.Right)
                    {
                        DialogResult reponse = MessageBox.Show("Êtes-vous sûr de vouloir supprimer " + perso.Sheet.Name + " ?",
                            "Confirmation", MessageBoxButtons.YesNo);
                        if (reponse == DialogResult.Yes)
                        {
                            Roster.Sheets.Remove(perso.Sheet.Name);
                            CreateCharacterViews();
                            Refresh();
                        }
                    }
                }

        }
        private void CharacterSelect_MouseMove(object sender, MouseEventArgs e)
        {
            if (deplacement && persoDépacer != null)
            {
                int offsetX = ViewSettings.DefaultPawnFrame.Width / 2;
                int offsetY = ViewSettings.DefaultPawnFrame.Height / 2;

                Point nouvellePos = new Point(e.X - offsetX, e.Y - offsetY);

                persoDépacer.Move(nouvellePos);
                Refresh();
            }
        }

        private void CharacterSelect_MouseUp(object sender, MouseEventArgs e)
        {
            Skill skillChoisi = (Skill)BoxSkill.SelectedItem;
            Difficulty diffChoisi = (Difficulty)boxDifficulty.SelectedItem;
            Indicator? indicateurDedui = skillChoisi.GetIndicator();
            if (deplacement && persoDépacer != null)
            {
                if (zoneExamen.Contains(e.Location)) 
                {
                        bool res = Trial.ClosedTrial(persoDépacer.Sheet, indicateurDedui.Value, skillChoisi, diffChoisi);
                }
                else if( zoneAuto.Contains(e.Location))
                {
                    Difficulty res = Trial.OpenTrial(persoDépacer.Sheet, indicateurDedui.Value, skillChoisi);
                }
                
            }
            deplacement = false;
            persoDépacer = null;
            CreateCharacterViews();
            Refresh();    
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        {
            boxDifficulty.DataSource = Enum.GetValues(typeof(Difficulty));
            BoxSkill.DataSource = Enum.GetValues(typeof(Skill));
        }
    }
}
