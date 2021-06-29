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
using System.Text.RegularExpressions;
using Finalproject.Services;

namespace Finalproject
{
    public partial class frm_NewStaff : Form
    {
        private newStaff staffservices;
        public frm_NewStaff()
        {
            InitializeComponent();
            staffservices = new newStaff();
        }

        private void btn_CreateStaff_Click(object sender, EventArgs e)
        {
            if (txt_Staff_id.Text == "" || txt_Staff_Address.Text == "" || txt_Staff_Email.Text == "" ||
                txt_Staff_name.Text == "")
            {
                MessageBox.Show("No se permiten campos vacíos", "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string emailExpression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (!Regex.IsMatch(txt_Staff_Email.Text, emailExpression))
                {
                    MessageBox.Show("Ingrese un email válido", "ERROR", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
                else
                {
                    int n = cmb_StaffType.SelectedIndex;
                    int index = n + 1;
                    if (index == 1)
                    {
                        FormNewPltManager newManager = new FormNewPltManager(txt_Staff_id.Text, txt_Staff_name.Text,
                            txt_Staff_Email.Text, txt_Staff_Address.Text);
                        newManager.Show();
                    }
                    else
                    {
                        var db = new VaccinationDBContext();

                        //se valida si el empleado ya se encuentra en la base de datos
                        var StaffList = db.staff
                            .OrderBy(u => u.Id)
                            .ToList();

                        var result = StaffList.Where(
                            u => u.Id.Equals(txt_Staff_id)
                            ).ToList();

                        //si el contador da 0 significa que el empleado no se encuentra en la base de datos
                        if (result.Count == 0)
                        {
                            string id = txt_Staff_id.Text;
                            string name = txt_Staff_name.Text;
                            string email = txt_Staff_Email.Text;
                            string address = txt_Staff_Address.Text;
                            int type = cmb_StaffType.SelectedIndex;

                            staff NewStaff = new staff();

                            NewStaff.Id = id;
                            NewStaff.NameStaff = name;
                            NewStaff.Email = email;
                            NewStaff.AddressStaff = address;
                            NewStaff.IdType = type + 1;
                            try
                            {
                                staffservices.create(NewStaff);

                                MessageBox.Show("Registrado correctamente", "REGISTRO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch
                            {
                                MessageBox.Show("El usuario ya existe", "ERROR",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        //Si da diferente de 0 significa que el gestor ya se encuentra en la base de datos
                        else
                        {
                            MessageBox.Show("El usuario ya existe", "ERROR",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frm_NewStaff_Load(object sender, EventArgs e)
        {
            var db = new VaccinationDBContext();
            cmb_StaffType.DataSource = db.StaffTypes.ToList();
            cmb_StaffType.DisplayMember = "StaffType1";
            cmb_StaffType.ValueMember = "Id";

            tlpId.SetToolTip(cmb_StaffType, "Al ser un gestor se redireccionará a una ventana para elegir su contraseña. Su usuario será su identificador ");
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
