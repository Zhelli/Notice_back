using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Teacher
    {
        public int Id;

        public string FullName;

        public string Email;

        public Teacher() { }

        public Teacher(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            FullName = reader.GetString(1);
            Email = reader.IsDBNull(2) ? "" : reader.GetString(2);
        }
    }
}
