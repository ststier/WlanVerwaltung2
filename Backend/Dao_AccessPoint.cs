using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Backend
{
    class Dao_AccessPoint
    {


        public Dao_AccessPoint() {

            
    }


        public Boolean insert(String macadresse, String ssid, String verschlüsselungstyp)
        {
            Boolean erfolg;
            DbConnector connection = new DbConnector();
            
            String query = "INSERT INTO `T_AccessPoints` (macadresse, ssid, verschluesselungstyp) VALUES ('"+
                macadresse +"', '"+
                ssid +"', '"+
                verschlüsselungstyp +"');";


            erfolg = connection.executeQuery(query);

            Console.ReadLine();

            return erfolg;
        }


        //public List<AccessPoint> selectAll()
        public Boolean selectAll()
        {


            List<AccessPoint> accessPointList = new List<AccessPoint>();
            Boolean erfolg;
            DbConnector connection = new DbConnector();

            String query = "SELECT * FROM `T_AccessPoints`; ";

            MySqlCommand command = new MySqlCommand();
            command.CommandText = query;


            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                // accessPointList.Add(reader["Values_To_Add "]);
                Console.WriteLine(reader["id"]);
            }


            //DbConnector connection = new DbConnector();

            


            erfolg = connection.executeQuery(query);

            Console.ReadLine();

            return erfolg;
        }

    }
}
