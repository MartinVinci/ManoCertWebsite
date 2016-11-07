using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace HandleStorage
{
    public class OrderEntity : TableEntity
    {
        public OrderEntity() { }
        public string OrderNumber { get; set; }
        public DateTime RequiredDate  { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }

        public OrderEntity(string customerName, string orderDate)
        {
            this.PartitionKey = customerName;
            this.RowKey = orderDate;
        }

    }
}
