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
        /// The name of the character.
        /// </summary>
        /// 

        public Rules SelectedRules;
        public string CharacterName { get { return nameTextBox.Text; } }
        /// <summary>
        /// The fact that this character is randomly created or not.
        /// </summary>
        public bool RandomGeneration { get { return randomCreationCheckBox.Checked; } }

        public bool FixePoint { get { return fixePointCheckBox.Checked; } }
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
                okButton.Enabled = false;
                SelectedRules = Rules.Fixed;
                randomCreationCheckBox.Checked = false;
            }
        }
    }
}
