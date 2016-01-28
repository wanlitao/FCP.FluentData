using System;
using System.Configuration;
using FluentData;

namespace FCP.FluentData.UnitTest
{
    public static class ContextHelper
    {
        public static IDbContext getMySqlDbContext(string connectionName)
        {
            var connectionString = getConfigConnectionString(connectionName);

            return new DbContext().ConnectionString(connectionString, new MySqlProvider());
        }

        private static string getConfigConnectionString(string connectionName)
        {
            var connectionObject = ConfigurationManager.ConnectionStrings[connectionName];
            if (connectionObject == null)
            {
                throw new ArgumentNullException("找不到数据库连接配置：" + connectionName);
            }
            return connectionObject.ConnectionString;
        }
    }
}
