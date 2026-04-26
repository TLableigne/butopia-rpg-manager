using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButopiaMysteries.GraphicsUserInterface
{
    /// <summary>
    /// A simple edit dialog with limitations.
    /// </summary>
    public partial class SimpleEditDialog : Form
    {
        /// <summary>
        /// The name of the stat being edited.
        /// </summary>
        private string name=string.Empty;
        /// <summary>
        /// The value (start & end) = level.
        /// </summary>
        public int Value { get; private set; }
        /// <summary>
        /// The points available.
        /// </summary>
        public int Points { get; private set; }
        /// <summary>
        /// Indicates whether the edited stat is a Skill.
        /// </summary>
        private readonly bool skill;
        /// <summary>
        /// Indicates whether the edited stat is an Indicator.
        /// </summary>
        private readonly bool indicator;
        /// <summary>
        /// Constructor: skill version
        /// </summary>
        /// <param name="skill">the skill</param>
        /// <param name="value">the value (start level)</param>
        /// <param name="points">the points (available before)</param>
        public SimpleEditDialog(Skill skill, int value, int points)
        {
            Construct(skill.Name(), value, points);
            this.skill = true;
            this.indicator = false;
            if (points < Skill_Operations.SkillPointsAtLevel(value + 1) || value >= Skill_Operations.CreationThreshold
                || value >= Skill_Operations.MaxValue)
            {
                plusButton.Enabled = false;
            }
            if (value <= Skill_Operations.MinValue)
            {
                minusButton.Enabled = false;
            }
        }
        /// <summary>
        /// Constructor: indicator version
        /// </summary>
        /// <param name="indicator">the indicator</param>
        /// <param name="value">the value (start level)</param>
        /// <param name="points">the points (available before)</param>
        public SimpleEditDialog(Indicator indicator, int value, int points)
        {
            Construct(indicator.Name(), value, points);
            this.skill = false;
            this.indicator = true;
            if (points < Indicator_Operations.IndicatorPointsAtLevel(value + 1) || value >= Indicator_Operations.CreationThreshold
                || value >= Indicator_Operations.MaxValue)
            {
                plusButton.Enabled = false;
            }
            if (value <= Indicator_Operations.MinValue)
            {
                minusButton.Enabled = false;
            }
        }

        /// <summary>
        /// Initializes the common UI elements and sets the starting values.
        /// </summary>
        private void Construct(string name, int value, int points)
        {
            InitializeComponent();
            this.name = name;
            this.Value = value;
            this.Points = points;
            nameLabel.Text = name;
            CurrentValues();
        }

        /// <summary>
        /// Updates the displayed labels for the current value and remaining points.
        /// </summary>
        private void CurrentValues()
        {
            currentValueLabel.Text = "Valeur actuelle : " + Value;
            pointsLabel.Text = "Points disponibles : " + Points;
        }



        private void MinusClick(object sender, EventArgs e)
        {
            Points += indicator ? Indicator_Operations.IndicatorPointsAtLevel(Value) : Skill_Operations.SkillPointsAtLevel(Value);
            Value--;
            UpdateButtonsState();
            CurrentValues();
        }

        private void PlusClick(object sender, EventArgs e)
        {
            Points -= indicator ? Indicator_Operations.IndicatorPointsAtLevel(Value + 1) : Skill_Operations.SkillPointsAtLevel(Value + 1);
            Value++;
            UpdateButtonsState();
            CurrentValues();
        }

        /// <summary>
        /// Evaluates the current state to enable or disable the plus/minus buttons based on limits and available points.
        /// </summary>
        private void UpdateButtonsState()
        {
            int minValue = indicator ? Indicator_Operations.MinValue : Skill_Operations.MinValue;
            int maxValue = indicator ? Indicator_Operations.MaxValue : Skill_Operations.MaxValue;
            minusButton.Enabled = (Value > minValue);

            if (Value < maxValue)
            {
                int nextCost = indicator ? Indicator_Operations.IndicatorPointsAtLevel(Value + 1) : Skill_Operations.SkillPointsAtLevel(Value + 1);
                plusButton.Enabled = (Points >= nextCost);
            }
            else
            {
                plusButton.Enabled = false;
            }
        }
    }
}
