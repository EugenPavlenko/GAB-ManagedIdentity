using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;

namespace GAB_ManagedIdentity.StorageProvider
{
    public interface IBlobStorageProvider
    {
        Task<List<string>> GetContainersListAsync();
        Task<List<string>> GetBlobsInContainerAsync(string containerName);
        Task<Response<BlobDownloadInfo>> GetBlobContentAsync(string containerName, string blobName);
    }
}