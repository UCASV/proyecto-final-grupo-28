
namespace Finalproject
{
    partial class FormNewPltManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewPltManager));
            this.lbl_ManagerUser = new System.Windows.Forms.Label();
            this.lbl_ManagerPass = new System.Windows.Forms.Label();
            this.lbl_showuser = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ManagerUser
            // 
            this.lbl_ManagerUser.AutoSize = true;
            this.lbl_ManagerUser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ManagerUser.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ManagerUser.Location = new System.Drawing.Point(42, 85);
            this.lbl_ManagerUser.Name = "lbl_ManagerUser";
            this.lbl_ManagerUser.Size = new System.Drawing.Size(83, 22);
            this.lbl_ManagerUser.TabIndex = 0;
            this.lbl_ManagerUser.Text = "Usuario:";
            // 
            // lbl_ManagerPass
            // 
            this.lbl_ManagerPass.AutoSize = true;
            this.lbl_ManagerPass.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ManagerPass.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_ManagerPass.Location = new System.Drawing.Point(31, 255);
            this.lbl_ManagerPass.Name = "lbl_ManagerPass";
            this.lbl_ManagerPass.Size = new System.Drawing.Size(117, 22);
            this.lbl_ManagerPass.TabIndex = 1;
            this.lbl_ManagerPass.Text = "Contraseña:";
            // 
            // lbl_showuser
            // 
            this.lbl_showuser.AutoSize = true;
            this.lbl_showuser.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_showuser.Location = new System.Drawing.Point(134, 85);
            this.lbl_showuser.Name = "lbl_showuser";
            this.lbl_showuser.Size = new System.Drawing.Size(0, 22);
            this.lbl_showuser.TabIndex = 2;
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Rockwell", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txt_password.Location = new System.Drawing.Point(154, 254);
            this.txt_password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(114, 29);
            this.txt_password.TabIndex = 3;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.White;
            this.btn_create.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_create.FlatAppearance.BorderSize = 3;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Location = new System.Drawing.Point(134, 330);
            this.btn_create.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(115, 65);
            this.btn_create.TabIndex = 4;
            this.btn_create.Text = "Registrar";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(294, 252);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormNewPltManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Finalproject.Properties.Resources._105400775_104099134694519_4920235969454692092_n3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(394, 408);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_showuser);
            this.Controls.Add(this.lbl_ManagerPass);
            this.Controls.Add(this.lbl_ManagerUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormNewPltManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIng Info";
            this.Load += new System.EventHandler(this.FormNewPltManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ManagerUser;
        private System.Windows.Forms.Label lbl_ManagerPass;
        private System.Windows.Forms.Label lbl_showuser;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}