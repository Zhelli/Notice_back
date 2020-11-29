using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Notice.DAL.Interfaces
{
    public interface IBaseRepository
    {
        public List<T> GettingData<T>(string sqlExpression, Func<SqlDataReader, T> func, Dictionary<string, object> paramNamesAndValues = null);
    }
}
