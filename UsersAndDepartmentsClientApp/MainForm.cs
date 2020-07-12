using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using UsersAndDepartmentsModel;

namespace UsersAndDepartmentsClientApp
{
    public partial class MainForm : Form
    {
        private HttpClient _httpClient;
        private RestClient _restClient;
        private Dictionary<int, Department> _departments;

        public MainForm()
        {
            InitializeComponent();

            btnReconnect.Click += Reconnect;
            Shown += Reconnect;
            btnAddDepartment.Click += AddDepartment;
            btnDeleteDepartment.Click += DeleteDepartment;
            btnEditDepartment.Click += EditDepartment;
            lstDepartments.ItemSelectionChanged += ShowDepartmentUsers;
            btnAddUser.Click += AddUser;
            btnMoveUser.Click += MoveUser;
        }

        private async void MoveUser(object sender, EventArgs e)
        {
            try
            {
                EnableUsers(false);

                if (!TryGetDepartmentId(out int departmentId))
                {
                    return;
                }

                if (!TryGetUserId(out int userId))
                {
                    return;
                }

                if (_departments == null || _departments.Count == 0)
                {
                    return;
                }

                var dialog = new MoveUserDialog(_departments.Values);

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var newDepartmentId = dialog.DepartmentId;

                if (!newDepartmentId.HasValue)
                {
                    return;
                }

                if (newDepartmentId.Value == departmentId)
                {
                    return;
                }

                await _restClient.MoveUserAsync(userId, newDepartmentId.Value);

                lstUsers.Items.RemoveByKey(userId.ToString());
            }
            finally
            {
                EnableUsers(true);
            }
        }

        private async void AddUser(object sender, EventArgs e)
        {
            try
            {
                EnableUsers(false);

                if (!TryGetDepartmentId(out int departmentId))
                {
                    return;
                }

                var dialog = new UserDialog();

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                var user = await _restClient.CreateUserAsync(dialog.FullName, departmentId);

                lstUsers.Items.Add(user.Id.ToString(), user.FullName, 0);
            }
            finally
            {
                EnableUsers(true);
            }
        }

        private async void ShowDepartmentUsers(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                EnableUsers(false);

                if (!e.IsSelected)
                {
                    return;
                }

                if (!int.TryParse(e.Item.Name, out int departmentId))
                {
                    return;
                }

                var users = await _restClient.GetDepartmentUsersAsync(departmentId);

                try
                {
                    lstUsers.BeginUpdate();

                    lstUsers.Items.Clear();

                    foreach (var user in users)
                    {
                        lstUsers.Items.Add(user.Id.ToString(), user.FullName, 0);
                    }
                }
                finally
                {
                    lstUsers.EndUpdate();
                }
            }
            finally
            {
                EnableUsers(true);
            }
        }

        private async void EditDepartment(object sender, EventArgs e)
        {
            try
            {
                EnableDepartments(false);

                if (!TryGetDepartmentId(out int departmentId))
                {
                    return;
                }

                var dialog = new DepartmentDialog();

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var department = await _restClient.EditDepartmentAsync(departmentId, dialog.Title);

                lstDepartments.SelectedItems[0].Text = department.Title;

                _departments[department.Id] = department;
            }
            finally
            {
                EnableDepartments(true);
            }
        }

        private async void DeleteDepartment(object sender, EventArgs e)
        {
            try
            {
                EnableAll(false);

                if (!TryGetDepartmentId(out int departmentId))
                {
                    return;
                }

                await _restClient.DeleteDepartmentAsync(departmentId);

                lstDepartments.Items.RemoveByKey(departmentId.ToString());
                _departments.Remove(departmentId);

                lstUsers.BeginUpdate();
                lstUsers.Items.Clear();
                lstUsers.EndUpdate();
            }
            finally
            {
                EnableAll(true);
            }
        }

        private async void AddDepartment(object sender, EventArgs e)
        {
            try
            {
                EnableDepartments(false);

                var dialog = new DepartmentDialog();

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var department = await _restClient.CreateDepartmentAsync(dialog.Title);

                lstDepartments.Items.Add(department.Id.ToString(), department.Title, 0);
                _departments.Add(department.Id, department);
            }
            finally
            {
                EnableDepartments(true);
            }
        }

        private void Reconnect(object sender, EventArgs e)
        {
            var dialog = new ApiAddressDialog();

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                if (_httpClient == null)
                {
                    Close();
                }

                return;
            }

            if (_httpClient != null)
            {
                _httpClient.Dispose();
            }

            _httpClient = new HttpClient
            {
                BaseAddress = dialog.ApiOriginUri,
            };

            _restClient = new RestClient(_httpClient);

            UpdateDepartments();
        }

        private async void UpdateDepartments()
        {
            try
            {
                EnableAll(false);

                _departments = (await _restClient.GetDepartmentsAsync()).ToDictionary(d => d.Id);

                lstDepartments.BeginUpdate();

                try
                {
                    lstDepartments.Items.Clear();

                    foreach (var department in _departments)
                    {
                        lstDepartments.Items.Add(department.Key.ToString(), department.Value.Title, 0);
                    }
                }
                finally
                {
                    lstDepartments.EndUpdate();
                }

                lstUsers.BeginUpdate();
                lstUsers.Items.Clear();
                lstUsers.EndUpdate();
            }
            finally
            {
                EnableAll(true);
            }
        }

        private void EnableDepartments(bool enabled)
        {
            lstDepartments.Enabled = enabled;
            btnAddDepartment.Enabled = enabled;
            btnEditDepartment.Enabled = enabled;
            btnDeleteDepartment.Enabled = enabled;

            btnReconnect.Enabled = enabled;
        }

        private void EnableUsers(bool enabled)
        {
            lstUsers.Enabled = enabled;
            btnAddUser.Enabled = enabled;
            btnMoveUser.Enabled = enabled;

            btnReconnect.Enabled = enabled;
        }

        private void EnableAll(bool enabled)
        {
            EnableDepartments(enabled);
            EnableUsers(enabled);

            btnReconnect.Enabled = enabled;
        }

        private bool TryGetDepartmentId(out int departmentId)
        {
            departmentId = default;

            if (lstDepartments.SelectedItems.Count == 0)
            {
                return false;
            }

            if (!int.TryParse(lstDepartments.SelectedItems[0].Name, out departmentId))
            {
                return false;
            }

            return true;
        }

        private bool TryGetUserId(out int userId)
        {
            userId = default;

            if (lstUsers.SelectedItems.Count == 0)
            {
                return false;
            }

            if (!int.TryParse(lstUsers.SelectedItems[0].Name, out userId))
            {
                return false;
            }

            return true;
        }

    }
}
