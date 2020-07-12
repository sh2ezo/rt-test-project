namespace UsersAndDepartmentsClientApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReconnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstDepartments = new System.Windows.Forms.ListView();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstUsers = new System.Windows.Forms.ListView();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnMoveUser = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReconnect
            // 
            this.btnReconnect.Location = new System.Drawing.Point(12, 12);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(776, 23);
            this.btnReconnect.TabIndex = 1;
            this.btnReconnect.Text = "Указать адрес API";
            this.btnReconnect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstDepartments);
            this.groupBox1.Controls.Add(this.btnAddDepartment);
            this.groupBox1.Controls.Add(this.btnEditDepartment);
            this.groupBox1.Controls.Add(this.btnDeleteDepartment);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 515);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отделы";
            // 
            // lstDepartments
            // 
            this.lstDepartments.FullRowSelect = true;
            this.lstDepartments.HideSelection = false;
            this.lstDepartments.Location = new System.Drawing.Point(6, 22);
            this.lstDepartments.Name = "lstDepartments";
            this.lstDepartments.Size = new System.Drawing.Size(339, 400);
            this.lstDepartments.TabIndex = 4;
            this.lstDepartments.UseCompatibleStateImageBehavior = false;
            this.lstDepartments.View = System.Windows.Forms.View.List;
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Location = new System.Drawing.Point(6, 428);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(339, 23);
            this.btnAddDepartment.TabIndex = 3;
            this.btnAddDepartment.Text = "Добавить";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.Location = new System.Drawing.Point(6, 457);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(339, 23);
            this.btnEditDepartment.TabIndex = 2;
            this.btnEditDepartment.Text = "Редактировать";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.Location = new System.Drawing.Point(6, 486);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(339, 23);
            this.btnDeleteDepartment.TabIndex = 1;
            this.btnDeleteDepartment.Text = "Удалить";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstUsers);
            this.groupBox2.Controls.Add(this.btnAddUser);
            this.groupBox2.Controls.Add(this.btnMoveUser);
            this.groupBox2.Location = new System.Drawing.Point(369, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(419, 515);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пользователи";
            // 
            // lstUsers
            // 
            this.lstUsers.FullRowSelect = true;
            this.lstUsers.HideSelection = false;
            this.lstUsers.Location = new System.Drawing.Point(6, 22);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(407, 400);
            this.lstUsers.TabIndex = 4;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.List;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(6, 428);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(407, 23);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Добавить";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // btnMoveUser
            // 
            this.btnMoveUser.Location = new System.Drawing.Point(6, 457);
            this.btnMoveUser.Name = "btnMoveUser";
            this.btnMoveUser.Size = new System.Drawing.Size(407, 23);
            this.btnMoveUser.TabIndex = 1;
            this.btnMoveUser.Text = "Переместить";
            this.btnMoveUser.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReconnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Пользователи и Отделы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnMoveUser;
        private System.Windows.Forms.ListView lstDepartments;
        private System.Windows.Forms.ListView lstUsers;
    }
}