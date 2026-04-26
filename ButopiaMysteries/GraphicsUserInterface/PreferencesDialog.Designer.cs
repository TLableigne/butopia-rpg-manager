namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class PreferencesDialog
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
            NumberOfCharacterLabel = new Label();
            numericUpDown1 = new NumericUpDown();
            BackgroundColorLabel = new Label();
            CharacterColorLabel = new Label();
            ChooseColorBGLabel = new Label();
            ChooseColorCharLabel = new Label();
            buttonOk = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // NumberOfCharacterLabel
            // 
            NumberOfCharacterLabel.AutoSize = true;
            NumberOfCharacterLabel.Location = new Point(44, 61);
            NumberOfCharacterLabel.Name = "NumberOfCharacterLabel";
            NumberOfCharacterLabel.Size = new Size(122, 15);
            NumberOfCharacterLabel.TabIndex = 0;
            NumberOfCharacterLabel.Text = "Number of characters";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(182, 59);
            numericUpDown1.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BackgroundColorLabel
            // 
            BackgroundColorLabel.AutoSize = true;
            BackgroundColorLabel.Location = new Point(44, 105);
            BackgroundColorLabel.Name = "BackgroundColorLabel";
            BackgroundColorLabel.Size = new Size(106, 15);
            BackgroundColorLabel.TabIndex = 2;
            BackgroundColorLabel.Text = "Background Color ";
            // 
            // CharacterColorLabel
            // 
            CharacterColorLabel.AutoSize = true;
            CharacterColorLabel.Location = new Point(44, 155);
            CharacterColorLabel.Name = "CharacterColorLabel";
            CharacterColorLabel.Size = new Size(90, 15);
            CharacterColorLabel.TabIndex = 3;
            CharacterColorLabel.Text = "Character Color";
            // 
            // ChooseColorBGLabel
            // 
            ChooseColorBGLabel.AutoSize = true;
            ChooseColorBGLabel.BackColor = Color.Black;
            ChooseColorBGLabel.BorderStyle = BorderStyle.FixedSingle;
            ChooseColorBGLabel.Location = new Point(172, 105);
            ChooseColorBGLabel.Name = "ChooseColorBGLabel";
            ChooseColorBGLabel.Size = new Size(40, 17);
            ChooseColorBGLabel.TabIndex = 4;
            ChooseColorBGLabel.Text = "label4";
            ChooseColorBGLabel.Click += ChooseColorBGLabel_Click;
            // 
            // ChooseColorCharLabel
            // 
            ChooseColorCharLabel.AutoSize = true;
            ChooseColorCharLabel.BackColor = Color.Black;
            ChooseColorCharLabel.BorderStyle = BorderStyle.FixedSingle;
            ChooseColorCharLabel.Location = new Point(172, 155);
            ChooseColorCharLabel.Name = "ChooseColorCharLabel";
            ChooseColorCharLabel.Size = new Size(40, 17);
            ChooseColorCharLabel.TabIndex = 5;
            ChooseColorCharLabel.Text = "label5";
            ChooseColorCharLabel.Click += ChooseColorCharLabel_Click;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(401, 221);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // PreferencesDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonOk);
            Controls.Add(ChooseColorCharLabel);
            Controls.Add(ChooseColorBGLabel);
            Controls.Add(CharacterColorLabel);
            Controls.Add(BackgroundColorLabel);
            Controls.Add(numericUpDown1);
            Controls.Add(NumberOfCharacterLabel);
            Name = "PreferencesDialog";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NumberOfCharacterLabel;
        private NumericUpDown numericUpDown1;
        private Label BackgroundColorLabel;
        private Label CharacterColorLabel;
        private Label ChooseColorBGLabel;
        private Label ChooseColorCharLabel;
        private Button buttonOk;
    }
}