using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A basic dialog for character creation.
    /// </summary>
    public partial class NewCharacterDialog : Form
    {

        /// <summary>
        /// The specific ruleset selected for character creation (e.g., None, Fixed).
        /// </summary>
        public Rules SelectedRules;
        /// <summary>
        /// The name of the character.
        /// </summary>
        /// 
        public string CharacterName { get { return nameTextBox.Text; } }
        /// <summary>
        /// The fact that this character is randomly created or not.
        /// </summary>
        public bool RandomGeneration { get { return randomCreationCheckBox.Checked; } }
        /// <summary>
        /// Indicates if the user opted for a fixed points creation method.
        /// </summary>
        public bool FixePoint { get { return fixePointCheckBox.Checked; } }
        /// <summary>
        /// The Plan chosen by the user from the dropdown menu.
        /// </summary>
        public Plan SelectedPlan => (Plan)boxPlan.SelectedItem;
        /// <summary>
        /// The Sphere chosen by the user from the dropdown menu.
        /// </summary>
        public Sphere SelectedSphere => (Sphere)boxSphere.SelectedItem;
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public NewCharacterDialog()
        {
            InitializeComponent();
            okButton.Enabled = false;
            SelectedRules = Rules.None;
        }
        private void NameTextBox_DoubleClick(object sender, EventArgs e)
        {
            nameTextBox.Text = Names.RandomName;
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

            okButton.Enabled = nameLabel.Text.Length > 0;
        }



        private void NewCharacterDialog_Load(object sender, EventArgs e)
        {       
            boxSphere.DataSource = Enum.GetValues(typeof(Sphere));
            boxPlan.DataSource = Enum.GetValues(typeof(Plan));
        }

        private void randomCreationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            okButton.Enabled = true;
            if (randomCreationCheckBox.Checked)
            {
                SelectedRules = Rules.None;
                fixePointCheckBox.Checked = false;
            }
        }
        private void fixePointCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fixePointCheckBox.Checked)
            {
                SelectedRules = Rules.Fixed;
                randomCreationCheckBox.Checked = false;
            }
        }
    }
}
