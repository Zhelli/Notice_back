using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Class
    {
        public int Id;

        public string ClassName;

        public int TeacherId;

        public Class() { }

        public Class(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            ClassName = reader.GetString(1);
            TeacherId = reader.GetInt32(2);
        }
    }
}