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
    public partial class CreateForm : Form
    {
        int slnoForUpdateFunction = 0;
        
        public CreateForm()
        {
            InitializeComponent();
            doLoadingWork();
        }
        public CreateForm(int slno)
        {
            InitializeComponent();
            doLoadingWork();
            button1.Visible = false;
            loadControlsWithDataToUpdate(slno);
            button2.Visible = true;
            slnoForUpdateFunction = slno;

        }
        public void doLoadingWork()
        {
            comboBox1.DataSource = ClsDbOperation.getDegreeDetails();
            comboBox1.DisplayMember = "DEGREENAME";
            comboBox1.ValueMember = "DEGREEID";
            radioButton2.Checked = true;
        }
        public void loadControlsWithDataToUpdate(int slno)
        {
            DataTable dt = new DataTable();
            dt = ClsDbOperation.getStudentDetails();
            DataRow[] dr = dt.Select("Slno = " + slno);
            foreach (DataRow row in dr)
            {
                textBox1.Text = row["USN"].ToString();
                textBox2.Text = row["Name"].ToString();
                textBox3.Text = row["CollegeName"].ToString();
                string ddlValue = Convert.ToString(row["Degree"]);
                int id;
                if (ddlValue.Equals("BCA"))
                    id = 1;
                else if (ddlValue.Equals("BSC(CS)"))
                    id = 2;
                else if (ddlValue.Equals("BE(CS)"))
                    id = 3;
                else
                    id = 0;
                comboBox1.SelectedValue = id;
                string rbtValue = row["Gender"].ToString();
                if (rbtValue.Equals("Male"))
                    radioButton1.Checked = true;
                else if (rbtValue.Equals("Female"))
                    radioButton2.Checked = true;
                else if (rbtValue.Equals("Other"))
                    radioButton3.Checked = true;
                else
                    radioButton2.Checked = true;
                string vacinated = row["ISCVACINATED"].ToString();
                if (vacinated.Equals("Yes"))
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;
            }
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            int rbtValue = 0;

            try
            {


                if (validate())
                {

                    ClsStudent ObjectclsStudent = new ClsStudent();
                    ObjectclsStudent.usn = textBox1.Text;
                    ObjectclsStudent.name = textBox2.Text;
                    ObjectclsStudent.collegeName = textBox3.Text;
                    ObjectclsStudent.degree = Convert.ToInt32(comboBox1.SelectedValue);
                    if (radioButton1.Checked)
                        rbtValue = 1;
                    else if (radioButton2.Checked)
                        rbtValue = 2;
                    else if (radioButton3.Checked)
                        rbtValue = 3;
                    ObjectclsStudent.gender = rbtValue;
                    ObjectclsStudent.isCovidVacinated = (checkBox1.Checked ? 1 : 0);
                    result = ClsDbOperation.insertStudentDetails(ObjectclsStudent);

                }
            }
            catch (Exception exec)
            {
                {
                    MessageBox.Show(exec.ToString(), "Alert");
                }
            }
            finally
            {
                if (result == 1)
                {
                    MessageBox.Show("Data inserted successfully", "Information");
                }
            }
            
        }
        private bool validate()
        {
            bool isValidated = true;
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Enter USN", "Alert");
                isValidated = false;
            }
            else if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Enter name", "Alert");
                isValidated = false;

            }
            else if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Enter college Name and address", "Alert");
                isValidated = false;
            }
            else if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                MessageBox.Show("Select Degree", "Alert");
                isValidated = false;
            }

            return isValidated;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int result = 0;
            int rbtValue = 0;

            try
            {
                if (validate())
                {

                    ClsStudent ObjectclsStudent = new ClsStudent();
                    ObjectclsStudent.slno = slnoForUpdateFunction;
                    ObjectclsStudent.usn = textBox1.Text;
                    ObjectclsStudent.name = textBox2.Text;
                    ObjectclsStudent.collegeName = textBox3.Text;
                    ObjectclsStudent.degree = Convert.ToInt32(comboBox1.SelectedValue);
                    if (radioButton1.Checked)
                        rbtValue = 1;
                    else if (radioButton2.Checked)
                        rbtValue = 2;
                    else if (radioButton3.Checked)
                        rbtValue = 3;
                    ObjectclsStudent.gender = rbtValue;
                    ObjectclsStudent.isCovidVacinated = (checkBox1.Checked ? 1 : 0);
                    result = ClsDbOperation.updateStudentDetails(ObjectclsStudent);

                }
            }
            catch (Exception exec)
            {
                {
                    MessageBox.Show(exec.ToString(), "Alert");
                }
            }
            finally
            {
                if (result == 1)
                {
                    MessageBox.Show("Data updated successfully", "Information");
                }
            }
        }


    }
}
