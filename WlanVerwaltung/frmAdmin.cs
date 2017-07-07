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
        AccessPoint ap = new AccessPoint();
        AccessPoint ap1 = new AccessPoint();

        // MySql Connection
        static string connStr = "server=127.0.0.1; database=wlanverwaltung; uid=wlanuser; password=1234;";
        static MySqlConnection conn = new MySqlConnection(connStr);

        public frmAdmin()
        {
            InitializeComponent();
        }


        private void frmAdmin_Load(object sender, EventArgs e)
        {

            selectFromDb();



            //MessageBox.Show("Dot Net Perls is awesome.");

            /*
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = True;
            col.Text = "ADD";
            col.Name = "MyButton";
            dataGridView1.Columns.Add(col);
            */

            ap.ssid = "AP1";
            ap.macAdresse = "123455667753556456";
            ap.verschluesselungstyp = "WPA/WPA2";

            ap1.ssid = "AP0";
            ap1.macAdresse = "123455667753556456";
            ap1.verschluesselungstyp = "WPA/WPA2";

            

            //accessPointBindingSource.Add(ap);
            //accessPointBindingSource.Add(ap1);

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

            }
            catch
            {
                Console.WriteLine("Verbindung Fehlgeschlagen");
            }
        }

        private void dgvAccessPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 0 && e.RowIndex != dgvAccessPoints.RowCount - 1)
            {
                try
                {
                    //+dgvAccessPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                    string accessPointID = dgvAccessPoints[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                    string macadresse = dgvAccessPoints[e.ColumnIndex + 2, e.RowIndex].Value.ToString();
                    string ssid = dgvAccessPoints[e.ColumnIndex + 3, e.RowIndex].Value.ToString();
                    string verschluesselungstyp = dgvAccessPoints[e.ColumnIndex + 4, e.RowIndex].Value.ToString();
                    updateDb(accessPointID, macadresse, ssid, verschluesselungstyp);
                    MessageBox.Show(sender.ToString() + " / " + accessPointID + " " + macadresse + " " + ssid + " " + verschluesselungstyp);
                }
                catch
                {
                    MessageBox.Show("Fehler Code xx0011");
                }
            }

        }

        private void updateDb (string accessPointID, string macadresse, string ssid, string verschluesselungstyp)
        {

            MessageBox.Show(dgvAccessPoints.Columns["isactive"].ToString() );
            //if ()

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `T_AccessPoints` (idT_AccessPoints, macadresse, ssid, verschluesselungstyp, isactive) VALUES(NULL, @macadresse, @ssid, @verschluesselungstyp, 1)", conn);
         
            cmd.Parameters.AddWithValue("@macadresse", macadresse);
            cmd.Parameters.AddWithValue("@ssid", ssid);
            cmd.Parameters.AddWithValue("@verschluesselungstyp", verschluesselungstyp);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            cmd = new MySqlCommand("UPDATE `wlanverwaltung`.`t_accesspoints` SET `isactive`= '0' WHERE `idT_AccessPoints`= '" + accessPointID + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //RELOAD TABLEGRIDVIEW
            selectFromDb();

            // UPDATE `wlanverwaltung`.`t_accesspoints` SET `verschluesselungstyp`= 'WPA3' WHERE `idT_AccessPoints`= '2';

        }
    }
}
