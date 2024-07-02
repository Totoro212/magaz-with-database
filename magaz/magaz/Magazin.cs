using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace magaz
{
    internal class Magazin
    {
        public SqlConnection con;

        public int Connection()
        {
            con = new SqlConnection(@"");
            try
            {
                con.Open();
                return 1;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        public DataTable Select_Query(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable tablica = new DataTable();
            da.Fill(tablica);
            return tablica;
        }
        public int Query_IUD(string zapros)
        {
            int res = -1;
            SqlCommand cm = new SqlCommand(zapros, con);
            res = cm.ExecuteNonQuery();
            return res;
        }


    }
}
