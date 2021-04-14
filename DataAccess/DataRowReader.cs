using System;
using System.Data.SqlClient;

namespace DataAccess
{
    /// <summary>
    /// Simple wrapper class for more concise code by the callers.
    /// Other "getters" supported by <see cref="SqlDataReader"/> can easily be added.
    /// </summary>
    internal class DataRowReader : IDataRowReader
    {
        private readonly SqlDataReader reader;

        public DataRowReader(SqlDataReader reader)
        {
            this.reader = reader;
        }

        public bool Read()
        {
            return reader.Read();
        }

        public int GetInt32(string name)
        {
            return GetValue(name, reader.GetInt32);
        }

        public int? GetNullableInt32(string name)
        {
            int col = reader.GetOrdinal(name);
            if (reader.IsDBNull(col)) return null;
            else return GetInt32(name);
        }

        public byte GetByte(string name)
        {
            return GetValue(name, reader.GetByte);
        }

        public bool GetBoolean(string name)
        {
            return GetValue(name, reader.GetBoolean);
        }

        public string GetString(string name)
        {
            return GetValue(name, reader.GetString);
        }

        public string GetNullableString(string name)
        {
            int col = reader.GetOrdinal(name);
            if (reader.IsDBNull(col)) return null;
            else return GetString(name);
        }

        public DateTimeOffset GetDateTimeOffset(string name)
        {
            return GetValue(name, reader.GetDateTimeOffset);
        }
        public DateTimeOffset? GetNullableDateTimeOffset(string name)
        {
            int col = reader.GetOrdinal(name);
            if (reader.IsDBNull(col)) return null;
            else return GetDateTimeOffset(name);
        }
        public DateTime GetDateTime(string name)
        {
            return GetValue(name, reader.GetDateTime);
        }

        public DateTime? GetNullableDateTime(string name)
        {
            int col = reader.GetOrdinal(name);
            if (reader.IsDBNull(col)) return null;
            else return GetDateTime(name);
        }
        public T GetValue<T>(string name)
        {
            return (T)reader.GetValue(reader.GetOrdinal(name));
        }

        public T GetValue<T>(string name, Func<int, T> getter)
        {
            try
            {
                return getter(reader.GetOrdinal(name));
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ColumnNotFoundException(name, ex);
            }
        }


    }
}