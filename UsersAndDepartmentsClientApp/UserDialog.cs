using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsersAndDepartmentsClientApp
{
    public partial class UserDialog : Form
    {
        public UserDialog()
        {
            InitializeComponent();

            btnOk.Click += Ok;
        }

        private void Ok(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show(this, "Пустое имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }
    }
}
