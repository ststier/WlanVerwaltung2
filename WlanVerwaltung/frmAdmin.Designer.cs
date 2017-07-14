namespace WlanVerwaltung
{
    partial class frmAdmin
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
            this.frmApAnlegen = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAccessPoint = new System.Windows.Forms.TabPage();
            this.dgvAccessPoints = new System.Windows.Forms.DataGridView();
            this.dgvBtnAccessPointAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabBenutzer = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.dgvBtnUserAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvCmbRole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabAccessPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessPoints)).BeginInit();
            this.tabBenutzer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // frmApAnlegen
            // 
            this.frmApAnlegen.AutoSize = true;
            this.frmApAnlegen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.frmApAnlegen.Location = new System.Drawing.Point(23, 12);
            this.frmApAnlegen.Name = "frmApAnlegen";
            this.frmApAnlegen.Size = new System.Drawing.Size(0, 0);
            this.frmApAnlegen.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAccessPoint);
            this.tabControl1.Controls.Add(this.tabBenutzer);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1498, 757);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabAccessPoint
            // 
            this.tabAccessPoint.AutoScroll = true;
            this.tabAccessPoint.Controls.Add(this.dgvAccessPoints);
            this.tabAccessPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAccessPoint.Location = new System.Drawing.Point(4, 34);
            this.tabAccessPoint.Name = "tabAccessPoint";
            this.tabAccessPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccessPoint.Size = new System.Drawing.Size(1490, 719);
            this.tabAccessPoint.TabIndex = 0;
            this.tabAccessPoint.Text = "Access Point";
            this.tabAccessPoint.UseVisualStyleBackColor = true;
            // 
            // dgvAccessPoints
            // 
            this.dgvAccessPoints.AllowUserToOrderColumns = true;
            this.dgvAccessPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAccessPoints.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAccessPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccessPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBtnAccessPointAdd});
            this.dgvAccessPoints.Location = new System.Drawing.Point(6, 6);
            this.dgvAccessPoints.Name = "dgvAccessPoints";
            this.dgvAccessPoints.Size = new System.Drawing.Size(1097, 593);
            this.dgvAccessPoints.TabIndex = 2;
            this.dgvAccessPoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccessPoints_CellContentClick);
            // 
            // dgvBtnAccessPointAdd
            // 
            this.dgvBtnAccessPointAdd.HeaderText = "Add";
            this.dgvBtnAccessPointAdd.Name = "dgvBtnAccessPointAdd";
            this.dgvBtnAccessPointAdd.Text = "save";
            this.dgvBtnAccessPointAdd.UseColumnTextForButtonValue = true;
            this.dgvBtnAccessPointAdd.Width = 57;
            // 
            // tabBenutzer
            // 
            this.tabBenutzer.Controls.Add(this.dgvUsers);
            this.tabBenutzer.Location = new System.Drawing.Point(4, 34);
            this.tabBenutzer.Name = "tabBenutzer";
            this.tabBenutzer.Padding = new System.Windows.Forms.Padding(3);
            this.tabBenutzer.Size = new System.Drawing.Size(1490, 719);
            this.tabBenutzer.TabIndex = 2;
            this.tabBenutzer.Text = "Benutzer";
            this.tabBenutzer.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvBtnUserAdd,
            this.dgvCmbRole});
            this.dgvUsers.Location = new System.Drawing.Point(7, 6);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(1477, 707);
            this.dgvUsers.TabIndex = 3;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            // 
            // dgvBtnUserAdd
            // 
            this.dgvBtnUserAdd.HeaderText = "Add";
            this.dgvBtnUserAdd.Name = "dgvBtnUserAdd";
            this.dgvBtnUserAdd.Text = "save";
            this.dgvBtnUserAdd.UseColumnTextForButtonValue = true;
            this.dgvBtnUserAdd.Width = 57;
            // 
            // dgvCmbRole
            // 
            this.dgvCmbRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvCmbRole.HeaderText = "Rolle";
            this.dgvCmbRole.Name = "dgvCmbRole";
            this.dgvCmbRole.Width = 68;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1522, 787);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.frmApAnlegen);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAccessPoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccessPoints)).EndInit();
            this.tabBenutzer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel frmApAnlegen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAccessPoint;
        private System.Windows.Forms.TabPage tabBenutzer;
        private System.Windows.Forms.DataGridView dgvAccessPoints;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewButtonColumn dgvBtnAccessPointAdd;
        private System.Windows.Forms.DataGridViewButtonColumn dgvBtnUserAdd;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvCmbRole;
    }
}