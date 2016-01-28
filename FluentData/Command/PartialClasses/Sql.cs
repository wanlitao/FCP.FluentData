namespace FluentData
{
	internal partial class DbCommand
	{
		public IDbCommand Sql(string sql)
		{
            Data.Sql.Append(sql);            
			return this;
		}

		public IDbCommand ClearSql()
		{			
			Data.Sql.Clear();
			return this;
		}
	}
}
