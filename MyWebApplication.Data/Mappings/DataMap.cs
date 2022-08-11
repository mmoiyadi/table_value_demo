using Dapper.FluentMap.Mapping;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Mappings
{
    public class DataMap : EntityMap<DataModel>
    {
        public DataMap()
        {
            Map(c => c.Id).ToColumn("Id");
            Map(c => c.CreatedDate).ToColumn("CreatedDate");
            Map(c => c.Name).ToColumn("Name");
            Map(c => c.Description).ToColumn("Description");
            Map(c => c.IsPublished).ToColumn("IsPublished");
        }
    
    }
    
}
