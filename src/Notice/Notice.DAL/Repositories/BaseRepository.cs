using Microsoft.Extensions.Options;
using Notice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DbConnection dbConnection;

        public BaseRepository(IOptions<DbConnection> options)
        {
            dbConnection = options.Value;
        }
        
        public void ExampleMethodGettingData()
        {
            //...

            using (SqlConnection connection = new SqlConnection(dbConnection.DefaultConnection))
            {
                //your logic, work with database
            }

            //...
        }
    }
}
