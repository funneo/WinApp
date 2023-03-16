using System;
using System.Data.Common;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Data.ADO.DA
{
    public static class Data
    {
        public static string dataProvider = "System.Data.SqlClient";
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
        public static string connectionString = string.Empty;
        public static string Server = string.Empty;
        public static string Database = string.Empty;
        public static string UserID = string.Empty;
        public static string Password = string.Empty;
        public static bool IsWindowAuthenMod = false;     

        public static string ConnectionString
        {
            get
            {
                connectionString = String.Format("server={0};database={1};", Server, Database);
                if (IsWindowAuthenMod)
                {
                    connectionString += "Integrated Security=true;";
                }
                else
                {
                    connectionString += String.Format("uid={0};pwd={1};Connection Timeout=10000", UserID, Password);
                }
                return connectionString;
            }
            set { connectionString = value; }
        }

        #region parameters

        public static DbParameter CreateParameter(string ParameterName)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = ParameterName;
            return p;
        }

        public static DbParameter CreateParameter(string ParameterName, object ParameterValue)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = ParameterName;
            p.Value = ParameterValue;
            if (p.Value == null)
                p.Value = DBNull.Value;
            else if (p.Value == DBNull.Value)
                p.Value = DBNull.Value;
            else if (p.DbType == DbType.String && (((string)p.Value).Trim().Length == 0 || (string)p.Value == "0"))
                p.Value = DBNull.Value;            
            else
                p.Value = p.Value;
            if (p.DbType == DbType.String && p.Value != DBNull.Value)
                p.Value = ((string)p.Value).Trim();
            return p;
        }

        public static DbParameter CreateParameter(string ParameterName, DbType ParameterType, int ParameterSize)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = ParameterName;
            p.DbType = ParameterType;
            p.Size = ParameterSize;
            return p;
        }

        public static DbParameter CreateParameter(string ParameterName, object ParameterValue, DbType ParameterType)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = ParameterName;
            p.Value = ParameterValue;
            p.DbType = ParameterType;
            if (p.Value == null)
                p.Value = DBNull.Value;
            else if (p.DbType == DbType.String && (((string)p.Value).Trim().Length == 0 || (string)p.Value == "0"))
                p.Value = DBNull.Value;
            else if (p.DbType == DbType.DateTime && ((DateTime)p.Value == new DateTime(1900, 1, 1)))
                p.Value = DBNull.Value;           
            return p;
        }

        #endregion
       
        /// <summary>
        /// Get Dataset
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static DataSet GetDataset(string proc, List<string> pName, List<object> pValue)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            for (int i = 0; i < pName.Count; i++)
                parameters.Add(Data.CreateParameter(pName[i], pValue[i]));
            return SqlHelper.ExecuteDataSet(Data.ConnectionString, CommandType.StoredProcedure, proc, parameters.ToArray());
        }

        /// <summary>
        /// Get Dataset
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static DataSet GetDataset(string Query, CommandType commandType, List<string> pName, List<object> pValue)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            if (pName != null)
                for (int i = 0; i < pName.Count; i++)
                    parameters.Add(Data.CreateParameter(pName[i], pValue[i]));
            return SqlHelper.ExecuteDataSet(Data.ConnectionString, commandType, Query, parameters.ToArray());
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="commandType"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public static void ExecuteNonQuery(string Query, CommandType commandType, List<string> pName, List<object> pValue)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            if (pName != null)
                for (int i = 0; i < pName.Count; i++)
                    parameters.Add(Data.CreateParameter(pName[i], pValue[i]));
            SqlHelper.ExecuteNonQuery(Data.ConnectionString, commandType, Query, parameters.ToArray());
        }

        /// <summary>
        /// ExecuteNonQuery return value
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="commandType"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public static int ExecuteNonQuery(string Query, CommandType commandType, List<string> pName, List<object> pValue, string OutputName)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            int n = 0;
            if (pName != null)
                for (int i = 0; i < pName.Count; i++)
                    parameters.Add(Data.CreateParameter(pName[i], pValue[i]));
            int id = 0;
            DbParameter para = Data.CreateParameter(OutputName, id);
            para.Direction = ParameterDirection.Output;
            parameters.Add(para);
            n = SqlHelper.ExecuteNonQuery(Data.ConnectionString, commandType, Query, parameters.ToArray());
            return (int)para.Value;
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="commandType"></param>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public static object ExecuteScalar(string Query, CommandType commandType, List<string> pName, List<object> pValue)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            if (pName != null)
                for (int i = 0; i < pName.Count; i++)
                    parameters.Add(Data.CreateParameter(pName[i], pValue[i]));
            return SqlHelper.ExecuteScalar(Data.ConnectionString, commandType, Query, parameters.ToArray());
        }
    }
}
