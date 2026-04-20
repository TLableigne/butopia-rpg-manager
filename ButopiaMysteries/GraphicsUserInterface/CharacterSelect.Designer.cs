namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class CharacterSelect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            createButton = new Button();
            quitButton = new Button();
            boxDifficulty = new ComboBox();
            BoxSkill = new ComboBox();
            SuspendLayout();
            // 
            // createButton
            // 
            createButton.Location = new Point(652, 12);
            createButton.Name = "createButton";
            createButton.Size = new Size(136, 23);
            createButton.TabIndex = 1;
            createButton.Text = "Nouveau mystère...";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(713, 402);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(75, 23);
            quitButton.TabIndex = 2;
            quitButton.Text = "Quitter";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += QuitButton_Click;
            // 
            // boxDifficulty
            // 
            boxDifficulty.FormattingEnabled = true;
            boxDifficulty.Location = new Point(358, 12);
            boxDifficulty.Name = "boxDifficulty";
            boxDifficulty.Size = new Size(121, 23);
            boxDifficulty.TabIndex = 3;
            // 
            // BoxSkill
            // 
            BoxSkill.FormattingEnabled = true;
            BoxSkill.Location = new Point(507, 12);
            BoxSkill.Name = "BoxSkill";
            BoxSkill.Size = new Size(121, 23);
            BoxSkill.TabIndex = 4;
            // 
            // CharacterSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BoxSkill);
            Controls.Add(boxDifficulty);
            Controls.Add(quitButton);
            Controls.Add(createButton);
            Name = "CharacterSelect";
            Text = "Sélection";
            Load += CharacterSelect_Load;
            Paint += CharacterSelect_Paint;
            MouseDown += CharacterSelect_MouseDown;
            ResumeLayout(false);
        }

        #endregion
        private Button createButton;
        private Button quitButton;
        private ComboBox boxDifficulty;
        private ComboBox BoxSkill;
    }
}
