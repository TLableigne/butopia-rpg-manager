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
        public string CharacterName { get { return nameTextBox.Text; } }
        /// <summary>
        /// The fact that this character is randomly created or not.
        /// </summary>
        public bool RandomGeneration { get { return randomCreationCheckBox.Checked; } }

        public bool FixePoint { get { return fixePoint.Checked; } }
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public NewCharacterDialog()
        {
            InitializeComponent();
            okButton.Enabled = false;
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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}