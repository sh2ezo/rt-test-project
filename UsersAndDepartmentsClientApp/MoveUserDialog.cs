using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UsersAndDepartmentsModel;

namespace UsersAndDepartmentsClientApp
{
    public partial class MoveUserDialog : Form
    {
        public MoveUserDialog(IEnumerable<Department> departments)
        {
            InitializeComponent();

            foreach (var department in departments)
            {
                cmbDepartment.Items.Add(new DepartmentWrapper(department));
            }

            btnOk.Click += Ok;
        }

        public int? DepartmentId => (cmbDepartment.SelectedItem as DepartmentWrapper)?.Department.Id;

        private void Ok(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem == null)
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private sealed class DepartmentWrapper
        {
            public DepartmentWrapper(Department department)
            {
                Department = department ?? throw new ArgumentNullException(nameof(department));
            }

            public Department Department { get; }

            public override string ToString()
            {
                return Department.Title;
            }
        }
    }
}
