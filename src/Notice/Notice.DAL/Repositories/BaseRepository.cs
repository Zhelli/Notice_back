using Microsoft.Extensions.Options;
using Notice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<T> GettingData<T>(string sqlExpression, Func<SqlDataReader, T> func, Dictionary<string, object> paramNamesAndValues = null)
        {
            List<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(dbConnection.DefaultConnection))
            {
                SqlCommand command = CreateCommand(sqlExpression, connection, paramNamesAndValues);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();
                try
                {
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(func(reader));
                        }
                    }

                    reader.Close();
                }
                catch
                { }
            }

            return list;
        }

        private SqlCommand CreateCommand(string sqlExpression, SqlConnection sqlConnection, Dictionary<string, object> paramNamesAndValues = null)
        {
            SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (paramNamesAndValues != null)
            {
                foreach (var item in paramNamesAndValues)
                {
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = item.Key,
                        Value = item.Value
                    });
                }
            }

            return command;
        }
    }
}
