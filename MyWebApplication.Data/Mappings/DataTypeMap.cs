using Dapper.FluentMap.Mapping;
using MyWebApplication.Models;

namespace MyWebApplication.Data.Mappings
{
    public class DataTypeMap : EntityMap<MyDataType>
    {
        public DataTypeMap()
        {
            Map(c => c.Int1).ToColumn("col_int1");
            Map(c => c.Int2).ToColumn("col_int2");
            Map(c => c.Int3).ToColumn("col_int3");
            Map(c => c.Str1).ToColumn("col_str1");
            Map(c => c.Str2).ToColumn("col_str2");
            Map(c => c.Str3).ToColumn("col_str3");
            Map(c => c.Date1).ToColumn("col_date1");
            Map(c => c.Date2).ToColumn("col_date2");
            Map(c => c.Date3).ToColumn("col_date3");
        }
    }
}
