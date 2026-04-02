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
    /// <summary>
    /// A class to view/edit a Mystery Sheet
    /// </summary>
    public partial class SheetView : Form
    {
        private MysterySheet Sheet { get; init; }
        private readonly Dictionary<Indicator, Label> indicatorLabels = [];
        private readonly Dictionary<Skill, Label> skillLabels = [];
        private bool edit = false;
        private int indicatorPoints = 0;
        private int skillPoints = 0;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mysterySheet">the sheet to display/edit</param>
        public SheetView(MysterySheet mysterySheet)
        {
            InitializeComponent();
            Sheet = mysterySheet;
            nameLabel.Text = Sheet.Name;
            indicatorLabels.Add(Indicator.Body, indicLabel1);
            indicatorLabels.Add(Indicator.Mind, indicLabel2);
            indicatorLabels.Add(Indicator.Sense, indicLabel3);
            indicatorLabels.Add(Indicator.Maximum, indicLabel4);
            skillLabels.Add(Skill.Feat, skillLabel1);
            skillLabel2.Text = string.Empty;
            skillLabels.Add(Skill.Design, skillLabel3);
            skillLabel4.Text = string.Empty;
            skillLabels.Add(Skill.Analysis, skillLabel5);
            skillLabel6.Text = string.Empty;
            skillLabels.Add(Skill.Survival, skillLabel7);
            skillLabel8.Text = string.Empty;
            skillLabels.Add(Skill.Dodge, skillLabel9);
            skillLabel10.Text = string.Empty;
            skillLabels.Add(Skill.Synthesis, skillLabel11);
            skillLabel12.Text = string.Empty;
            skillLabels.Add(Skill.Expression, skillLabel13);
            skillLabel14.Text = string.Empty;
            skillLabels.Add(Skill.Seduction, skillLabel15);
            skillLabel16.Text = string.Empty;
            DisplayControls();
        }
        private void DisplayControls()
        {
            if (edit)
            {
                modeToolStripButton.Text = "Edit Mode";
                indicatorPointsToolStripLabel.Visible = true;
                indicatorPointsToolStripLabel.Text = "PI: " + indicatorPoints;
                skillPointsToolStripLabel.Visible = true;
                skillPointsToolStripLabel.Text = "PC: " + skillPoints;
            }
            else
            {
                modeToolStripButton.Text = "View Mode";
                indicatorPointsToolStripLabel.Visible = false;
                skillPointsToolStripLabel.Visible = false;
            }
            foreach (Skill skill in skillLabels.Keys)
            {
                skillLabels[skill].Text = DisplaySkill(skill);
            }
            foreach(Indicator indicator in indicatorLabels.Keys)
            {
                indicatorLabels[indicator].Text = DisplayIndicator(indicator);
            }
        }
        private string DisplaySkill(Skill skill)
        {
            return skill.Name() + " : " + Sheet.Skills[skill];
        }

        private string DisplayIndicator(Indicator indicator)
        {
            return indicator.Name() + " : " + Sheet.Indicators[indicator];
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ModeToolStripButton_Click(object sender, EventArgs e)
        {
            edit = !edit;
            DisplayControls();
        }


        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (!edit)
            {
                return;
            }
            if (sender is Label label)
            {
                Indicator indicator = indicatorLabels.Keys.FirstOrDefault(i => indicatorLabels[i].Equals(label), Indicator.None);
                if (indicator != Indicator.None)
                {
                    IndicatorEdit(indicator);
                }
                else
                {
                    Skill skill = skillLabels.Keys.FirstOrDefault(s => skillLabels[s].Equals(label), Skill.None);
                    if (skill != Skill.None)
                    {
                        SkillEdit(skill);
                    }
                }
            }
        }
        private void SkillEdit(Skill skill)
        {
            SimpleEditDialog dialog = new(skill, Sheet.Skills[skill], skillPoints);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                skillPoints = dialog.Points;
                Sheet.Skills[skill] = dialog.Value;
                DisplayControls();
            }
        }

        private void IndicatorEdit(Indicator indicator)
        {
            SimpleEditDialog dialog = new(indicator, Sheet.Indicators[indicator], indicatorPoints);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                indicatorPoints = dialog.Points;
                Sheet.Indicators[indicator] = dialog.Value;
                DisplayControls();
            }
        }
    }
}
