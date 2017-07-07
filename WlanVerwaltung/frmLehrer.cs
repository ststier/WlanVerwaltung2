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

        private string accessPointID;
        private string macadresse;
        private string ssid;
        private string verschluesselungstyp;
        private string idT_AccessPoints;

        public frmAdmin()
        {
            InitializeComponent();
        }


        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //get Data from DB and apply them to DataGridView
            selectFromDb();

        }

        private void selectFromDb()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();

            //SELECT STATEMENT
            String select = "SELECT * FROM `T_AccessPoints` WHERE `isactive`=1;";

            try
            {
                cmd = new MySqlCommand(select, conn);
                //ADAPTER
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //APPLY TABLE TO DATASET
                bs.DataSource = ds.Tables[0];
                //INSERT DATA INTO DATAGRIDVIEW
                dgvAccessPoints.DataSource = bs;
                conn.Close();
                dgvAccessPoints.Columns["idT_AccessPoints"].ReadOnly = true;

                int row = dgvAccessPoints.RowCount -1;
                int col = dgvAccessPoints.ColumnCount;

                dgvAccessPoints["isactive", row].Value = "True";
                dgvAccessPoints["isactive", row].ReadOnly = true;
                dgvAccessPoints["isactive", row].Style.BackColor = Color.Gray;


                dgvBtnAdd.Text = "\U0001f4be";

                dgvAccessPoints.Columns["dgvBtnAdd"].DisplayIndex = dgvAccessPoints.ColumnCount -1;

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
                    this.accessPointID = dgvAccessPoints["idT_AccessPoints", e.RowIndex].Value.ToString();
                    this.macadresse = dgvAccessPoints["macadresse", e.RowIndex].Value.ToString();
                    this.ssid = dgvAccessPoints["ssid", e.RowIndex].Value.ToString();
                    this.verschluesselungstyp = dgvAccessPoints["verschluesselungstyp", e.RowIndex].Value.ToString();
                    updateDb(e.ColumnIndex, e.RowIndex);

                }
                catch
                {
                    MessageBox.Show("Fehler Code xx0011");
                }
            }

        }

        private void updateDb (int colIndex, int rowIndex)
        {

            string query = "";
            bool success = false;
            DataGridViewCheckBoxCell cell = dgvAccessPoints["isactive", rowIndex] as DataGridViewCheckBoxCell;

            // if A new Access Point was added
            if (dgvAccessPoints["idT_AccessPoints", rowIndex].Value == null | dgvAccessPoints["idT_AccessPoints", rowIndex].Value.ToString() == "")
            {
                query = buildInsertAccesspointQuery();

                success = queryExecute(query);

                MessageBox.Show(success.ToString());

            }
            else if (cell.Value.Equals(true))
            {

                query = buildInsertAccesspointQuery();

                success = queryExecute(query);

                query = buildDeleteAccesspointQuery();

                success = queryExecute(query);

                MessageBox.Show(success.ToString());

            }
            else
            {
                query = buildDeleteAccesspointQuery();

                success = queryExecute(query);

                MessageBox.Show(success.ToString());

            }

            //RELOAD TableGridView
            selectFromDb();

        }

        private string buildInsertAccesspointQuery()
        {

            string query = "INSERT INTO `T_AccessPoints` " +
                    "(" +
                        "idT_AccessPoints, " +
                        "macadresse, " +
                        "ssid, " +
                        "verschluesselungstyp, " +
                        "isactive) " +
                    "VALUES(" +
                        "NULL, " +
                        "'" + this.macadresse + "', " +
                        "'" + this.ssid + "', " +
                        "'" + this.verschluesselungstyp + "', " +
                        "1" +
                    " )";

            return query;
        }

        private string buildDeleteAccesspointQuery()
        {
            string query = "UPDATE `wlanverwaltung`.`t_accesspoints` " + 
                "SET `isactive`= '0' " + 
                "WHERE `idT_AccessPoints`= '" + 
                this.accessPointID + "'";

            return query;
        }

        private bool queryExecute(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            } catch (Exception ex)
            {
                //MessageBox.Show("Fehlercode Fehler Code xx0012 - " + ex); //debugmode
                MessageBox.Show("Fehlercode Fehler Code xx0012 - " + ex);
                return false;
            }

        }
    }
}