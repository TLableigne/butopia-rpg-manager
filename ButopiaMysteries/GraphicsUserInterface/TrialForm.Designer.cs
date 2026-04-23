namespace ButopiaMysteries.Logic
{
    partial class TrialForm
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
            Nom = new Label();
            Competance = new Label();
            Indicateur = new Label();
            Difficulte = new Label();
            result = new Label();
            Lancer = new Button();
            Fermer = new Button();
            SuspendLayout();
            // 
            // Nom
            // 
            Nom.AutoSize = true;
            Nom.Location = new Point(48, 75);
            Nom.Name = "Nom";
            Nom.Size = new Size(32, 15);
            Nom.TabIndex = 0;
            Nom.Text = "nom";
            // 
            // Competance
            // 
            Competance.AutoSize = true;
            Competance.Location = new Point(48, 154);
            Competance.Name = "Competance";
            Competance.Size = new Size(73, 15);
            Competance.TabIndex = 1;
            Competance.Text = "compétance";
            // 
            // Indicateur
            // 
            Indicateur.AutoSize = true;
            Indicateur.Location = new Point(48, 247);
            Indicateur.Name = "Indicateur";
            Indicateur.Size = new Size(60, 15);
            Indicateur.TabIndex = 2;
            Indicateur.Text = "indicateur";
            // 
            // Difficulte
            // 
            Difficulte.AutoSize = true;
            Difficulte.Location = new Point(48, 356);
            Difficulte.Name = "Difficulte";
            Difficulte.Size = new Size(94, 15);
            Difficulte.TabIndex = 4;
            Difficulte.Text = "difficulté choisie";
            // 
            // result
            // 
            result.Location = new Point(306, 247);
            result.Name = "result";
            result.RightToLeft = RightToLeft.No;
            result.Size = new Size(376, 30);
            result.TabIndex = 5;
            // 
            // Lancer
            // 
            Lancer.Location = new Point(399, 144);
            Lancer.Name = "Lancer";
            Lancer.Size = new Size(154, 35);
            Lancer.TabIndex = 6;
            Lancer.Text = "lancer l'épreuve";
            Lancer.UseVisualStyleBackColor = true;
            Lancer.Click += Lancer_Click;
            // 
            // Fermer
            // 
            Fermer.DialogResult = DialogResult.Cancel;
            Fermer.Location = new Point(669, 379);
            Fermer.Name = "Fermer";
            Fermer.Size = new Size(75, 23);
            Fermer.TabIndex = 7;
            Fermer.Text = "Fermer";
            Fermer.UseVisualStyleBackColor = true;
            // 
            // TrialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Fermer);
            Controls.Add(Lancer);
            Controls.Add(result);
            Controls.Add(Difficulte);
            Controls.Add(Indicateur);
            Controls.Add(Competance);
            Controls.Add(Nom);
            Name = "TrialForm";
            Text = "TrialForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nom;
        private Label Competance;
        private Label Indicateur;
        private Label Difficulte;
        private Label result;
        private Button Lancer;
        private Button Fermer;
    }
}