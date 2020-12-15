using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Pupil
    {
        public int Id;

        public string FullName;

        public string Email;

        public string ClassName;

        public Pupil() { }

        public Pupil(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            FullName = reader.GetString(1);
            Email = reader.IsDBNull(2) ? "" : reader.GetString(2);
            ClassName = reader.GetString(3);
        }
    }
}
