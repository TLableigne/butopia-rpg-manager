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
            MysterySheet charOne = new(Names.RandomName, Plan.Thinkers, Sphere.Algebra);
            charOne.RandomGeneration();
            Roster.Sheets.Add(charOne.Name, charOne);
            referencePoint = new Point(10, 10);
            this.BackColor = ViewSettings.BackgroundColor;
            this.Text = "Sélection des personnages"; 

            for (int i = 0; i < ViewSettings.InitialCharacterCount-1; i++)
            {
                String name = Names.RandomName;
                CreateCharacter(name , Rules.None, Plan.Thinkers, Sphere.Algebra);
            }
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
                Plan planChoisi = dialog.SelectedPlan;
                Sphere sphereChoisie = dialog.SelectedSphere;
                if (string.IsNullOrWhiteSpace(nomChoisi))
                {
                    nomChoisi = Names.RandomName;
                }
                CreateCharacter(nomChoisi, regleChoisie, planChoisi, sphereChoisie);
            }
        }
        private void CreateCharacter(string name, Rules rule, Plan plan, Sphere sphere)
        {
            if (Roster.Sheets.ContainsKey(name))
            {
                MessageBox.Show("Erreur : " + name + " déjà présent !");
            }
            else
            {
                // Utilisation du constructeur complet
                MysterySheet sheet = new MysterySheet(name, plan, sphere);
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
                        if (e.Clicks == 2)
                        {
                            ShowSheetViewFor(perso.Sheet.Name);
                            deplacement = false;
                            
                        }
                        else
                        {
                            persoDépacer = perso;
                            deplacement = true;
                        }
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
            if (deplacement && persoDépacer != null && !BoxSkill.SelectedValue.Equals(Skill.None))
            {
                Skill s = (Skill)BoxSkill.SelectedValue;
                Indicator? i = s.GetIndicator();

                if (i.HasValue)
                {

                    if (zoneEntrainement.Contains(e.Location))
                    {
                        if (persoDépacer.Sheet.estEnFormation != true)
                        {
                            MessageBox.Show("Ce personnage doit être en formation pour pouvoir s'entraîner !");
                        }
                        else
                        {
                            TrainForm tf = new TrainForm(persoDépacer.Sheet);
                            tf.ShowDialog();
                        }
                    }

                    else if (zoneAuto.Contains(e.Location) || zoneExamen.Contains(e.Location))
                    {
                        if (persoDépacer.Sheet.estEnFormation != true)
                        {
                            MessageBox.Show("Ce personnage doit être en formation pour participer à une épreuve.");
                        }
                        else
                        {
                            Skill finalSkill = s;
                            int malus = 0;

                            if (!persoDépacer.Sheet.Skills.ContainsKey(s) || persoDépacer.Sheet.Skills[s] == 0)
                            {
                                Skill sub = FindBestSubstitution(persoDépacer.Sheet, i.Value, s);
                                if (sub == Skill.None)
                                {
                                    MessageBox.Show(persoDépacer.Sheet.Name + " n'a aucune compétence pour cet indicateur.");
                                    CreateCharacterViews();
                                    deplacement = false;
                                    persoDépacer = null;
                                    Refresh();
                                    return;
                                }
                                else
                                {
                                    finalSkill = sub;
                                    malus = 2;
                                    MessageBox.Show("Substitution : " + sub.Name() + " utilisée avec un malus de -2.");
                                }
                            }

                            if (zoneAuto.Contains(e.Location))
                            {
                                TrialForm tf = new TrialForm(persoDépacer.Sheet, finalSkill, i.Value, null, malus);
                                tf.afficherInfo();
                                tf.ShowDialog();
                            }
                            else if (zoneExamen.Contains(e.Location))
                            {
                                if (!boxDifficulty.SelectedItem.Equals(Difficulty.None))
                                {
                                    Difficulty d = (Difficulty)boxDifficulty.SelectedItem;
                                    TrialForm tf = new TrialForm(persoDépacer.Sheet, finalSkill, i.Value, d, malus);
                                    tf.afficherInfo();
                                    tf.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Veuillez choisir une difficulté svp");
                                }
                            }
                        }
                    }
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

        private Skill FindBestSubstitution(MysterySheet sheet, Indicator targetIndicator, Skill missingSkill)
        {
            Skill bestSkill = Skill.None;
            int highestLevel = -1;
            foreach (Skill s in sheet.Skills.Keys)
            {
                if (s.GetIndicator() == targetIndicator && s != missingSkill)
                {
                    int currentLevel = sheet.Skills[s];
                    if (currentLevel > 0 && currentLevel > highestLevel)
                    {
                        highestLevel = currentLevel;
                        bestSkill = s;
                    }
                }
            }
            return bestSkill;
        }
    }
}
