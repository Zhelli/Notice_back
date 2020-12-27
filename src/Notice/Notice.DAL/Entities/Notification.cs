using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Notification
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public Notification() { }

        public Notification(SqlDataReader reader)
        {
            Title = reader.GetString(0);
            EventId = reader.GetInt32(1);
        }
    }
}
