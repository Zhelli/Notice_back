using System;
using System.Collections.Generic;
using System.Text;

namespace Notice.DAL
{
    public class DbConnection
    {
        public const string ConnectionStrings = "ConnectionStrings";

        public string DefaultConnection { get; set; }
    }
}