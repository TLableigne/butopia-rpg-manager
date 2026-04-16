using ButopiaMysteries.Logic;
using System.Windows.Forms;

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

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public CharacterSelect()
        {
            InitializeComponent();
            // Very first try: create a character, put it in the roster, associate it to the button
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
            foreach (CharacterView view in views)
            {
                view.Draw(e.Graphics);
            }
        }
        private void CreateCharacterViews()
        {
            views.Clear();
            int x = referencePoint.X;
            int y = referencePoint.Y + ViewSettings.DefaultPawnSide;
            foreach (string name in Roster.Sheets.Keys)
            {
                views.Add(new CharacterView(Roster.Sheets[name], new Point(x, y)));
                y += ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Height;
            }
            referencePoint = new(x, y);
        }
        private void AddOneNewCharacterView(MysterySheet sheet)
        {
            views.Add(new CharacterView(sheet, new Point(referencePoint.X, referencePoint.Y + ViewSettings.DefaultPawnSide)));
            referencePoint = new Point(referencePoint.X, referencePoint.Y + ViewSettings.DefaultPawnSide + ViewSettings.DefaultPawnFrame.Height);
            Refresh();
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
                AddOneNewCharacterView(sheet);
            }
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void CharacterSelect_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (CharacterView view in views)
            {
                if (view.Contains(e.Location)) 
                { 
                    ShowSheetViewFor(view.Sheet.Name);
                }
               
            }
                
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        {

        }
    }
}
