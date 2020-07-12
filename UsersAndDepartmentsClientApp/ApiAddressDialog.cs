using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsersAndDepartmentsClientApp
{
    public partial class ApiAddressDialog : Form
    {
        public ApiAddressDialog()
        {
            InitializeComponent();

            btnOk.Click += Ok;
        }

        public Uri ApiOriginUri { get; private set; }

        private void Ok(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(txtApiAddress.Text, UriKind.Absolute, out var uri))
            {
                MessageBox.Show(this, "Неверный формат адреса!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApiOriginUri = uri;
        }
    }
}
