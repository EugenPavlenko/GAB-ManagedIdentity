using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GAB_ManagedIdentity.StorageProvider
{
    public class BlobStorageProvider : IBlobStorageProvider
    {
        private readonly BlobServiceClient client;
        public BlobStorageProvider(IWebHostEnvironment env, IConfiguration Configuration)
        {
            string connectionString = Configuration.GetConnectionString("StorageAccount");
            if (env.IsProduction())
            {
                client = new BlobServiceClient(new Uri(connectionString), new DefaultAzureCredential());
            }
            else
            {
                client = new BlobServiceClient(connectionString);
            }
        }

        public async Task<List<string>> GetContainersListAsync()
        {
            var result = new List<string>();
            await foreach (var containerItem in client.GetBlobContainersAsync())
            {
                result.Add(containerItem.Name);
            }
            return result;
        }

        public async Task<List<string>> GetBlobsInContainerAsync(string containerName)
        {
            var result = new List<string>();
            var blobContainerClient = client.GetBlobContainerClient(containerName);
            await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
            {
                result.Add(blobItem.Name);
            }
            return result;
        }

        public async Task<Response<BlobDownloadInfo>> GetBlobContentAsync(string containerName, string blobName)
        {
            var blobContainerClient = client.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);
            return await blobClient.DownloadAsync();
        }

    }
}