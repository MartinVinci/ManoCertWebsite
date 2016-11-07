using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;

namespace HandleStorage
{
    public class BlobClass
    {
        public static void BlobMain()
        {
            //UploadBlob();
            //ListBlobs();
            //SetMetadata();
            ReadMetadata();
            Console.ReadLine();

        }
        private static void UploadBlob()
        {
            CloudBlobContainer container = GetContainer("files");
            container.CreateIfNotExists();

            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });

            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblobtwo");
            using (var fileStream = System.IO.File.OpenRead(@"C:\InFiles\mickey.jpg"))
            {
                blockBlob.UploadFromStream(fileStream);
            }
        }

        private static void ListBlobs()
        {
            CloudBlobContainer container = GetContainer("files");

            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);


                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory direcotry = (CloudBlobDirectory)item;
                    Console.WriteLine("Directory: {0}", direcotry.Uri);
                }
            }


        }
        private static CloudBlobContainer GetContainer(string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            return blobClient.GetContainerReference(containerName);
        }
        private static void SetMetadata()
        {
            CloudBlobContainer container = GetContainer("files");
            container.FetchAttributes();
            //Add some metadata to the container.
            container.Metadata.Add("docType", "myImage");
            container.Metadata["mycategory"] = "guidance";

            //Set the container's metadata.
            container.SetMetadata();


            container.Metadata["asdf"] = "100";
            container.SetMetadata();

        }
        private static void ReadMetadata()
        {
            var container = GetContainer("files");

            container.FetchAttributes();
            Console.WriteLine("counter value: " + container.Metadata["asdf"]);


        }

    }
}
