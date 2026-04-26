namespace ButopiaMysteries.GraphicsUserInterface
{
    partial class NewCharactereCreation
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
            suivantBouton = new Button();
            précedentBouton = new Button();
            panelEtape1 = new Panel();
            panelEtape2 = new Panel();
            panelEtape3 = new Panel();
            panelEtape4 = new Panel();
            panelEtape5 = new Panel();
            panelEtape1.SuspendLayout();
            SuspendLayout();
            // 
            // suivantBouton
            // 
            suivantBouton.Location = new Point(698, 387);
            suivantBouton.Name = "suivantBouton";
            suivantBouton.Size = new Size(75, 23);
            suivantBouton.TabIndex = 0;
            suivantBouton.Text = "Suivant";
            suivantBouton.UseVisualStyleBackColor = true;
            suivantBouton.Click += suivantBouton_Click;
            // 
            // précedentBouton
            // 
            précedentBouton.Location = new Point(572, 387);
            précedentBouton.Name = "précedentBouton";
            précedentBouton.Size = new Size(75, 23);
            précedentBouton.TabIndex = 1;
            précedentBouton.Text = "Précedent";
            précedentBouton.UseVisualStyleBackColor = true;
            précedentBouton.Click += précedentBouton_Click;
            // 
            // panelEtape1
            // 
            panelEtape1.Controls.Add(panelEtape2);
            panelEtape1.Location = new Point(89, 41);
            panelEtape1.Name = "panelEtape1";
            panelEtape1.Size = new Size(558, 304);
            panelEtape1.TabIndex = 2;
            // 
            // panelEtape2
            // 
            panelEtape2.Location = new Point(0, 0);
            panelEtape2.Name = "panelEtape2";
            panelEtape2.Size = new Size(558, 304);
            panelEtape2.TabIndex = 0;
            panelEtape2.Visible = false;
            // 
            // panelEtape3
            // 
            panelEtape3.Location = new Point(89, 41);
            panelEtape3.Name = "panelEtape3";
            panelEtape3.Size = new Size(558, 304);
            panelEtape3.TabIndex = 0;
            panelEtape3.Visible = false;
            // 
            // panelEtape4
            // 
            panelEtape4.Location = new Point(89, 41);
            panelEtape4.Name = "panelEtape4";
            panelEtape4.Size = new Size(558, 304);
            panelEtape4.TabIndex = 0;
            panelEtape4.Visible = false;
            // 
            // panelEtape5
            // 
            panelEtape5.Location = new Point(89, 41);
            panelEtape5.Name = "panelEtape5";
            panelEtape5.Size = new Size(558, 304);
            panelEtape5.TabIndex = 0;
            panelEtape5.Visible = false;
            // 
            // NewCharactereCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelEtape5);
            Controls.Add(panelEtape4);
            Controls.Add(panelEtape3);
            Controls.Add(panelEtape1);
            Controls.Add(précedentBouton);
            Controls.Add(suivantBouton);
            Name = "NewCharactereCreation";
            Text = "NewCharactereCreation";
            panelEtape1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button suivantBouton;
        private Button précedentBouton;
        private Panel panelEtape1;
        private Panel panelEtape2;
        private Panel panelEtape3;
        private Panel panelEtape4;
        private Panel panelEtape5;
    }
}