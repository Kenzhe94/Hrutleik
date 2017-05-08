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
            database = "0112982819_hopaverk";
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
        public List<string> LesariSQL(string Quar)
        {
            List<string> data = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                nySQLskipun = new MySqlCommand(Quar, sqltenging);
                sqllesari = nySQLskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ":";
                    }
                    data.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return data;
            }
            return data;
        }
    }
}
