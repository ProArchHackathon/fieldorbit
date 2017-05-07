using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace ProArch.FieldOrbit.BusinessLayer.Streaming
{
    public static class ContentService
    {
        const string blobContainerName = "BlobContainerName";
        const string connectionString = "StorageConnectionString";

        private static CloudBlobContainer GetContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(connectionString));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(CloudConfigurationManager.GetSetting(blobContainerName));
            blobContainer.CreateIfNotExistsAsync();
            return blobContainer;
        }

        public static string GetVideoPath(string filename)
        {
            CloudBlobContainer blobContainer = GetContainer();

            blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            var blob = blobContainer.GetBlockBlobReference(filename);

            return blob.Uri.AbsoluteUri;
        }

        public static async Task<bool> UploadFiles(HttpFileCollectionBase files)
        {
            int fileCount = files.Count;
            CloudBlobContainer blobContainer = GetContainer();

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            if (blobContainer.Exists() && fileCount > 0)
            {
                for (int i = 0; i < fileCount; i++)
                {
                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(files[i].FileName);
                    if (blob != null)
                    {
                        var blobUrl = blob.Uri.AbsoluteUri;
                        blob.Properties.ContentType = files[i].ContentType;
                        blob.UploadFromStream(files[i].InputStream);
                    }
                }
                return true;
            }
            return false;
        }

        //public async Task GetVideoContent(string filename)
        //{
        //    CloudBlobContainer blobContainer = GetContainer();

        //    await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        //    //var blob = blobContainer.GetBlockBlobReference(filename);
        //    //await blob.

        //    List<Uri> allBlobs = new List<Uri>();
        //    foreach (IListBlobItem blob in blobContainer.ListBlobs())
        //    {
        //        if (blob.GetType() == typeof(CloudBlockBlob))
        //            allBlobs.Add(blob.Uri);
        //    }
        //}

        //public async Task<List<Uri>> GetAllBlobs()
        //{
        //    CloudBlobContainer blobContainer = GetContainer();

        //    await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

        //    List<Uri> allBlobs = new List<Uri>();
        //    foreach (IListBlobItem blob in blobContainer.ListBlobs())
        //    {
        //        if (blob.GetType() == typeof(CloudBlockBlob))
        //            allBlobs.Add(blob.Uri);
        //    }
        //    return allBlobs;
        //}
    }
}
