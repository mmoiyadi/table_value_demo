using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.API.ViewModels
{
    public class DataViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
