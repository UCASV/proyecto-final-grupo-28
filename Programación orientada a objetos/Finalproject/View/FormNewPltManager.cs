using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finalproject.Services;
using Finalproject.SqlServerContext;

namespace Finalproject
{
    public partial class FormNewPltManager : Form
    {
        private newStaff NewStasff;


        public string user { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public FormNewPltManager(string user, string name, string email, string address)
        {
            InitializeComponent();
            NewStasff = new newStaff();
            this.user = user;
            this.name = name;
            this.email = email;
            this.address = address;
        }

        private void FormNewPltManager_Load(object sender, EventArgs e)
        {
            lbl_showuser.Text = user;
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            //se valida si el empleado ya se encuentra en la base de datos
            var db = new VaccinationDBContext();
            var StaffList = db.staff
                .OrderBy(u => u.Id)
                .ToList();

            var result = StaffList.Where(
                u => u.Id.Equals(user)
                ).ToList();

            //si el contador da 0 significa que el gestor no se encuentra en la base de datos
            if (result.Count == 0)
            {
                string password = txt_password.Text;
                int type = 1;
                staff NewStaff = new staff();

                NewStaff.Id = user;
                NewStaff.NameStaff = name;
                NewStaff.Email = email;
                NewStaff.PasswordStaff = password;
                NewStaff.UserStaff = user;
                NewStaff.AddressStaff = address;
                NewStaff.IdType = type;
                NewStasff.create(NewStaff);

                MessageBox.Show("Registrado correctamente", "Empleado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario ya existe", "ERROR",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txt_password.UseSystemPasswordChar == true)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

       
    }
}
