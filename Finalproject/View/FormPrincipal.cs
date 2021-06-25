using Finalproject.SqlServerContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Finalproject.View;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using Finalproject.SqlServerContext;

namespace Finalproject
{
    public partial class FrmPrincipal : Form
    {
        private bool stateInst = false;
        private bool stateDis = false;
        private string expressionDUI = "^0[0-9]{7}-[0-9]{1}$";
        private string expressionPhone = "^[7|6|2][0-9]{7}$";
        private string emailExpression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

        //Variable que almacenara el usuario que inicio sesion
        public string user { get; set; }

        public FrmPrincipal(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtDui.Text == "" || txtAge.Text == "" || txtAddress.Text == "" || txtName.Text == "" ||
               txtPhone.Text == "")
            {
                MessageBox.Show("No se permiten campos vacíos", "ERROR", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }
            else
            {
                if (txtEmail.Text != "")
                {
                    if (Regex.IsMatch(txtEmail.Text, emailExpression))
                    {
                        if (Regex.IsMatch(txtDui.Text, expressionDUI) && Regex.IsMatch(txtPhone.Text, expressionPhone))
                            AddingCitizen();
                        else
                        {
                            MessageBox.Show("DUI o teléfono inválidos", "ERROR", MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email inválido", "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (Regex.IsMatch(txtDui.Text, expressionDUI) && Regex.IsMatch(txtPhone.Text, expressionPhone))
                        AddingCitizen();
                    else
                    {
                        MessageBox.Show("DUI o teléfono inválidos", "ERROR", MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void chkInstQuestion_CheckedChanged(object sender, EventArgs e)
        {
            var db = new VaccinationDBContext();

            if (!stateInst)
            {
                txtIdentifier.Enabled = true;
                cmbInstitution.Enabled = true;
                btnAddNewInst.Enabled = true;
                stateInst = true;

                cmbInstitution.DataSource = db.Institutions.ToList();
                cmbInstitution.DisplayMember = "Institution1";
                cmbInstitution.ValueMember = "Id";
            }
            else
            {
                txtIdentifier.Enabled = false;
                cmbInstitution.Enabled = false;
                btnAddNewInst.Enabled = false;
                stateInst = false;
            }

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            txtIdentifier.Enabled = false;
            cmbInstitution.Enabled = false;
            txtDisease.Enabled = false;
            cmbDisType.Enabled = false;
            button1.Enabled = false;
            btnAddNewInst.Enabled = false;

            this.Activated += (s, evt) => { UpdateCMB(); };

        }

        private void chkDiseaseAsk_CheckedChanged(object sender, EventArgs e)
        {
            var db = new VaccinationDBContext();

            if (!stateDis)
            {
                txtDisease.Enabled = true;
                cmbDisType.Enabled = true;
                stateDis = true;
                button1.Enabled = true;

                cmbDisType.DataSource = db.DiseaseTypes.ToList();
                cmbDisType.DisplayMember = "DiseaseType1";
                cmbDisType.ValueMember = "Id";
            }
            else
            {
                txtDisease.Enabled = false;
                cmbDisType.Enabled = false;
                stateDis = false;
                button1.Enabled = false;

            }
        }

        private void btnAddNewInst_Click(object sender, EventArgs e)
        {
            FrmAddInstitution formAdd = new FrmAddInstitution();
            formAdd.Show();
        }

        private void UpdateCMB()
        {
            var db = new VaccinationDBContext();
            cmbInstitution.DataSource = null;
            cmbInstitution.DataSource = db.Institutions.ToList();
            cmbInstitution.DisplayMember = "Institution1";
            cmbInstitution.ValueMember = "Id";
        }

        private void Clearing_Text()
        {
            txtAddress.Clear();
            txtAge.Clear();
            txtDisease.Clear();
            txtDui.Clear();
            txtEmail.Clear();
            txtIdentifier.Clear();
            txtName.Clear();
            txtPhone.Clear();
            chkDiseaseAsk.Checked = false;
            chkInstQuestion.Checked = false;
            dgvDisease.Rows.Clear();
        }

        private void AddingCitizen()
        {
            var db = new VaccinationDBContext();

            bool priority = false;
            Citizen newCitizen = new Citizen();
            List<ChronicDisease> diseases = new List<ChronicDisease>();
            int idType = 0;


            if (chkInstQuestion.Checked)
            {
                var institutions = db.Institutions
                    .OrderBy(i => i.Id)
                    .ToList();

                var resultInstitution = institutions.Where(
                    i => i.Id.Equals(cmbInstitution.SelectedIndex + 1)
                 ).ToList();

                idType = resultInstitution[0].IdType;
            }


            var citizens = db.Citizens.ToList();
            var resultCitizen = citizens.Where(
                    c => (c.Dui.Equals(txtDui.Text) ||
                        c.Phone.Equals(txtPhone.Text) ||
                        c.Email.Equals(txtEmail.Text) ||
                        c.Identifier.Equals(txtIdentifier.Text))
                        &&
                        (c.Email.Equals("None") ||
                        c.Identifier.Equals("None"))
                ).ToList();

            if (resultCitizen.Count == 0)
            {
                bool stateType = false;
                for (int i = 0; i < dgvDisease.RowCount; i++)
                {
                    if (Int32.Parse(dgvDisease.Rows[i].Cells[2].Value.ToString()) == 2 ||
                        Int32.Parse(dgvDisease.Rows[i].Cells[2].Value.ToString()) == 3)
                        stateType = true;
                }

                if (Int32.Parse(txtAge.Text) >= 60)
                    priority = true;
                else if (idType == 1 || idType == 3 || idType == 4)
                    priority = true;
                else if (Int32.Parse(txtAge.Text) >= 18 && stateType)
                    priority = true;

                if (priority)
                {
                    newCitizen.Dui = txtDui.Text;
                    newCitizen.Age = Int32.Parse(txtAge.Text);
                    newCitizen.CitizenName = txtName.Text;
                    newCitizen.AddressCitizen = txtAddress.Text;
                    newCitizen.Phone = txtPhone.Text;
                    if (txtEmail.Text != "")
                        newCitizen.Email = txtEmail.Text;

                    //Si está marcado solo checkbox de institución
                    if (chkInstQuestion.Checked && !chkDiseaseAsk.Checked)
                    {
                        if (txtIdentifier.Text == "")
                        {
                            MessageBox.Show("Identificador de institución vacío", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            newCitizen.Identifier = txtIdentifier.Text;
                            newCitizen.IdInstitution = cmbInstitution.SelectedIndex + 1;
                            db.Add(newCitizen);
                            db.SaveChanges();
                            Appointment();
                            MessageBox.Show("Cita guardada", "Proceso de Cita", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                            Vaccination();
                            Clearing_Text();
                        }
                    }
                    //Si está marcado solo checkbox de Enfermedad
                    else if (!chkInstQuestion.Checked && chkDiseaseAsk.Checked)
                    {
                        if (txtDisease.Text == "")
                        {
                            MessageBox.Show("Enfermedad vacía", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            db.Add(newCitizen);
                            db.SaveChanges();
                            for (int i = 0; i < Int32.Parse(dgvDisease.RowCount.ToString()); i++)
                            {
                                diseases.Add(new ChronicDisease(dgvDisease.Rows[i].Cells[0].Value.ToString(), txtDui.Text, Int32.Parse(dgvDisease.Rows[i].Cells[2].Value.ToString())));
                                db.Add(diseases[i]);
                                db.SaveChanges();
                            }
                            Appointment();
                            MessageBox.Show("Cita guardada", "Proceso de Cita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Vaccination();
                            Clearing_Text();
                        }
                    }
                    // Si están marcados ambos checkbox, institución y enfermedad
                    else if (chkInstQuestion.Checked && chkDiseaseAsk.Checked)
                    {
                        if (txtDisease.Text == "" || txtIdentifier.Text == "")
                        {
                            MessageBox.Show("Nombre de Institución o enfermedad vacía", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            newCitizen.Identifier = txtIdentifier.Text;
                            newCitizen.IdInstitution = cmbInstitution.SelectedIndex + 1;
                            db.Add(newCitizen);
                            db.SaveChanges();

                            for (int i = 0; i < Int32.Parse(dgvDisease.RowCount.ToString()); i++)
                            {
                                diseases.Add(new ChronicDisease(dgvDisease.Rows[i].Cells[0].Value.ToString(), txtDui.Text, Int32.Parse(dgvDisease.Rows[i].Cells[2].Value.ToString())));
                                db.Add(diseases[i]);
                                db.SaveChanges();
                            }
                            Appointment();
                            MessageBox.Show("Cita guardada", "Proceso de Cita", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Vaccination();
                            Clearing_Text();
                        }
                    }
                    // Si ningún checkbox está marcado
                    else
                    {
                        db.Add(newCitizen);
                        db.SaveChanges();

                        Appointment();
                        MessageBox.Show("Cita guardada", "Proceso de Cita", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Vaccination();
                        Clearing_Text();
                    }


                }
                else
                {
                    MessageBox.Show("No pertenece a ningún grupo de prioridad", "´Registro de Vacunación", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("DUI, teléfono, email o identificador ya existen ", "´Registro de Vacunación", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

        }


        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new VaccinationDBContext();
            var types = db.DiseaseTypes.ToList();


            if (chkDiseaseAsk.Checked)
            {
                if (txtDisease.Text == "")
                {
                    MessageBox.Show("Enfermedad vacía", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    var result = types.Where(r => r.Id.Equals(cmbDisType.SelectedIndex + 1)).ToList();

                    dgvDisease.Rows.Add(txtDisease.Text, result[0].DiseaseType1,
                        cmbDisType.SelectedIndex + 1);

                    MessageBox.Show("Enfermedad crónica añadida", "Proceso de Cita", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }


        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            //Genera el documento PDF
            var pdif = txtDui.Text;


            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream($"{pdif}.pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("Cita COVID-19");
            doc.Add(title);

            doc.Add(new Paragraph(lbltxtx1.Text));
            doc.Add(new Paragraph(lbltxt2.Text));
            doc.Add(new Paragraph(lbltxt3.Text + lblfeha1.Text + lbltxt4.Text + lblhora2.Text + lbltxt5.Text));
            doc.Add(new Paragraph(lbltxt6.Text + lblplacevacun.Text));
            doc.Add(new Paragraph(lbltxt7.Text));
            doc.Add(new Paragraph(lbltxt8.Text));
            doc.Add(new Paragraph(lbltxt9.Text));

            doc.Close();
            
        }

        //Funcion que mostrara los datos del ciudadano recien ingresado
        private void Vaccination()
        {
            string dui = txtDui.Text;
            string name = txtName.Text;

            lblimpdui.Text = dui;
            lblimpname.Text = name;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //se valida si el ciudadano existe ya se encuentra en la base de datos
            var db = new VaccinationDBContext();
            var CitizenList = db.Citizens
                .OrderBy(u => u.Dui)
                .ToList();

            var result = CitizenList.Where(
                u => u.Dui.Equals(txt_Dui.Text)
                ).ToList();

            //si el contador da 0 significa que el ciudadano no se encuentra en la base de datos
            if (result.Count == 0)
            {
                MessageBox.Show("El ciudadano no ha realizado ninguna cita", "ERROR",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Citizen Searchcitizen = db.Citizens.Find(txt_Dui.Text);


                Appointment SearchAppointment = db.Appointments.FirstOrDefault(x=> x.DuiCitizen == txt_Dui.Text);
                
                //Mostrando los datos de la cita con el DUI insertado
                Citizen citizen = new Citizen();
                Appointment appointment = new Appointment();

                citizen.CitizenName = Searchcitizen.CitizenName;
                appointment.FirstDoseDate = SearchAppointment.FirstDoseDate;
                appointment.Place = SearchAppointment.Place;

                lbl_showname.Text = citizen.CitizenName;
                lbl_showDate.Text = appointment.FirstDoseDate.ToString("yyyy/MM/dd hh:mm");
                lbl_showPlace.Text = appointment.Place;
                
            }
        }

        //Funcion que generara una fecha en la que el ciudadano podra asistir
        private DateTime RandomDate()
        {
            Random random = new Random();

            DateTime start = DateTime.Today;
            int range = (DateTime.Today.AddMonths(3) - start).Days;
            return start.AddDays(random.Next(range));
        }

        //Funcion que generara una hora a la cual el ciudadano podra asistir
        private DateTime RandomHour()
        {
            DateTime start = DateTime.Today.AddHours(7);
            Random rnd = new Random();
            DateTime value = start.AddMinutes(rnd.Next(241));

            return value;
        }

        //Funcion que generara un lugar de vacunacion para el ciudadano
        private string RandomPlace()
        {
            Random random = new Random();

            string[] Place = { " Megacentro Hospital", "Hospital El Salvador", "Gran Via"};

            int Pindex = random.Next(Place.Length);

            return Place[Pindex];
        }

        //Funcion que guardara la cita en la base de datos
        private void RegisterAppointment(DateTime date, string place)
        {
            var db = new VaccinationDBContext();

            Appointment appointment = new Appointment();
            appointment.Place = place;
            appointment.FirstDoseDate = date;
            appointment.IdStaff = user;
            appointment.DuiCitizen = txtDui.Text;

            db.Add(appointment);
            db.SaveChanges();
        }

        //Funcion que mostrara los datos de la cita que genero la aplicacion
        private void Appointment ()
        {
            var date = RandomDate();
            var hour = RandomHour();
            var place = RandomPlace();

            lblfeha1.Text = date.ToString("yyyy/MM/dd");
            lblhora2.Text = hour.ToString("hh:mm");
            lblplacevacun.Text = place;

            DateTime TotalDate = new DateTime(date.Year,date.Month,date.Day,hour.Hour,hour.Minute,hour.Second);

            RegisterAppointment(TotalDate, place);
        }
    }
}
