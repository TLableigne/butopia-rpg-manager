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
            Competence = new Label();
            Indicateur = new Label();
            Difficulte = new Label();
            result = new Label();
            Lancer = new Button();
            Fermer = new Button();
            numUpDownNbEpreuve = new NumericUpDown();
            labelNumUpDown = new Label();
            Type = new Label();
            labelSanteMentale = new Label();
            ((System.ComponentModel.ISupportInitialize)numUpDownNbEpreuve).BeginInit();
            SuspendLayout();
            // 
            // Nom
            // 
            Nom.AutoSize = true;
            Nom.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Nom.Location = new Point(48, 142);
            Nom.Name = "Nom";
            Nom.Size = new Size(63, 32);
            Nom.TabIndex = 0;
            Nom.Text = "nom";
            // 
            // Competence
            // 
            Competence.AutoSize = true;
            Competence.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Competence.Location = new Point(48, 18);
            Competence.Name = "Competence";
            Competence.Size = new Size(94, 21);
            Competence.TabIndex = 1;
            Competence.Text = "compétence";
            // 
            // Indicateur
            // 
            Indicateur.AutoSize = true;
            Indicateur.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Indicateur.Location = new Point(48, 57);
            Indicateur.Name = "Indicateur";
            Indicateur.Size = new Size(79, 21);
            Indicateur.TabIndex = 2;
            Indicateur.Text = "indicateur";
            // 
            // Difficulte
            // 
            Difficulte.AutoSize = true;
            Difficulte.Location = new Point(48, 242);
            Difficulte.Name = "Difficulte";
            Difficulte.Size = new Size(0, 15);
            Difficulte.TabIndex = 4;
            // 
            // result
            // 
            result.BackColor = SystemColors.ControlLightLight;
            result.Location = new Point(360, 277);
            result.Name = "result";
            result.RightToLeft = RightToLeft.No;
            result.Size = new Size(376, 30);
            result.TabIndex = 5;
            // 
            // Lancer
            // 
            Lancer.Location = new Point(396, 126);
            Lancer.Name = "Lancer";
            Lancer.Size = new Size(301, 118);
            Lancer.TabIndex = 6;
            Lancer.Text = "lancer l'épreuve";
            Lancer.UseVisualStyleBackColor = true;
            Lancer.Click += Lancer_Click;
            // 
            // Fermer
            // 
            Fermer.DialogResult = DialogResult.Cancel;
            Fermer.Location = new Point(457, 335);
            Fermer.Name = "Fermer";
            Fermer.Size = new Size(168, 38);
            Fermer.TabIndex = 7;
            Fermer.Text = "Fermer";
            Fermer.UseVisualStyleBackColor = true;
            // 
            // numUpDownNbEpreuve
            // 
            numUpDownNbEpreuve.Location = new Point(646, 47);
            numUpDownNbEpreuve.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numUpDownNbEpreuve.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numUpDownNbEpreuve.Name = "numUpDownNbEpreuve";
            numUpDownNbEpreuve.Size = new Size(120, 23);
            numUpDownNbEpreuve.TabIndex = 8;
            numUpDownNbEpreuve.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNumUpDown
            // 
            labelNumUpDown.AutoSize = true;
            labelNumUpDown.Location = new Point(494, 49);
            labelNumUpDown.Name = "labelNumUpDown";
            labelNumUpDown.Size = new Size(129, 15);
            labelNumUpDown.TabIndex = 9;
            labelNumUpDown.Text = "Nombre d'executions : ";
            // 
            // Type
            // 
            Type.AutoSize = true;
            Type.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Type.Location = new Point(396, 78);
            Type.Name = "Type";
            Type.Size = new Size(86, 45);
            Type.TabIndex = 10;
            Type.Text = "type";
            // 
            // labelSanteMentale
            // 
            labelSanteMentale.AutoSize = true;
            labelSanteMentale.Location = new Point(390, 411);
            labelSanteMentale.Name = "labelSanteMentale";
            labelSanteMentale.Size = new Size(104, 15);
            labelSanteMentale.TabIndex = 11;
            labelSanteMentale.Text = "labelSanteMentale";
            // 
            // TrialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 450);
            Controls.Add(labelSanteMentale);
            Controls.Add(Type);
            Controls.Add(labelNumUpDown);
            Controls.Add(numUpDownNbEpreuve);
            Controls.Add(Fermer);
            Controls.Add(Lancer);
            Controls.Add(result);
            Controls.Add(Difficulte);
            Controls.Add(Indicateur);
            Controls.Add(Competence);
            Controls.Add(Nom);
            Name = "TrialForm";
            Text = "TrialForm";
            ((System.ComponentModel.ISupportInitialize)numUpDownNbEpreuve).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Nom;
        private Label Competence;
        private Label Indicateur;
        private Label Difficulte;
        private Label result;
        private Button Lancer;
        private Button Fermer;
        private NumericUpDown numUpDownNbEpreuve;
        private Label labelNumUpDown;
        private Label Type;
        private Label labelSanteMentale;
    }
}