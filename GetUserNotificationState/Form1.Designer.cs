
namespace GetUserNotificationState
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnGetState = new System.Windows.Forms.Button();
            this.TxtBxState = new System.Windows.Forms.TextBox();
            this.BtnGetFeatureName = new System.Windows.Forms.Button();
            this.TxtBxFeatureName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnGetState
            // 
            this.BtnGetState.Location = new System.Drawing.Point(12, 41);
            this.BtnGetState.Name = "BtnGetState";
            this.BtnGetState.Size = new System.Drawing.Size(111, 23);
            this.BtnGetState.TabIndex = 2;
            this.BtnGetState.Text = "GetState";
            this.BtnGetState.UseVisualStyleBackColor = true;
            this.BtnGetState.Click += new System.EventHandler(this.BtnGetState_Click);
            // 
            // TxtBxState
            // 
            this.TxtBxState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBxState.Location = new System.Drawing.Point(129, 44);
            this.TxtBxState.Name = "TxtBxState";
            this.TxtBxState.ReadOnly = true;
            this.TxtBxState.Size = new System.Drawing.Size(136, 20);
            this.TxtBxState.TabIndex = 3;
            // 
            // BtnGetFeatureName
            // 
            this.BtnGetFeatureName.Location = new System.Drawing.Point(12, 12);
            this.BtnGetFeatureName.Name = "BtnGetFeatureName";
            this.BtnGetFeatureName.Size = new System.Drawing.Size(111, 23);
            this.BtnGetFeatureName.TabIndex = 0;
            this.BtnGetFeatureName.Text = "Get Feature Name";
            this.BtnGetFeatureName.UseVisualStyleBackColor = true;
            this.BtnGetFeatureName.Click += new System.EventHandler(this.BtnGetFeatureName_Click);
            // 
            // TxtBxFeatureName
            // 
            this.TxtBxFeatureName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBxFeatureName.Location = new System.Drawing.Point(129, 14);
            this.TxtBxFeatureName.Name = "TxtBxFeatureName";
            this.TxtBxFeatureName.ReadOnly = true;
            this.TxtBxFeatureName.Size = new System.Drawing.Size(136, 20);
            this.TxtBxFeatureName.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 82);
            this.Controls.Add(this.TxtBxFeatureName);
            this.Controls.Add(this.BtnGetFeatureName);
            this.Controls.Add(this.TxtBxState);
            this.Controls.Add(this.BtnGetState);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Concentration Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGetState;
        private System.Windows.Forms.TextBox TxtBxState;
        private System.Windows.Forms.Button BtnGetFeatureName;
        private System.Windows.Forms.TextBox TxtBxFeatureName;
    }
}

