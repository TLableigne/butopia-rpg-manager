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
    public partial class TrainForm : Form
    {
        private MysterySheet Sheet { get; }
        public TrainForm(MysterySheet character)
        {
            InitializeComponent();
            Sheet = character;

            SkillComboBox.DataSource = Enum.GetValues(typeof(Skill));
            IndicateurComboBox.DataSource = Enum.GetValues(typeof(Indicator));
            UpdateDisplay();
        }
        public void UpdateDisplay()
        {
            NameLabel.Text = "Entraînement de : " + Sheet.Name;
            XPLabel.Text = "Points d'expérience (XP) : " + Sheet.xp;
            labelResSoigner.Text = "";
        }

        private void TrainSkill_Click(object sender, EventArgs e)
        {
            Skill selectedSkill = (Skill)SkillComboBox.SelectedItem;
            int level = Sheet.Skills[selectedSkill];
            int niveauSuivant = level + 1;
            int cost = niveauSuivant;

            if (level < 6)
            {
                if (Sheet.xp >= cost)
                {
                    Sheet.xp = Sheet.xp - cost;
                    Sheet.Skills[selectedSkill] = niveauSuivant;
                    labelRes.Text = selectedSkill + " est maintenant au niveau " + niveauSuivant + " !";
                    UpdateDisplay();
                }
                else
                {
                    labelRes.Text = $"XP insuffisant ! Il vous faut" + cost + "XP pour le niveau " + niveauSuivant + ".";
                }
            }
            else
            {
                labelRes.Text = "Niveau maximum déjà atteint !";
            }
        }

        private void TrainIndicateur_Click(object sender, EventArgs e)
        {
            Indicator selectedInd = (Indicator)IndicateurComboBox.SelectedItem;
            int level = Sheet.Indicators[selectedInd];
            int niveauSuivant = level + 1;
            int cout = niveauSuivant * 2;

            if (level < 7)
            {
                if (Sheet.xp >= cout)
                {
                    Sheet.xp = Sheet.xp - cout;
                    Sheet.Indicators[selectedInd] = niveauSuivant;
                    labelRes.Text = selectedInd + " est maintenant au niveau " + niveauSuivant;
                    UpdateDisplay();
                }
                else
                {
                    labelRes.Text = "XP insuffisant ! Il vous faut" + cout + " XP pour le niveau " + niveauSuivant;
                }
            }
            else
            {
                labelRes.Text = "Niveau maximum déjà atteint !";
            }
        }

        private void soignerButton_Click(object sender, EventArgs e)
        {
            if (Sheet.EstEnCrise())
            {
                labelResSoigner.Text = "Impossible de se soigner , le personnage est en crise ";
                return; 
            }
            if (Sheet.SanteMentale >= Sheet.SanteMentaleMax)
            {
                labelResSoigner.Text = "La santé mentale est déjà à son maximum ";
                return;
            }
            if (Sheet.xp >= 10)
            {
                Sheet.xp = Sheet.xp - 10;
                Sheet.SanteMentale++;
                labelResSoigner.Text = "Soin réussi ! Vous avez dépensé 10 XP pour récupérer 1 point de Santé Mentale.";
            }
            else
            {
                labelResSoigner.Text = "XP insuffisant ( il en faut 10 ) ";
            }
        }
    }
}

