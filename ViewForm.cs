using LabMDISample.DB_Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabMDISample
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            loadDataToGrid();
        }
        private void loadDataToGrid()
        {
            dataGridView1.DataSource = ClsDbOperation.getStudentDetails();
            this.dataGridView1.Columns["slno"].Visible = false;
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int slno = Convert.ToInt32(row.Cells[0].Value);
            string name = (row.Cells[2].Value).ToString();
            var confirmResult = MessageBox.Show("Are you sure to delete " + name + "'s record.?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int result = ClsDbOperation.deleteStudentDetails(slno);
                if (result == 1)
                {
                    MessageBox.Show(name + "'s record deleted", "Information");
                    loadDataToGrid();
                }

            }
            else
            {
                // If 'No', do something here.
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            int slno = Convert.ToInt32(row.Cells[0].Value);
            CreateForm objectCreateForm = new CreateForm(slno);
            objectCreateForm.Show();
            this.Close();
        }
    }
}
