using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsersAndDepartmentsClientApp
{
    public partial class DepartmentDialog : Form
    {
        public DepartmentDialog()
        {
            InitializeComponent();

            btnOk.Click += Ok;
        }

        public string Title
        {
            get => txtTitle.Text;
            set => txtTitle.Text = value;
        }

        private void Ok(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show(this, "Пустое название!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
