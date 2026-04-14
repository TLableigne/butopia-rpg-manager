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
            okButton = new Button();
            cancelButton = new Button();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            randomCreationCheckBox = new CheckBox();
            fixePoint = new CheckBox();
            SuspendLayout();
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(379, 29);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 0;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = SystemColors.ControlLightLight;
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(380, 78);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(60, 34);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(100, 23);
            nameTextBox.TabIndex = 2;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            nameTextBox.DoubleClick += NameTextBox_DoubleClick;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 37);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(42, 15);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Name:";
            // 
            // randomCreationCheckBox
            // 
            randomCreationCheckBox.AutoSize = true;
            randomCreationCheckBox.Location = new Point(166, 38);
            randomCreationCheckBox.Name = "randomCreationCheckBox";
            randomCreationCheckBox.Size = new Size(132, 19);
            randomCreationCheckBox.TabIndex = 4;
            randomCreationCheckBox.Text = "Random Generation";
            randomCreationCheckBox.UseVisualStyleBackColor = true;
            randomCreationCheckBox.CheckedChanged += randomCreationCheckBox_CheckedChanged;
            // 
            // fixePoint
            // 
            fixePoint.AutoSize = true;
            fixePoint.Location = new Point(166, 78);
            fixePoint.Name = "fixePoint";
            fixePoint.Size = new Size(159, 19);
            fixePoint.TabIndex = 5;
            fixePoint.Text = "Utiliser les donné de base";
            fixePoint.UseVisualStyleBackColor = true;
            // 
            // NewCharacterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 131);
            Controls.Add(fixePoint);
            Controls.Add(randomCreationCheckBox);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Name = "NewCharacterDialog";
            Text = "NewCharacterDialog";
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
        private CheckBox fixePoint;
    }
}