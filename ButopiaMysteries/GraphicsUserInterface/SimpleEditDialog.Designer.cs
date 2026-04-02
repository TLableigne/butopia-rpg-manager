namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class SimpleEditDialog
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
            nameLabel = new Label();
            currentValueLabel = new Label();
            pointsLabel = new Label();
            plusButton = new Button();
            minusButton = new Button();
            cancelButton = new Button();
            okButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 23);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "The name";
            // 
            // currentValueLabel
            // 
            currentValueLabel.AutoSize = true;
            currentValueLabel.Location = new Point(117, 23);
            currentValueLabel.Name = "currentValueLabel";
            currentValueLabel.Size = new Size(57, 15);
            currentValueLabel.TabIndex = 1;
            currentValueLabel.Text = "The value";
            // 
            // pointsLabel
            // 
            pointsLabel.AutoSize = true;
            pointsLabel.Location = new Point(272, 23);
            pointsLabel.Name = "pointsLabel";
            pointsLabel.Size = new Size(91, 15);
            pointsLabel.TabIndex = 2;
            pointsLabel.Text = "Available Points";
            // 
            // plusButton
            // 
            plusButton.Location = new Point(468, 19);
            plusButton.Name = "plusButton";
            plusButton.Size = new Size(75, 23);
            plusButton.TabIndex = 3;
            plusButton.Text = "Plus un";
            plusButton.UseVisualStyleBackColor = true;
            plusButton.Click += PlusClick;
            // 
            // minusButton
            // 
            minusButton.Location = new Point(549, 19);
            minusButton.Name = "minusButton";
            minusButton.Size = new Size(75, 23);
            minusButton.TabIndex = 4;
            minusButton.Text = "Moins un";
            minusButton.UseVisualStyleBackColor = true;
            minusButton.Click += MinusClick;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(639, 19);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Annuler";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(720, 19);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 6;
            okButton.Text = "Confirmer";
            okButton.UseVisualStyleBackColor = true;
            // 
            // SimpleEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 63);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(minusButton);
            Controls.Add(plusButton);
            Controls.Add(pointsLabel);
            Controls.Add(currentValueLabel);
            Controls.Add(nameLabel);
            Name = "SimpleEditDialog";
            Text = "Edit dialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label currentValueLabel;
        private Label pointsLabel;
        private Button plusButton;
        private Button minusButton;
        private Button cancelButton;
        private Button okButton;
    }
}