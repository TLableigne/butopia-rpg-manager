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
    public partial class PreferencesDialog : Form
    {
        public PreferencesDialog()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ViewSettings.CharacterColor = colorDialog.Color;
                    label5.BackColor = colorDialog.Color;
                    label5.ForeColor = colorDialog.Color;
                    ViewSettings.DefaultPawnColour = colorDialog.Color;
                    Refresh();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ViewSettings.BackgroundColor = colorDialog.Color;
                    label4.BackColor = colorDialog.Color;
                    label4.ForeColor = colorDialog.Color;
                    Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewSettings.InitialCharacterCount = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
