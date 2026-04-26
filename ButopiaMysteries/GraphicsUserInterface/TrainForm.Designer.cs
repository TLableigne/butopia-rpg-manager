namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class TrainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameLabel = new Label();
            XPLabel = new Label();
            SkillComboBox = new ComboBox();
            IndicateurComboBox = new ComboBox();
            TrainSkill = new Button();
            TrainIndicateur = new Button();
            Close = new Button();
            IndicateurBoxLabel = new Label();
            SkillComboBoxLabel = new Label();
            soignerButton = new Button();
            labelResSoigner = new Label();
            labelRes = new Label();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(45, 25);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(67, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "NameLabel";
            // 
            // XPLabel
            // 
            XPLabel.AutoSize = true;
            XPLabel.Location = new Point(252, 28);
            XPLabel.Name = "XPLabel";
            XPLabel.Size = new Size(49, 15);
            XPLabel.TabIndex = 1;
            XPLabel.Text = "XPLabel";
            // 
            // SkillComboBox
            // 
            SkillComboBox.FormattingEnabled = true;
            SkillComboBox.Location = new Point(45, 171);
            SkillComboBox.Name = "SkillComboBox";
            SkillComboBox.Size = new Size(121, 23);
            SkillComboBox.TabIndex = 2;
            // 
            // IndicateurComboBox
            // 
            IndicateurComboBox.FormattingEnabled = true;
            IndicateurComboBox.Location = new Point(45, 104);
            IndicateurComboBox.Name = "IndicateurComboBox";
            IndicateurComboBox.Size = new Size(121, 23);
            IndicateurComboBox.TabIndex = 3;
            // 
            // TrainSkill
            // 
            TrainSkill.Location = new Point(492, 122);
            TrainSkill.Name = "TrainSkill";
            TrainSkill.Size = new Size(75, 23);
            TrainSkill.TabIndex = 4;
            TrainSkill.Text = "TrainSkill";
            TrainSkill.UseVisualStyleBackColor = true;
            TrainSkill.Click += TrainSkill_Click;
            // 
            // TrainIndicateur
            // 
            TrainIndicateur.Location = new Point(298, 122);
            TrainIndicateur.Name = "TrainIndicateur";
            TrainIndicateur.Size = new Size(123, 23);
            TrainIndicateur.TabIndex = 5;
            TrainIndicateur.Text = "TrainIndicateur";
            TrainIndicateur.UseVisualStyleBackColor = true;
            TrainIndicateur.Click += TrainIndicateur_Click;
            // 
            // Close
            // 
            Close.DialogResult = DialogResult.Cancel;
            Close.Location = new Point(602, 234);
            Close.Name = "Close";
            Close.Size = new Size(75, 23);
            Close.TabIndex = 6;
            Close.Text = "Fermer";
            Close.UseVisualStyleBackColor = true;
            // 
            // IndicateurBoxLabel
            // 
            IndicateurBoxLabel.AutoSize = true;
            IndicateurBoxLabel.Location = new Point(45, 86);
            IndicateurBoxLabel.Name = "IndicateurBoxLabel";
            IndicateurBoxLabel.Size = new Size(69, 15);
            IndicateurBoxLabel.TabIndex = 7;
            IndicateurBoxLabel.Text = "Indicateur : ";
            // 
            // SkillComboBoxLabel
            // 
            SkillComboBoxLabel.AutoSize = true;
            SkillComboBoxLabel.Location = new Point(45, 153);
            SkillComboBoxLabel.Name = "SkillComboBoxLabel";
            SkillComboBoxLabel.Size = new Size(34, 15);
            SkillComboBoxLabel.TabIndex = 8;
            SkillComboBoxLabel.Text = "Skill :";
            // 
            // soignerButton
            // 
            soignerButton.Location = new Point(45, 234);
            soignerButton.Name = "soignerButton";
            soignerButton.Size = new Size(121, 23);
            soignerButton.TabIndex = 9;
            soignerButton.Text = "Soigner votre perso";
            soignerButton.UseVisualStyleBackColor = true;
            soignerButton.Click += soignerButton_Click;
            // 
            // labelResSoigner
            // 
            labelResSoigner.AutoSize = true;
            labelResSoigner.Location = new Point(252, 242);
            labelResSoigner.Name = "labelResSoigner";
            labelResSoigner.Size = new Size(0, 15);
            labelResSoigner.TabIndex = 10;
            // 
            // labelRes
            // 
            labelRes.AutoSize = true;
            labelRes.Location = new Point(413, 171);
            labelRes.Name = "labelRes";
            labelRes.Size = new Size(0, 15);
            labelRes.TabIndex = 11;
            // 
            // TrainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 287);
            Controls.Add(labelRes);
            Controls.Add(labelResSoigner);
            Controls.Add(soignerButton);
            Controls.Add(SkillComboBoxLabel);
            Controls.Add(IndicateurBoxLabel);
            Controls.Add(Close);
            Controls.Add(TrainIndicateur);
            Controls.Add(TrainSkill);
            Controls.Add(IndicateurComboBox);
            Controls.Add(SkillComboBox);
            Controls.Add(XPLabel);
            Controls.Add(NameLabel);
            Name = "TrainForm";
            Text = "TrainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label XPLabel;
        private ComboBox SkillComboBox;
        private ComboBox IndicateurComboBox;
        private Button TrainSkill;
        private Button TrainIndicateur;
        private Button Close;
        private Label IndicateurBoxLabel;
        private Label SkillComboBoxLabel;
        private Button soignerButton;
        private Label labelResSoigner;
        private Label labelRes;
    }
}