using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;
using System.Configuration;

namespace HandleStorage
{
    public class TableClass
    {
        public static void TableMain()
        {
            //InsertRecords();

            //GettingRecords();

            //UpdateRecord();
            ListTables();

            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static void GettingRecords()
        {
            var table = GetCloudTable();

            TableQuery<OrderEntity> query = new TableQuery<OrderEntity>().Where(
                TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Lana"));

            foreach (OrderEntity entity in table.ExecuteQuery(query))
            {
                Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey, entity.Status, entity.ShippedDate);
            }
        }

        private static CloudTableClient GetTableClient()
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            return tableClient;
        }
        private static CloudTable GetCloudTable()
        {
            var tableClient = GetTableClient();

            CloudTable table = tableClient.GetTableReference("customers");
            table.CreateIfNotExists();

            return table;
        }

        private static void InsertRecord()
        {
            var table = GetCloudTable();

            OrderEntity newOrder = new OrderEntity("Archer", "20141216");
            newOrder.OrderNumber = "101";
            newOrder.ShippedDate = Convert.ToDateTime("03/08/2008");
            newOrder.RequiredDate = Convert.ToDateTime("05/04/2009");
            newOrder.Status = "shipped";

            TableOperation insertOperation = TableOperation.Insert(newOrder);
            table.Execute(insertOperation);



        }
        private static void InsertRecords()
        {
            var table = GetCloudTable();
            TableBatchOperation batchOperation = new TableBatchOperation();

            OrderEntity newOrder1 = new OrderEntity("Lana", "20141223");
            newOrder1.OrderNumber = "102";
            newOrder1.ShippedDate = Convert.ToDateTime("03/08/2008");
            newOrder1.RequiredDate = Convert.ToDateTime("05/04/2009");
            newOrder1.Status = "pending";

            OrderEntity newOrder2 = new OrderEntity("Pam", "20141201");
            newOrder2.OrderNumber = "103";
            newOrder2.ShippedDate = Convert.ToDateTime("03/08/2008");
            newOrder2.RequiredDate = Convert.ToDateTime("05/04/2009");
            newOrder2.Status = "open";

            OrderEntity newOrder3 = new OrderEntity("Lana", "20141224");
            newOrder3.OrderNumber = "104";
            newOrder3.ShippedDate = Convert.ToDateTime("03/08/2008");
            newOrder3.RequiredDate = Convert.ToDateTime("05/04/2009");
            newOrder3.Status = "shipped";

            batchOperation.Insert(newOrder1);
            batchOperation.Insert(newOrder2);
            batchOperation.Insert(newOrder3);

            table.ExecuteBatch(batchOperation);





        }

        private static void UpdateRecord()
        {
            var table = GetCloudTable();

            TableOperation retrieveOperation = TableOperation.Retrieve<OrderEntity>("Lana", "20141222");
            TableResult retrivedResult = table.Execute(retrieveOperation);
            OrderEntity updateEntity = (OrderEntity)retrivedResult.Result;

            if(updateEntity != null)
            {
                updateEntity.Status = "MyNewStatus";
                updateEntity.ShippedDate = Convert.ToDateTime("03/08/2009");
                TableOperation insertOrReplaceOperation = TableOperation.InsertOrReplace(updateEntity);
                table.Execute(insertOrReplaceOperation);
            }
        }


        private static void ListTables()
        {
            var tableClient = GetTableClient();

            IEnumerable<CloudTable> tables = tableClient.ListTables();

            List<CloudTable> listTable = tables.ToList();

            foreach (CloudTable table in tables)
            {

                //table.DehleteIfExists();
            }
        }
    }
}
