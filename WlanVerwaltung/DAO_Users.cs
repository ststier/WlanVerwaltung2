using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WlanVerwaltung
{
    class DAO_Users : DbConnection
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Isactive { get; set; }
        public ArrayList RoleList { get; set; }
        public BindingSource RoleSource { get; set; }
        public DataTable dataTable { get; set; }


       


        public override string buildSelectQuery()
        {
            string query = "SELECT * FROM t_benutzer " + 
                "LEFT JOIN t_rolle " +
                "ON (t_benutzer.fk_rolle = t_rolle.idT_Rolle) " +
                "WHERE `isactive` = 1;";

            return query;
        }

        public override string buildInsertQuery()
        {
            string query = "INSERT INTO `t_benutzer` " +
                    "(" +
                        "idT_Benutzer, " +
                        "benutzername, " +
                        "vorname, " +
                        "nachname, " +
                        "passwort, " +
                        "fk_rolle, " +
                        "isactive) " +
                    "VALUES(" +
                        "NULL, " +
                        "'" + Username + "', " +
                        "'" + Firstname + "', " +
                        "'" + Lastname + "', " +
                        "'" + Password + "', " +
                        "'" + Role + "', " +
                        "1" +
                    " )";

            return query;
        }


        public override string buildUpdateQuery()
        {
            string query = "UPDATE `wlanverwaltung`.`t_benutzer` " +
                "SET `isactive`= '0' " +
                "WHERE `idT_Benutzer`= '" +
                this.UserId + "'";

            return query;
        }

        public string buildQueryForDropDownList()
        {
            string query = "SELECT * FROM wlanverwaltung.t_rolle;";

            return query;
        }

        public void getRoleDataAsBindingSource(string select)
        {

            MySqlCommand cmd;

            mysqlDataAdapter = new MySqlDataAdapter();
            dataTable = new DataTable();

            RoleSource = new BindingSource();

            cmd = new MySqlCommand(select, this.conn);
            //ADAPTER
            mysqlDataAdapter.SelectCommand = cmd;
            mysqlDataAdapter.Fill(dataTable);
            //APPLY TABLE TO DATASET
            RoleSource.DataSource = dataTable;
            conn.Close();

            this.RoleList = new ArrayList();

            foreach (DataRow dr in dataTable.Rows )
            {
                this.RoleList.Add(dr["bezeichnung"].ToString());
                
            }
            
            

        }



    }
}
