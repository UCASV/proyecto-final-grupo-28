using Finalproject.SqlServerContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalproject.View
{
    public partial class FrmAddInstitution : Form
    {
        public FrmAddInstitution()
        {
            InitializeComponent();
        }

        private void FrmAddInstitution_Load(object sender, EventArgs e)
        {
            var db = new VaccinationDBContext();
            cmbInstType.DataSource = db.InstitutionTypes.ToList();
            cmbInstType.DisplayMember = "InstType";
            cmbInstType.ValueMember = "Id";
        }

        private void btnAddInst_Click(object sender, EventArgs e)
        {
            if (txtInst.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }
            else
            {
                var db = new VaccinationDBContext();

                Institution inst = new Institution();
                inst.Institution1 = txtInst.Text;
                inst.IdType = cmbInstType.SelectedIndex + 1;
                db.Add(inst);
                db.SaveChanges();

                MessageBox.Show("Institución añadida", "Instituciones", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

    }
}
