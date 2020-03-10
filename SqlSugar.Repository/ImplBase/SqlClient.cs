using SqlSugar;
using System;

namespace SqlSugar.Repository.ImplBase
{
    public class SqlClient
    {
        public static string ConnectionString;

        public SqlClient(string connStr)
        {
            ConnectionString = connStr;
        }

        public SqlClient()
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ArgumentException("SqlSugarClient.ConnectString不能是null或Empty");
            }
        }

        /// <summary>
        /// 返回一个一个可访问数据库的SqlSugarClient对象
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = false,
                InitKeyType = InitKeyType.Attribute
            });
            db.Open();
            return db;
        }
    }
}
