using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Models
{
    public class InputData
    {
        public string Name { get; set; }
        public int  MonthId { get; set; }
    }

    public class InputDataBetween
    {
        public int Month1Id { get; set; }
        public int Month2Id { get; set; }
    }
}
