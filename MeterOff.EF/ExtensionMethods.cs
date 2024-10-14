using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF
{
    public static class ExtensionMethods
    {
        const string connectionName = "Default";
        private static SqlConnection _connection
        {
            get
            {
                return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            }
        }
        public static Tuple<SqlParameter[], string> ExecuParamsSqlOrStored(this string command, bool isSql = false, params KeyValuePair<string, object>[] arr)
        {
            SqlParameter[] retarrr = new SqlParameter[arr.Length];
            command += " ";
            for (int i = 0; i < arr.Length; i++)
            {
                bool allowNull = false;
                var val = arr[i].Value;
                if (arr[i].Value == null)
                {
                    allowNull = true;
                    val = DBNull.Value;
                }
                retarrr[i] = new SqlParameter(arr[i].Key, val);
                retarrr[i].IsNullable = allowNull;
                if (!isSql)
                {
                    command += ((i == arr.Length - 1) ? "@" + arr[i].Key + "" : "@" + arr[i].Key + " , ");
                }
            }
            return new Tuple<SqlParameter[], string>(retarrr, command);
        }

        public static int AsNonQuery(this Tuple<SqlParameter[], string> procedureData)
        {
            var _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(procedureData.Item2, _connection);
            cmd.Parameters.AddRange(procedureData.Item1);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result;
        }

        public static DataTable AsDataTable(this Tuple<SqlParameter[], string> procedureData)
        {
            var _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(procedureData.Item2, _connection);
            cmd.Parameters.AddRange(procedureData.Item1);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();
                table.Load(reader);
                _connection.Close();
                return table;
            }
        }

        public static List<T> AsList<T>(this DataTable dt)
        {
            List<T> list = new List<T>();
            PropertyInfo[] fields = typeof(T).GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (PropertyInfo fi in fields)
                {
                    if (fi.PropertyType != typeof(string) && dr[fi.Name].ToString() == "")
                    {
                        fi.SetValue(t, (null));
                    }
                    else
                    {
                        fi.SetValue(t, (dr[fi.Name].ToString() == "" ? string.Empty : dr[fi.Name]));
                    }
                }
                list.Add(t);
            }
            return list;
        }

        public static List<T> AsList<T>(this Tuple<SqlParameter[], string> procedureData)
        {
            return procedureData.AsDataTable().AsList<T>();
        }

        public static object AsScalar(this Tuple<SqlParameter[], string> procedureData)
        {
            var _connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            _connection.Open();
            SqlCommand cmd = new SqlCommand(procedureData.Item2, _connection);
            cmd.Parameters.AddRange(procedureData.Item1);
            object result = cmd.ExecuteScalar();
            _connection.Close();
            return result;
        }

        public static KeyValuePair<string, object> KVP(this string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }
    }
}
