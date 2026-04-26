namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class NewCharacterDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCharacterDialog));
            okButton = new Button();
            cancelButton = new Button();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            randomCreationCheckBox = new CheckBox();
            fixePointCheckBox = new CheckBox();
            boxSphere = new ComboBox();
            boxPlan = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.BackColor = Color.SeaGreen;
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(12, 135);
            okButton.Name = "okButton";
            okButton.Size = new Size(213, 39);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.IndianRed;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(276, 135);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(207, 39);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Annuler";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 34);
            nameTextBox.MaxLength = 15;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(124, 23);
            nameTextBox.TabIndex = 2;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            nameTextBox.DoubleClick += NameTextBox_DoubleClick;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(14, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(34, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Nom";
            // 
            // randomCreationCheckBox
            // 
            randomCreationCheckBox.AutoSize = true;
            randomCreationCheckBox.BackColor = Color.Transparent;
            randomCreationCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            randomCreationCheckBox.ForeColor = SystemColors.ButtonFace;
            randomCreationCheckBox.Location = new Point(37, 76);
            randomCreationCheckBox.Name = "randomCreationCheckBox";
            randomCreationCheckBox.Size = new Size(188, 25);
            randomCreationCheckBox.TabIndex = 4;
            randomCreationCheckBox.Text = "Génération Aléatoire";
            randomCreationCheckBox.UseVisualStyleBackColor = false;
            randomCreationCheckBox.CheckedChanged += randomCreationCheckBox_CheckedChanged;
            // 
            // fixePointCheckBox
            // 
            fixePointCheckBox.AutoSize = true;
            fixePointCheckBox.BackColor = Color.Transparent;
            fixePointCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fixePointCheckBox.ForeColor = SystemColors.Control;
            fixePointCheckBox.Location = new Point(267, 76);
            fixePointCheckBox.Name = "fixePointCheckBox";
            fixePointCheckBox.Size = new Size(222, 25);
            fixePointCheckBox.TabIndex = 5;
            fixePointCheckBox.Text = "Utiliser les Données Fixes";
            fixePointCheckBox.UseVisualStyleBackColor = false;
            fixePointCheckBox.CheckedChanged += fixePointCheckBox_CheckedChanged;
            // 
            // boxSphere
            // 
            boxSphere.FormattingEnabled = true;
            boxSphere.Location = new Point(362, 34);
            boxSphere.Name = "boxSphere";
            boxSphere.Size = new Size(121, 23);
            boxSphere.TabIndex = 6;
            // 
            // boxPlan
            // 
            boxPlan.FormattingEnabled = true;
            boxPlan.Location = new Point(189, 34);
            boxPlan.Name = "boxPlan";
            boxPlan.Size = new Size(121, 23);
            boxPlan.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(189, 9);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 8;
            label1.Text = "Plan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(362, 9);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 9;
            label2.Text = "Sphère";
            // 
            // NewCharacterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(501, 206);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(boxPlan);
            Controls.Add(boxSphere);
            Controls.Add(fixePointCheckBox);
            Controls.Add(randomCreationCheckBox);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            ForeColor = SystemColors.ControlText;
            Name = "NewCharacterDialog";
            Load += NewCharacterDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button okButton;
        private Button cancelButton;
        private TextBox nameTextBox;
        private Label nameLabel;
        private CheckBox randomCreationCheckBox;
        private CheckBox fixePointCheckBox;
        private ComboBox boxSphere;
        private ComboBox boxPlan;
        private Label label1;
        private Label label2;
    }
}