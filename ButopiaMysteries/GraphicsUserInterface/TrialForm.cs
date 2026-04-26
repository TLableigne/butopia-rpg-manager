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
    /// <summary>
    /// A form representing a trial (either open or closed) for a character.
    /// </summary>
    public partial class TrialForm : Form
    {
        private MysterySheet Sheet;
        private Skill Skill;
        private Indicator Indicator;
        private Difficulty? Diff;
        private int Malus;

        /// <summary>
        /// Initializes a new instance of the TrialForm.
        /// </summary>
        /// <param name="sheet">The character sheet taking the trial.</param>
        /// <param name="skill">The skill used for the trial.</param>
        /// <param name="indicator">The indicator used for the trial.</param>
        /// <param name="diff">The target difficulty (null for open trials).</param>
        /// <param name="malus">The malus applied, typically from skill substitution (default is 0).</param>
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
        /// <summary>
        /// Updates the UI labels with the character's information, trial parameters, and any applied malus.
        /// </summary>
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

        /// <summary>
        /// Executes the trial(s) based on the selected parameters and displays the results.
        /// </summary>
        private void Lancer_Click(object sender, EventArgs e)
        {
            Lancer.Enabled = false;
            Sheet.Age++;
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
                        Sheet.Wealth += 50;
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

        /// <summary>
        /// Updates the mental health display and indicates if the character is currently in a state of crisis.
        /// </summary>
        private void MettreAJourAffichageSante()
        {
            string etat;
            if (Sheet.EstEnCrise()) {
                etat = "  - En crise "; 
            }
            else
            {
                etat =  " - Stable ";
            }
            labelMentalHealth.Text = "Santé Mentale :"+ Sheet.SanteMentale+" / "+Sheet.SanteMentaleMax + etat;
        }
    }
}
 