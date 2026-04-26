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
    /// A dialog window allowing the user to configure global visual settings and initial roster parameters.
    /// </summary>
    public partial class PreferencesDialog : Form
    {
        public PreferencesDialog()
        {
            InitializeComponent();
            ChooseColorBGLabel.BackColor = ViewSettings.BackgroundColor;
            ChooseColorBGLabel.ForeColor = ViewSettings.BackgroundColor;
            ChooseColorCharLabel.BackColor = ViewSettings.DefaultPawnColour;
            ChooseColorCharLabel.ForeColor = ViewSettings.DefaultPawnColour;
        }

        /// <summary>
        /// Opens a color dialog to set the default character pawn color.
        /// </summary>
        private void ChooseColorCharLabel_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ViewSettings.CharacterColor = colorDialog.Color;
                    ChooseColorCharLabel.BackColor = colorDialog.Color;
                    ChooseColorCharLabel.ForeColor = colorDialog.Color;
                    ViewSettings.DefaultPawnColour = colorDialog.Color;
                    Refresh();
                }
            }
        }

        /// <summary>
        /// Opens a color dialog to set the main background color.
        /// </summary>
        private void ChooseColorBGLabel_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ViewSettings.BackgroundColor = colorDialog.Color;
                    ChooseColorBGLabel.BackColor = colorDialog.Color;
                    ChooseColorBGLabel.ForeColor = colorDialog.Color;
                    Refresh();
                }
            }
        }

        /// <summary>
/// Validates the preferences and updates the global application settings.
/// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            ViewSettings.InitialCharacterCount = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
