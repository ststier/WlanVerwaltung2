using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace WlanVerwaltung
{
   abstract class DbConnection
    {
        // MySql Connection
        static string connStr = "server=127.0.0.1; database=wlanverwaltung; uid=wlanuser; password=1234;";
        protected MySqlConnection conn = new MySqlConnection(connStr);

        public MySqlDataAdapter mysqlDataAdapter { get; set; }
        public DataSet dataSet { get; set; }
        public BindingSource bindingSource { get; set; }


        public void getDbDataAsBindingSource(string select) {

            MySqlCommand cmd;

            mysqlDataAdapter = new MySqlDataAdapter();
            dataSet = new DataSet();
            bindingSource = new BindingSource();

            cmd = new MySqlCommand(select, this.conn);
            //ADAPTER
            mysqlDataAdapter.SelectCommand = cmd;
            mysqlDataAdapter.Fill(dataSet);
            //APPLY TABLE TO DATASET
            bindingSource.DataSource = dataSet.Tables[0];
            conn.Close();

        }


        public abstract string buildSelectQuery();
        public abstract string buildInsertQuery();

        public abstract string buildUpdateQuery();

        public bool queryExecute(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Fehlercode Fehler Code xx0012 - " + ex); //debugmode
                MessageBox.Show("Fehlercode Fehler Code xx0012 - " + ex);
                return false;
            }

        }
    }
}
