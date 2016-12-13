using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;

namespace HandleStorage
{
    public class QueueClass
    {
        private static string WORKERQUEUE = "workerqueue";
        private static string TESTQUEUE = "testqueue";
        private static string WEBJOBQUEUE = "webjobqueue";
        private static string FILEPROCCESSING = "fileprocessing";


        public static void QueueMain()
        {
            //AddMessages2();
            //ProcessMessages();

            ProcessBatchMessages();

            //Console.WriteLine("");
            //Console.WriteLine("-----------------");
            //Console.WriteLine("");

            //ProcessBatchMessages();


            Console.ReadLine();

        }

        private static void ProcessBatchMessages()
        {
            var queue = GetCloudQueue(FILEPROCCESSING);

            IEnumerable<CloudQueueMessage> batch = queue.GetMessages(10, new TimeSpan(0, 0, 5));

            queue.FetchAttributes();

            Console.WriteLine(queue.ApproximateMessageCount.ToString());

            foreach (CloudQueueMessage batchMessage in batch)
            {
                if (batchMessage.AsString.ToString().StartsWith("START"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (batchMessage.AsString.ToString().StartsWith("STOP"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(batchMessage.AsString);
                Console.ForegroundColor = ConsoleColor.Gray;
            }


        }

        private static void ProcessMessages()
        {
            var queue = GetCloudQueue(FILEPROCCESSING);
            queue.FetchAttributes();

            int? count = queue.ApproximateMessageCount;


            CloudQueueMessage message = queue.GetMessage(new TimeSpan(0, 0, 10));

            if(message != null)
            {
                string theMessage = message.AsString;
                Console.WriteLine(theMessage);
            }

            CloudQueueMessage message2 = queue.GetMessage(new TimeSpan(0, 0, 30));

            if (message2 != null)
            {
                string theMessage = message2.AsString;
                Console.WriteLine(theMessage);

            }

        }

        private static CloudQueue GetCloudQueue(string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();

            queue.FetchAttributes();
            return queue;
        }

        private static void AddMessages()
        {
            var queue = GetCloudQueue(TESTQUEUE);

            queue.AddMessage(new CloudQueueMessage("Queued super message 1"));
            queue.AddMessage(new CloudQueueMessage("Queued super message 2"));
            queue.AddMessage(new CloudQueueMessage("Queued super message 3"));
            queue.AddMessage(new CloudQueueMessage("Queued super message 4"));
            queue.AddMessage(new CloudQueueMessage("Queued super message 5"));
            queue.AddMessage(new CloudQueueMessage("Queued super message 6"));

        }
        private static void AddMessages2()
        {
            var queue = GetCloudQueue(TESTQUEUE);

            

        }

    }
}
