using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalMarks.Models;

namespace JournalMarks.DataAccess
{
    public class Repository : BaseRepository
    {
        public void SavePerson(Person person)
        {
            string query = @"insert into Person (LastName,FirstName,MiddleName,GenderId) values
                            (@lastName,@firstName,@middleName,@genderId)";

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("@lastName", SqlDbType.NVarChar){Value = person.LastName},
                new SqlParameter("@firstName", SqlDbType.NVarChar){Value = person.FirstName},
                new SqlParameter("@middleName", SqlDbType.NVarChar){Value = person.MiddleName},
                new SqlParameter("@genderId", SqlDbType.Int){Value = person.GenderId},
            });

            command.ExecuteNonQuery();
            command.Dispose();
        }
        public Person GetPersonById(int id)
        {
            Person person = new Person();
            string query = "Select * from Person Where Id = @id";
            using(SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    person.Id = (int)reader["Id"];
                    person.LastName = reader["LastName"].ToString();
                    person.FirstName = reader["FirstName"].ToString();
                    person.MiddleName = reader["MiddleName"].ToString();
                    person.GenderId = (int)reader["GenderId"];
                }
            }
            return person;
        }
    }
}
