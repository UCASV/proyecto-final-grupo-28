
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject.SqlServerContext;

namespace Finalproject
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtuser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("No se permiten campos vacíos", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                //se valida si el gestor a ingresar se encuentra en la base de datos
                var db = new VaccinationDBContext();
                var StaffList = db.staff
                    .OrderBy(s => s.Id)
                    .ToList();

                var result = StaffList.Where(
                        s => s.UserStaff.Equals(txtuser.Text) &&
                             s.PasswordStaff.Equals(txtPassword.Text) &&
                             s.IdType.Equals(1)
                    ).ToList();

                if (result.Count == 0)
                {
                    //El gestor a ingresar no existe en la base de datos
                    MessageBox.Show("Este usuario no existe o no tiene nivel de acceso suficiente", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var Date = DateTime.Now;

                    LoginInfo NewLogin = new LoginInfo();

                    NewLogin.IdCabin = 1;
                    NewLogin.IdStaff = txtuser.Text;
                    NewLogin.LoginDate = Date;
                    db.Add(NewLogin);
                    db.SaveChanges();

                    FrmPrincipal principal = new FrmPrincipal(txtuser.Text);
                    this.Hide();
                    principal.Show();
                }
            }
        }

        private void btn_Staff_Click(object sender, EventArgs e)
        {
            frm_NewStaff NewStaff = new frm_NewStaff();
            NewStaff.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
