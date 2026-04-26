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


            comboBoxPlan.DataSource = Enum.GetValues(typeof(Plan));
            comboBoxSphere.DataSource = Enum.GetValues(typeof(Sphere));
            MettreAJourAffichage();
        }

        private void MettreAJourAffichage()
        {
            switch (etapeActuelle)
            {
                case 1:
                    panelEtape1.Visible = true;
                    break;
                case 2:
                    panelEtape2.Visible = true;
                    break;
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
            if (etapeActuelle == 1)
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("Veuillez entrer un nom pour votre personnage !");
                    return;
                }
                else
                {
                    NouveauPersonnage = new MysterySheet(textBoxName.Text, (Plan)comboBoxPlan.SelectedItem, (Sphere)comboBoxSphere.SelectedItem);
                }
            }
            else if (etapeActuelle == 2)
            {
                int valCorps = (int)comboBoxPlan.SelectedItem;
                int valEsprit = (int)comboBoxPlan.SelectedItem;
                int valSens = (int)comboBoxPlan.SelectedItem;

                if (valCorps != valEsprit && valCorps != valSens && valEsprit != valSens && (valCorps + valEsprit + valSens == 9))
                {
                    NouveauPersonnage.Indicators[Indicator.Body] = 0;
                    NouveauPersonnage.Indicators[Indicator.Mind] = 0;
                    NouveauPersonnage.Indicators[Indicator.Sense] = 0;

                    switch (NouveauPersonnage.MyPlan)
                    {
                        case Plan.Makers:
                            NouveauPersonnage.Indicators[Indicator.Body] = 2;
                            break;
                        case Plan.Thinkers:
                            NouveauPersonnage.Indicators[Indicator.Mind] = 2;
                            break;
                        case Plan.Legates:
                            NouveauPersonnage.Indicators[Indicator.Sense] = 2;
                            break;
                        case Plan.Traders:
                            NouveauPersonnage.Indicators[Indicator.Sense] = 2;
                            break;
                        case Plan.Integrators:
                            if (valCorps <= valEsprit && valCorps <= valSens)
                            {
                                NouveauPersonnage.Indicators[Indicator.Mind] = 1;
                                NouveauPersonnage.Indicators[Indicator.Sense] = 1;
                            }
                            else if (valEsprit <= valCorps && valEsprit <= valSens)
                            {
                                NouveauPersonnage.Indicators[Indicator.Body] = 1;
                                NouveauPersonnage.Indicators[Indicator.Sense] = 1;
                            }
                            else
                            {
                                NouveauPersonnage.Indicators[Indicator.Body] = 1;
                                NouveauPersonnage.Indicators[Indicator.Mind] = 1;
                            }
                            break;
                    }

                    NouveauPersonnage.Indicators[Indicator.Body] += valCorps;
                    NouveauPersonnage.Indicators[Indicator.Mind] += valEsprit;
                    NouveauPersonnage.Indicators[Indicator.Sense] += valSens;

                    NouveauPersonnage.Indicators[Indicator.Maximum] = Math.Max(Math.Max(NouveauPersonnage.Indicators[Indicator.Body], NouveauPersonnage.Indicators[Indicator.Mind]), NouveauPersonnage.Indicators[Indicator.Sense]);
                    NouveauPersonnage.InitSanteMentale();
                }
                else
                {
                    MessageBox.Show("Erreur : Vous devez utiliser exactement 2, 3 et 4.");
                    return;
                }
            }
            else if (etapeActuelle == 3)
            {

            }

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
