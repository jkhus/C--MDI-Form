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
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }
        CreateForm objCreateForm = null;
        ViewForm objViewForm = null;
        private void CreateToolStripMenu_click(object sender, EventArgs e)
        {
            if (objCreateForm == null)
            {
                objCreateForm = new CreateForm();
                objCreateForm.FormClosed += objCreateForm_FormClosed;
                if (objViewForm != null) objViewForm.Close();
                objCreateForm.Show();
            }
            else
            {
                if (objViewForm != null) objViewForm.Close();
                objCreateForm.Activate();
            }

        }

        private void objCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objCreateForm = null;
        }

        private void Update_click(object sender, EventArgs e)
        {
            if (objViewForm == null)
            {
                objViewForm = new ViewForm();
                objViewForm.FormClosed += objViewForm_FormClosed;
                if (objCreateForm != null) objCreateForm.Close();
                objViewForm.Show();
            }
            else
            {
                if (objCreateForm != null) objCreateForm.Close();
                objViewForm.Activate();

            }
        }

        private void objViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objViewForm = null;
        }
    }
}
