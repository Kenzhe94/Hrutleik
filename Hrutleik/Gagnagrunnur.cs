using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Hrutleik
{
    class Gagnagrunnur
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        string tengistrengur = null;
        string fyrirspurn = null;

        MySqlConnection sqltenging;
        MySqlCommand nySQLskipun;
        MySqlDataReader sqllesari = null;

        public void TengingVidGagnagrunn()
        {
            server = "10.200.10.24";
            database = "0510942049_timaverkefni6";
            uid = "0510942049";
            password = "mypassword";

            tengistrengur = "server=" + server + ";userid=" + uid + ";password=" + password
                + ";database=" + database;
            sqltenging = new MySqlConnection(tengistrengur);
        }
        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
