using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WlanVerwaltung
{
    public partial class frmAdmin : Form
    {

        // MySql Connection
        static string connStr = "server=127.0.0.1; database=wlanverwaltung; uid=wlanuser; password=1234;";
        static MySqlConnection conn = new MySqlConnection(connStr);


        private DAO_AccessPoints accessPointsConn = new DAO_AccessPoints();
        private string accessPointId;
        private string macadresse;
        private string ssid;
        private string verschluesselungstyp;

        private DAO_Users usersConn = new DAO_Users();
        private string userId;
        private string username;
        private string firstname;
        private string lastname;
        private string password;
        private string role;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //get Data from DB and apply them to DataGridView
            selectAccessPointsFromDb();
            selectUsersFromDb();

        }

        private void selectAccessPointsFromDb()
        {

            //SELECT STATEMENT

            String select = this.accessPointsConn.buildSelectQuery();
            this.accessPointsConn.getDbDataAsBindingSource(select);

            try
            {

                //INSERT DATA INTO DATAGRIDVIEW
                dgvAccessPoints.DataSource = this.accessPointsConn.bindingSource;
                
                //Rearrange DataGridView
                dgvAccessPoints.Columns["idT_AccessPoints"].ReadOnly = true;

                int row = dgvAccessPoints.RowCount -1;
                int col = dgvAccessPoints.ColumnCount -1;

                dgvAccessPoints["isactive", row].Value = "True";
                dgvAccessPoints["isactive", row].ReadOnly = true;
                dgvAccessPoints["isactive", row].Style.BackColor = Color.Gray;
                dgvAccessPoints["isactive", row].Style.ForeColor = Color.Gray;

                dgvAccessPoints["dgvBtnAccessPointAdd", row].Style.BackColor = Color.Gray;
                dgvAccessPoints["dgvBtnAccessPointAdd", row].Style.ForeColor = Color.Gray;
                dgvBtnAccessPointAdd.Text = "\U0001f4be";

                dgvAccessPoints.Columns["dgvBtnAccessPointAdd"].DisplayIndex = col;

            }
            catch
            {
                Console.WriteLine("Verbindung Fehlgeschlagen");
            }
        }

        private void dgvAccessPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //if sender from DataGridView is Button
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 && e.RowIndex != dgvAccessPoints.RowCount - 1)
            {
                try
                {
                    this.accessPointId = dgvAccessPoints["idT_AccessPoints", e.RowIndex].Value.ToString();
                    this.macadresse = dgvAccessPoints["macadresse", e.RowIndex].Value.ToString();
                    this.ssid = dgvAccessPoints["ssid", e.RowIndex].Value.ToString();
                    this.verschluesselungstyp = dgvAccessPoints["verschluesselungstyp", e.RowIndex].Value.ToString();

                    assignDgvAccessPointsValuesToDao(e.ColumnIndex, e.RowIndex);

                }
                catch
                {
                    MessageBox.Show("Fehler Code xx0011");
                }
            }

        }

        private void assignDgvAccessPointsValuesToDao(int colIndex, int rowIndex)
        {
            //Apply Data from DataGridView to Database Object
            this.accessPointsConn.accessPointID = this.accessPointId;
            this.accessPointsConn.macadresse = this.macadresse;
            this.accessPointsConn.ssid = this.ssid;
            this.accessPointsConn.verschluesselungstyp = this.verschluesselungstyp;

            string colIndexText = "idT_AccessPoints";

            updateDatabase(this.accessPointsConn, ref dgvAccessPoints, rowIndex, colIndexText);

            //RELOAD TableGridView
            selectAccessPointsFromDb();

        }

        /**
         * 
         **/
        private void updateDatabase(DbConnection connHelper, ref DataGridView dgvHelper, int rowIndex, string colIndexText)
        {

            string query = "";
            bool success = false;
            
            DataGridViewCheckBoxCell cell = dgvHelper["isactive", rowIndex] as DataGridViewCheckBoxCell;
            

            if (dgvHelper[colIndexText, rowIndex].Value == null | dgvHelper[colIndexText, rowIndex].Value.ToString() == "")
            {
                //INSERT 
                query = connHelper.buildInsertQuery();
                success = connHelper.queryExecute(query);
                MessageBox.Show("Gespeichert " + success.ToString());

            }
            else if (cell.Value.Equals(true))
            {
                //INSERT NEW AND DELETE OLD
                query = connHelper.buildInsertQuery();
                success = connHelper.queryExecute(query);
                query = connHelper.buildUpdateQuery();
                success = connHelper.queryExecute(query);
                MessageBox.Show("Gespeichert " + success.ToString());

            }
            else
            {
                //DELETE
                query = connHelper.buildUpdateQuery();
                success = connHelper.queryExecute(query);
                MessageBox.Show("Gespeichert " + success.ToString());

            }

        }

        private void selectUsersFromDb ()
        {
            //SELECT STATEMENT
            String select = this.usersConn.buildSelectQuery(); 
            this.usersConn.getDbDataAsBindingSource(select);

            try
            {

                //INSERT DATA INTO DATAGRIDVIEW
                dgvUsers.DataSource = this.usersConn.bindingSource;
                string dropdownQuery = this.usersConn.buildQueryForDropDownList();
                usersConn.getRoleDataAsBindingSource(dropdownQuery);

                //Rearrange DataGridView
                dgvUsers.Columns["idT_benutzer"].ReadOnly = true;

                //set Values of Combobox Role (teacher, student, admin)
                dgvCmbRole.DataSource = this.usersConn.RoleSource;
                dgvCmbRole.DisplayMember = "bezeichnung";
                dgvCmbRole.ValueMember = "idT_Rolle";
                dgvCmbRole.DataPropertyName = "idT_Rolle";

                dgvUsers.Columns["idT_Rolle"].Visible = false;
                dgvUsers.Columns["bezeichnung"].Visible = false;
                dgvUsers.Columns["fk_rolle"].Visible = false;

                int row = dgvUsers.RowCount - 1;
                int col = dgvUsers.ColumnCount - 1;

                dgvCmbRole.DisplayIndex = col;

                dgvUsers["isactive", row].Value = "True";
                dgvUsers["isactive", row].ReadOnly = true;
                dgvUsers["isactive", row].Style.BackColor = Color.Gray;
                dgvUsers["isactive", row].Style.ForeColor = Color.Gray;

                dgvUsers["dgvBtnUserAdd", row].Style.BackColor = Color.Gray;
                dgvUsers["dgvBtnUserAdd", row].Style.ForeColor = Color.Gray;
                dgvBtnUserAdd.Text = "\U0001f4be";
                dgvBtnUserAdd.DisplayIndex = col;
                dgvUsers.Columns["dgvBtnUserAdd"].DisplayIndex = col;


                dgvUsers.Refresh();


            }
            catch
            {
                Console.WriteLine("Verbindung Fehlgeschlagen");
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            bool roleIsEmpty = false;
            

            if (dgvUsers["dgvCmbRole", e.RowIndex].Value.ToString().Equals("") )
            {
                MessageBox.Show("value is empty");
                roleIsEmpty = true;
            }

            

            //if sender from DataGridView is Button
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 && e.RowIndex != dgvUsers.RowCount - 1 && !roleIsEmpty)
            {

                try
                {

                    this.userId = dgvUsers["idT_Benutzer", e.RowIndex].Value.ToString();
                    this.username = dgvUsers["benutzername", e.RowIndex].Value.ToString();
                    this.firstname = dgvUsers["vorname", e.RowIndex].Value.ToString();
                    this.lastname = dgvUsers["nachname", e.RowIndex].Value.ToString();
                    this.password = dgvUsers["passwort", e.RowIndex].Value.ToString();
                    this.role = dgvUsers["dgvCmbRole", e.RowIndex].Value.ToString();

                    assignDgvUsersValuesToDao(e.ColumnIndex, e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler Code xx0011 - \n" + ex);
                }
            }
        }

        private void assignDgvUsersValuesToDao(int colIndex, int rowIndex)
        {
            //Apply Data from DataGridView to Database Object
            this.usersConn.UserId = this.userId;
            this.usersConn.Username = this.username;
            this.usersConn.Firstname = this.firstname;
            this.usersConn.Lastname = this.lastname;
            this.usersConn.Password = this.password;
            this.usersConn.Role = this.role;

            //MessageBox.Show(this.role);

            string colIndexText = "idT_Benutzer";

            updateDatabase(this.usersConn, ref dgvUsers, rowIndex, colIndexText);

            //RELOAD TableGridView
            selectUsersFromDb();

        }
    }
}