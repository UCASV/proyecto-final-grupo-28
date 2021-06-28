
namespace Finalproject.View
{
    partial class FrmAddInstitution
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
            this.btnAddInst = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInstType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAddInst
            // 
            this.btnAddInst.Location = new System.Drawing.Point(221, 145);
            this.btnAddInst.Name = "btnAddInst";
            this.btnAddInst.Size = new System.Drawing.Size(125, 28);
            this.btnAddInst.TabIndex = 0;
            this.btnAddInst.Text = "Agregar institución";
            this.btnAddInst.UseVisualStyleBackColor = true;
            this.btnAddInst.Click += new System.EventHandler(this.btnAddInst_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de la institución:";
            // 
            // txtInst
            // 
            this.txtInst.Location = new System.Drawing.Point(180, 52);
            this.txtInst.Name = "txtInst";
            this.txtInst.Size = new System.Drawing.Size(166, 23);
            this.txtInst.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo de institución:";
            // 
            // cmbInstType
            // 
            this.cmbInstType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstType.FormattingEnabled = true;
            this.cmbInstType.Location = new System.Drawing.Point(180, 97);
            this.cmbInstType.Name = "cmbInstType";
            this.cmbInstType.Size = new System.Drawing.Size(166, 23);
            this.cmbInstType.TabIndex = 4;
            // 
            // FrmAddInstitution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 185);
            this.Controls.Add(this.cmbInstType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddInst);
            this.Name = "FrmAddInstitution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddInstitution";
            this.Load += new System.EventHandler(this.FrmAddInstitution_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddInst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInstType;
    }
}