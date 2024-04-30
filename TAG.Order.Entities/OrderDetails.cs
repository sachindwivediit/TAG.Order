using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG.Order.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; } = 100;
        public string ProductName { get; set; } = "Test";
        public string CreatedBy { get; set; } = "SachinDwivedi";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
