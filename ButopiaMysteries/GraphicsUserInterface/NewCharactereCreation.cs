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
    public partial class NewCharactereCreation : Form
    {
        private int etapeActuelle = 1;
        private const int max = 5;
        public MysterySheet NouveauPersonnage { get; private set; }
        public NewCharactereCreation()
        {
            InitializeComponent();
            panelEtape1.Visible = false;
            panelEtape2.Visible = false;
            panelEtape3.Visible = false;
            panelEtape4.Visible = false;
            panelEtape5.Visible = false;
        }
        private void MettreAJourAffichage()
        {
            switch (etapeActuelle)
            {
                case 1: panelEtape1.Visible = true; break;
                case 2: panelEtape2.Visible = true; break;
                case 3: panelEtape3.Visible = true; break;
                case 4: panelEtape4.Visible = true; break;
                case 5: panelEtape5.Visible = true; break;
            }
            précedentBouton.Enabled = (etapeActuelle > 1);

            if (etapeActuelle == max)
            {
                suivantBouton.Text = "Terminer";
            }
            else
            {
                suivantBouton.Text = "Suivant";
            }
        }

        private void précedentBouton_Click(object sender, EventArgs e)
        {
            if (etapeActuelle > 1)
            {
                etapeActuelle--;
                MettreAJourAffichage();
            }
        }

        private void suivantBouton_Click(object sender, EventArgs e)
        {
            if (etapeActuelle < max)
            {
                etapeActuelle++;
                MettreAJourAffichage();
            }
            else
            {
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
        }
    }
}
