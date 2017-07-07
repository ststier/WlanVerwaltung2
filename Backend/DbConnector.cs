using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Backend
{
    class DbConnector
    {

        private MySqlConnection connection;

        public DbConnector()
        {
            connectToDb();
        }


        public void connectToDb()
        {
            //generate the connection string

            string connStr = CreateConnStr("127.0.0.1", "wlanverwaltung", "wlanuser", "1234");



            try
            {
                //create a MySQL connection with a query string
                connection = new MySqlConnection(connStr);

                //open the connection
                //connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }

            //close the connection
            // connection.Close();

        }




        private string CreateConnStr(string server, string databaseName, string user, string pass)
        {
            //build the connection string
            string connStr = "server=" + server + ";database=" + databaseName + ";uid=" +
                user + ";password=" + pass + ";";

            //return the connection string
            return connStr;
        }

        public Boolean executeQuery(String query)
        {
            Boolean erfolg = false;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, this.connection);

                command.ExecuteNonQuery();
                

                erfolg = true;

            } catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                erfolg = false;
            }finally
            {
                connection.Close();

            }

            return erfolg;

        }

    }

}
    

