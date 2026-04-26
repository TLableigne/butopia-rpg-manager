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
            labelNom = new Label();
            textBoxName = new TextBox();
            labelPlan = new Label();
            labelSphere = new Label();
            comboBoxPlan = new ComboBox();
            comboBoxSphere = new ComboBox();
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
            panelEtape1.Controls.Add(labelNom);
            panelEtape1.Controls.Add(labelPlan);
            panelEtape1.Controls.Add(textBoxName);
            panelEtape1.Controls.Add(labelSphere);
            panelEtape1.Controls.Add(comboBoxPlan);
            panelEtape1.Controls.Add(comboBoxSphere);
            panelEtape1.Location = new Point(89, 41);
            panelEtape1.Name = "panelEtape1";
            panelEtape1.Size = new Size(558, 304);
            panelEtape1.TabIndex = 2;
            // 
            // panelEtape2
            // 
            panelEtape2.Location = new Point(89, 41);
            panelEtape2.Name = "panelEtape2";
            panelEtape2.Size = new Size(558, 304);
            panelEtape2.TabIndex = 0;
            panelEtape2.Visible = false;
            // 
            // labelNom
            // 
            labelNom.AutoSize = true;
            labelNom.Location = new Point(227, 40);
            labelNom.Name = "labelNom";
            labelNom.Size = new Size(96, 15);
            labelNom.TabIndex = 0;
            labelNom.Text = "Entrer votre nom";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(227, 82);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 1;
            // 
            // labelPlan
            // 
            labelPlan.AutoSize = true;
            labelPlan.Location = new Point(29, 40);
            labelPlan.Name = "labelPlan";
            labelPlan.Size = new Size(122, 15);
            labelPlan.TabIndex = 2;
            labelPlan.Text = "Choisisser votre plan :";
            // 
            // labelSphere
            // 
            labelSphere.AutoSize = true;
            labelSphere.Location = new Point(394, 40);
            labelSphere.Name = "labelSphere";
            labelSphere.Size = new Size(134, 15);
            labelSphere.TabIndex = 3;
            labelSphere.Text = "Choisisser votre sphere :";
            // 
            // comboBoxPlan
            // 
            comboBoxPlan.FormattingEnabled = true;
            comboBoxPlan.Location = new Point(29, 82);
            comboBoxPlan.Name = "comboBoxPlan";
            comboBoxPlan.Size = new Size(121, 23);
            comboBoxPlan.TabIndex = 4;
            // 
            // comboBoxSphere
            // 
            comboBoxSphere.FormattingEnabled = true;
            comboBoxSphere.Location = new Point(394, 82);
            comboBoxSphere.Name = "comboBoxSphere";
            comboBoxSphere.Size = new Size(121, 23);
            comboBoxSphere.TabIndex = 5;
            // 
            // NewCharactereCreation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelEtape2);
            Controls.Add(panelEtape1);
            Controls.Add(précedentBouton);
            Controls.Add(suivantBouton);
            Name = "NewCharactereCreation";
            Text = "NewCharactereCreation";
            panelEtape1.ResumeLayout(false);
            panelEtape1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button suivantBouton;
        private Button précedentBouton;
        private Panel panelEtape1;
        private Panel panelEtape2;
        private Label labelSphere;
        private Label labelPlan;
        private TextBox textBoxName;
        private Label labelNom;
        private ComboBox comboBoxPlan;
        private ComboBox comboBoxSphere;
    }
}