using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DateOfEvent { get; set; }

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
