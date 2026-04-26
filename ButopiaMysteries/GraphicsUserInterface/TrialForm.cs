using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ButopiaMysteries.Logic
{
    public partial class TrialForm : Form
    {
        private MysterySheet Sheet;
        private Skill Skill;
        private Indicator Indicator;
        private Difficulty? Diff;
        private int Malus;

        public TrialForm(MysterySheet sheet, Skill skill, Indicator indicator, Difficulty? diff, int malus=0)
        {
            InitializeComponent();
            Sheet = sheet;
            Skill = skill;
            Indicator = indicator;
            Diff = diff;
            result.Text = "";
            Malus = malus;
            MettreAJourAffichageSante();
        }
        public void afficherInfo()
        {
            Nom.Text = "Personnage : " + Sheet.Name;
            if (Malus > 0)
            {
                Competence.Text = $"Compétence : " + Skill.Name() + " - Niveau : " + Sheet.Skills[Skill] + " (Substitution -> Malus -2)";
            }
            else
            {
                Competence.Text = $"Compétence : " + Skill.Name() + " - Niveau : " + Sheet.Skills[Skill];
            }
            Indicateur.Text = $"Indicateur : " + Indicator + " - Niveau : " + Sheet.Indicators[Indicator];
            if (Diff != null)
            {
                Difficulte.Text = "Difficulté visée : " + Diff.Value.Name();
                Type.Text = "Épreuve Fermée";
            }
            else
            {
                Type.Text = "Épreuve Ouverte";
            }
        }

        private void Lancer_Click(object sender, EventArgs e)
        {
            Lancer.Enabled = false;

            string text = "";
            int nbEpreuves = (int)numUpDownNbEpreuve.Value;
            if (Diff != null)
            {
                for (int i = 1; i <= nbEpreuves; i++)
                {

                    bool res = Trial.ClosedTrial(Sheet, Indicator, Skill, (Difficulty)Diff, Malus);

                    if (res)
                    {
                        text += $"Bravo tu as passé l'épreuve n°{i}" + Environment.NewLine;
                        Sheet.xp++; 
                    }
                    else
                    {
                        text += $"Dommage tu n'as pas réussi l'épreuve n°{i}..." + Environment.NewLine;
                    }
                }

                result.Text = "Épreuves fermées terminées.";
            }

            else
            {
                for (int i = 1; i <= nbEpreuves; i++)
                {
                    Difficulty res = Trial.OpenTrial(Sheet, Indicator, Skill, Malus);

                    text += $"Bravo tu as atteint la difficulté : {Difficulty_Operations.Name(res)} pour l'épreuve n°{i}" + Environment.NewLine;
                }
                result.Text = "Épreuves ouvertes terminées.";
            }
            MettreAJourAffichageSante();
            MessageBox.Show(text, "Résultats");
        }

        private void MettreAJourAffichageSante()
        {
            string etat;
            if (Sheet.EstEnCrise()) {
                etat = Sheet.Name + "  - En crise "; 
            }
            else
            {
                etat = Sheet.Name + " - Stable ";
            }
            labelSanteMentale.Text = "Santé Mentale :"+ Sheet.SanteMentale+" / "+Sheet.SanteMentaleMax + etat;
        }
    }
}
 