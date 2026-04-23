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
        public TrialForm(MysterySheet sheet, Skill skill, Indicator indicator, Difficulty? diff)
        {
            InitializeComponent();
            Sheet = sheet;
            Skill = skill;
            Indicator = indicator;
            Diff = diff;
            result.Text = "";
        }
        public void afficherInfo()
        {
            Nom.Text = "Personnage : " + Sheet.Name;
            Competance.Text = $"Compétence : " + Skill.Name() + " - Niveau : " + Sheet.Skills[Skill];
            Indicateur.Text = $"Indicateur : " + Indicator + " - Niveau : " + Sheet.Indicators[Indicator];
            if (Diff != null)
            {
                Difficulte.Text = "Difficulté visée : " + Diff.Value.Name();
            }
            else
            {
                Difficulte.Text = "Type : Épreuve Ouverte";
            }
            result.Text = " Le résultat sera ici lance l'épreuve pour le découvrir ";
        }

        private void Lancer_Click(object sender, EventArgs e)
        {
            string text ="";
            for (int i = 0; i < numUpDownNbEpreuve.Value; i++)
            {
                Lancer.Enabled = false;
                if (Diff != null)
                {
                    bool res = Trial.ClosedTrial(Sheet, Indicator, Skill, (Difficulty)Diff);
                    if (res)
                    {
                        text +="Bravo tu as passé l'epreuve n°"+i + Environment.NewLine; 
                    }
                    else
                    {
                        text += "Dommage tu n'as pas réussi l'épreuve n°"+i + Environment.NewLine;
                    }
                }
                else
                {
                    Difficulty res = Trial.OpenTrial(Sheet, Indicator, Skill);
                    text += "Bravo tu as réussi a atteindre la difficulté : " + Difficulty_Operations.Name(res) +" pour l'épreuve n°"+i+ Environment.NewLine;

                }
            }
            MessageBox.Show(text);
        }  
    }
}
 