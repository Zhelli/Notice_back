using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Event
    {
        public int Id;

        public int AuthorId;

        public string Title;

        public string Description;

        public DateTime DateOfEvent;

        public Event() { }

        public Event(SqlDataReader reader)
        {
            Id = reader.GetInt32(0);
            AuthorId = reader.GetInt32(1);
            Title = reader.GetString(2);
            Description = reader.IsDBNull(3) ? "" : reader.GetString(3);
            DateOfEvent = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4);
        }
    }
}
