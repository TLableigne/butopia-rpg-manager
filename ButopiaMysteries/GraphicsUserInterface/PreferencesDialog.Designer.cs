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
            label1 = new Label();
            label4 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // NumberOfCharacterLabel
            // 
            NumberOfCharacterLabel.AutoSize = true;
            NumberOfCharacterLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NumberOfCharacterLabel.Location = new Point(23, 203);
            NumberOfCharacterLabel.Name = "NumberOfCharacterLabel";
            NumberOfCharacterLabel.Size = new Size(156, 21);
            NumberOfCharacterLabel.TabIndex = 0;
            NumberOfCharacterLabel.Text = "Nombre de Mystères";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(196, 203);
            numericUpDown1.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(94, 23);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // BackgroundColorLabel
            // 
            BackgroundColorLabel.AutoSize = true;
            BackgroundColorLabel.Font = new Font("Segoe UI", 12F);
            BackgroundColorLabel.Location = new Point(23, 247);
            BackgroundColorLabel.Name = "BackgroundColorLabel";
            BackgroundColorLabel.Size = new Size(122, 21);
            BackgroundColorLabel.TabIndex = 2;
            BackgroundColorLabel.Text = "Couleur de fond";
            // 
            // CharacterColorLabel
            // 
            CharacterColorLabel.AutoSize = true;
            CharacterColorLabel.Font = new Font("Segoe UI", 12F);
            CharacterColorLabel.Location = new Point(23, 297);
            CharacterColorLabel.Name = "CharacterColorLabel";
            CharacterColorLabel.Size = new Size(160, 21);
            CharacterColorLabel.TabIndex = 3;
            CharacterColorLabel.Text = "Couleur des Mystères";
            // 
            // ChooseColorBGLabel
            // 
            ChooseColorBGLabel.AutoSize = true;
            ChooseColorBGLabel.BackColor = Color.Black;
            ChooseColorBGLabel.BorderStyle = BorderStyle.FixedSingle;
            ChooseColorBGLabel.Font = new Font("Segoe UI", 12F);
            ChooseColorBGLabel.Location = new Point(196, 247);
            ChooseColorBGLabel.Name = "ChooseColorBGLabel";
            ChooseColorBGLabel.Size = new Size(94, 23);
            ChooseColorBGLabel.TabIndex = 4;
            ChooseColorBGLabel.Text = "label4          ";
            ChooseColorBGLabel.Click += ChooseColorBGLabel_Click;
            // 
            // ChooseColorCharLabel
            // 
            ChooseColorCharLabel.AutoSize = true;
            ChooseColorCharLabel.BackColor = Color.Black;
            ChooseColorCharLabel.BorderStyle = BorderStyle.FixedSingle;
            ChooseColorCharLabel.Font = new Font("Segoe UI", 12F);
            ChooseColorCharLabel.Location = new Point(196, 297);
            ChooseColorCharLabel.Name = "ChooseColorCharLabel";
            ChooseColorCharLabel.Size = new Size(94, 23);
            ChooseColorCharLabel.TabIndex = 5;
            ChooseColorCharLabel.Text = "label5          ";
            ChooseColorCharLabel.Click += ChooseColorCharLabel_Click;
            // 
            // buttonOk
            // 
            buttonOk.BackColor = SystemColors.Info;
            buttonOk.Location = new Point(439, 216);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(247, 110);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "NOUVELLE PARTIE";
            buttonOk.UseVisualStyleBackColor = false;
            buttonOk.Click += buttonOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 169);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 7;
            label1.Text = "Options";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI Semibold", 27.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(23, 30);
            label4.Name = "label4";
            label4.Size = new Size(484, 52);
            label4.TabIndex = 10;
            label4.Text = "LES MYSTERES DE BUTOPIA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(605, 40);
            label2.Name = "label2";
            label2.Size = new Size(81, 30);
            label2.TabIndex = 11;
            label2.Text = "Maj 5.3";
            // 
            // PreferencesDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.editDialogBG__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(712, 338);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(buttonOk);
            Controls.Add(ChooseColorCharLabel);
            Controls.Add(ChooseColorBGLabel);
            Controls.Add(CharacterColorLabel);
            Controls.Add(BackgroundColorLabel);
            Controls.Add(numericUpDown1);
            Controls.Add(NumberOfCharacterLabel);
            DoubleBuffered = true;
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
        private Label label1;
        private Label label4;
        private Label label2;
    }
}