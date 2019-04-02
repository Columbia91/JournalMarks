using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalMarks.DataAccess
{
    public class BaseRepository : IDisposable
    {
        public SqlConnection _connection { get; set; }

        public BaseRepository()
        {
            try
            {
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["JournalMarkDB"].ConnectionString);
                //ConfigurationManager.ConnectionStrings["JournalMarkDB"].ConnectionString;
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
