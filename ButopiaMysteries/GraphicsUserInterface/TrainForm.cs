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
            NameLabel.Text = $"Entraînement de : " + Sheet.Name;
            XPLabel.Text = $"Points d'expérience (XP) : " + Sheet.xp;
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
                    MessageBox.Show(selectedSkill + " est maintenant au niveau " + niveauSuivant + " !");
                    UpdateDisplay();
                }
                else
                {
                    MessageBox.Show($"XP insuffisant ! Il vous faut" + cost + "XP pour le niveau " + niveauSuivant + ".");
                }
            }
            else
            {
                MessageBox.Show("Niveau maximum déjà atteint !");
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
                    MessageBox.Show(selectedInd+" est maintenant au niveau "+niveauSuivant);
                    UpdateDisplay();
                }
                else
                {
                    MessageBox.Show("XP insuffisant ! Il vous faut" + cout + " XP pour le niveau "+niveauSuivant);
                }
            }
            else
            {
                MessageBox.Show("Niveau maximum déjà atteint !");
            }
        }
    }
}
