using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashSneaker.BlobServices
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public BlobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }

        public Task<IEnumerable<string>> AllBlobs(string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(name);

            return await blobClient.DeleteIfExistsAsync();
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            // this will allow us access to the storage container
            var containerClient = _blobClient.GetBlobContainerClient(containerName);

            // this will allow us access to the files inside the container via the file name
            var blobClient = containerClient.GetBlobClient(name);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            var containerClient = _blobClient.GetBlobContainerClient(containerName);

            // check if the file exist or not
            // if the file exist it will be replaced
            // else it will create a temp space until its uploaded
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if(result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
