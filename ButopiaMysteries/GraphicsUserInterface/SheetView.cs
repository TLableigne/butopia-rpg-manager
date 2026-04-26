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
            labelSanteMental.Text = "Santé Mentale : " + Sheet.SanteMentale + " / " + Sheet.SanteMentaleMax;
            nameLabel.Text = Sheet.Name;
            sphereLabel.Text += Sheet.MySphere.Name();
            planLabel.Text += Sheet.MyPlan.Name();
            labelAge.Text = "Âge : " + Sheet.Age;
            labelWealth.Text = "Richesse : " + Sheet.Wealth + " rubis";
            indicatorLabels.Clear();
            skillLabels.Clear();
            indicatorLabels.Add(Indicator.Body, indicLabel1);
            indicatorLabels.Add(Indicator.Mind, indicLabel2);
            indicatorLabels.Add(Indicator.Sense, indicLabel3);
            indicatorLabels.Add(Indicator.Maximum, indicLabel4);
            Label[] tousLesLabels = {
            skillLabel1, skillLabel2, skillLabel3, skillLabel4,
            skillLabel5, skillLabel6, skillLabel7, skillLabel8,
            skillLabel9, skillLabel10, skillLabel11, skillLabel12,
            skillLabel13, skillLabel14, skillLabel15, skillLabel16
            };
            foreach (Label l in tousLesLabels)
            {
                l.Text = string.Empty;
            }
            int index = 0;
            Indicator[] ordre = { Indicator.Body, Indicator.Mind, Indicator.Sense, Indicator.Maximum };

            foreach (Indicator i in ordre)
            {
                foreach (Skill s in Sheet.Skills.Keys)
                {
                    if (s.GetIndicator() == i && index < tousLesLabels.Length)
                    {
                        skillLabels.Add(s, tousLesLabels[index]);
                        index++;
                    }
                }
            }
            foreach (Skill s in Sheet.Skills.Keys)
            {
                if (!skillLabels.ContainsKey(s) && index < tousLesLabels.Length)
                {
                    skillLabels.Add(s, tousLesLabels[index]);
                    index++;
                }
            }
            labelXP.Text = "XP " + mysterySheet.xp;

            DisplayControls();
        }

        /// <summary>
        /// Refresh the display of points and toggles interface elements based on whether the character is in creation or training mode.
        /// </summary>
        private void DisplayControls()
        {
            if (!Sheet.estEnFormation)
            {
                modeToolStripButton.Text = "Mode Création";
                indicatorPointsToolStripLabel.Visible = true;
                indicatorPointsToolStripLabel.Text = "PI: " + indicatorPoints;
                skillPointsToolStripLabel.Visible = true;
                skillPointsToolStripLabel.Text = "PC: " + skillPoints;
            }
            else
            {
                modeToolStripButton.Text = "Mode Formation";
                indicatorPointsToolStripLabel.Visible = false;
                skillPointsToolStripLabel.Visible = false;
            }
            foreach (Skill skill in skillLabels.Keys)
            {
                skillLabels[skill].Text = DisplaySkill(skill);
            }
            foreach (Indicator indicator in indicatorLabels.Keys)
            {
                indicatorLabels[indicator].Text = DisplayIndicator(indicator);
            }
            listInventory.Items.Clear();
            foreach (string objet in Sheet.Inventaire)
            {
                listInventory.Items.Add(objet);
            }
            textObject.Visible = !Sheet.estEnFormation;
            addButton.Visible = !Sheet.estEnFormation;
        }

        /// <summary>
        /// Formats a skill and its textual level representation for display.
        /// </summary>
        /// <param name="skill">The skill to display.</param>
        /// <returns>A formatted string indicating the skill's name and current level.</returns>
        private string DisplaySkill(Skill skill)
        {
            int level = Sheet.Skills[skill];
            string levelText = Skill_Operations.GetSkillText(level);
            return skill.Name() + " : " + levelText;
        }

        /// <summary>
        /// Formats an indicator and its numeric value for display.
        /// </summary>
        /// <param name="indicator">The indicator to display.</param>
        /// <returns>A formatted string indicating the indicator's name and value.</returns>
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
            Sheet.estEnFormation = true;
            modeToolStripButton.Enabled = false;
            DisplayControls();
        }



        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if (Sheet.estEnFormation)
            {
                return;
            }
            if (sender is Label label)
            {
                Indicator indicator = indicatorLabels.Keys.FirstOrDefault(i => indicatorLabels[i].Equals(label), Indicator.None);
                if (indicator == Indicator.Maximum)
                {
                    return;
                }
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

        /// <summary>
        /// Opens the edition dialog to modify a specific skill's level.
        /// </summary>
        /// <param name="skill">The skill to edit.</param>
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

        /// <summary>
        /// Opens the edition dialog to modify a specific indicator's level and recalculates the Maximum indicator if necessary.
        /// </summary>
        /// <param name="indicator">The indicator to edit.</param>
        private void IndicatorEdit(Indicator indicator)
        {
            SimpleEditDialog dialog = new(indicator, Sheet.Indicators[indicator], indicatorPoints);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                indicatorPoints = dialog.Points;
                Sheet.Indicators[indicator] = dialog.Value;

                int max = Sheet.Indicators[Indicator.Body];
                if (Sheet.Indicators[Indicator.Mind] > max)
                {
                    max = Sheet.Indicators[Indicator.Mind];
                }
                if (Sheet.Indicators[Indicator.Sense] > max)
                {
                    max = Sheet.Indicators[Indicator.Sense];
                }
                Sheet.Indicators[Indicator.Maximum] = max;

                DisplayControls();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textObject.Text))
            {
                Sheet.Inventaire.Add(textObject.Text);
                textObject.Text = "";
                DisplayControls();
            }
        }
    }
}
