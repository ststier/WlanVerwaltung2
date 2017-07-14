using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WlanVerwaltung
{
    class DAO_AccessPoints : DbConnection
    {

        public string accessPointID { get; set; }
        public string macadresse { get; set; }
        public string ssid { get; set; }
        public string verschluesselungstyp { get; set; }


        public override string buildSelectQuery()
        {
            string query = "SELECT * FROM `T_AccessPoints` WHERE `isactive`=1;";

            return query;
        }

        public override string buildInsertQuery()
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
            "'" + macadresse + "', " +
            "'" + ssid + "', " +
            "'" + verschluesselungstyp + "', " +
            "1" +
        " )";

            return query;
        }

        public override string buildUpdateQuery()
        {
            string query = "UPDATE `wlanverwaltung`.`t_accesspoints` " +
                "SET `isactive`= '0' " +
                "WHERE `idT_AccessPoints`= '" +
                this.accessPointID + "'";

            return query;
        }

    }
}
