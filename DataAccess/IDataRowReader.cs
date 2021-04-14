using System;

namespace DataAccess
{
    public interface IDataRowReader
    {
        bool Read();
        byte GetByte(string name);
        DateTimeOffset GetDateTimeOffset(string name);
        DateTimeOffset? GetNullableDateTimeOffset(string name);
        DateTime GetDateTime(string name);
        DateTime? GetNullableDateTime(string name);
        int GetInt32(string name);
        int? GetNullableInt32(string name);

        string GetString(string name);
        string GetNullableString(string name);
        T GetValue<T>(string name);
    }
}