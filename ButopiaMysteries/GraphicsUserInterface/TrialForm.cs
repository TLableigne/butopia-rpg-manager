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
        public TrialForm(MysterySheet sheet, Skill skill, Indicator indicator, Difficulty? diff )
        {
            InitializeComponent();
            Sheet = sheet;
            Skill = skill;
            Indicator = indicator;
            Diff = diff;
        }
        public void afficherInfo() 
        {
            Nom.Text = "Personnage : " + Sheet.Name;
            Competance.Text = $"Compétence : "+ Skill.Name() +  " - Niveau : " + Sheet.Skills[Skill];
            Indicateur.Text = $"Indicateur : " + Indicator + " - Niveau : " + Sheet.Indicators[Indicator];
            if (Diff != null )
            {
                Difficulte.Text = "Difficulté visée : " + Diff.Value.Name();
            }
            else
            {
                Difficulte.Text = "Type : Épreuve Ouverte";
            }

            result.Text = "Jeux en cours";


        }

    }
}
