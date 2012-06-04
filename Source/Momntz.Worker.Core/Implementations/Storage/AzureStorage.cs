using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace Momntz.Worker.Core.Implementations.Storage
{
    public class AzureStorage : IStorage
    {
 
        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private CloudBlobContainer GetProvider(string name)
        {
            string cloudUrl = ConfigurationManager.AppSettings["cloudurl"]; //_configurationService.GetValueByKey("cloudUrl");
            string cloudAccount = ConfigurationManager.AppSettings["cloudaccount"];  //_configurationService.GetValueByKey("cloudAccount");
            string cloudKey = ConfigurationManager.AppSettings["cloudkey"];

            CheckForConfigurationValue(cloudUrl, "Cloud Url was not provided. Expected configuration appSettings key of 'cloudUrl'");
            CheckForConfigurationValue(cloudAccount, "Cloud Account was not provided. Expected configuration appSettings key of 'cloudAccount'");
            CheckForConfigurationValue(cloudKey, "Cloud Key was not provided. Expected configuration appSettings key of 'cloudKey'");

            CloudBlobContainer container = new CloudBlobContainer(name, new CloudBlobClient(cloudUrl, new StorageCredentialsAccountAndKey(cloudAccount, cloudKey)));
            return container;
        }

        /// <summary>
        /// Checks for configuration value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message.</param>
        public void CheckForConfigurationValue(string value, string errorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentOutOfRangeException(errorMessage);
            }
        }

        /// <summary>
        /// Creates the bucket.
        /// </summary>
        /// <param name="name">The name.</param>
        public void CreateBucket(string name)
        {
            CloudBlobContainer container = GetProvider(name);
            BlobContainerPermissions permissions = new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            };
            container.CreateIfNotExist();
            container.SetPermissions(permissions);
        }

        /// <summary>
        /// Adds the file.
        /// </summary>
        /// <param name="bucketName">Name of the bucket.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="file">The file.</param>
        public void AddFile(string bucketName, string keyName, string contentType, byte[] file)
        {
            var blob = Popuate(bucketName, keyName, contentType);
            blob.UploadByteArray(file);
        }

        private CloudBlob Popuate(string bucketName, string keyName, string contentType)
        {
            CloudBlob blob = GetBlob(bucketName, keyName);
            blob.Properties.ContentType = contentType;

            // Create some metadata for this image
            var metadata = new NameValueCollection();
            metadata["Filename"] = keyName;
            metadata["ImageName"] = String.IsNullOrEmpty(keyName) ? "unknown" : keyName;
            metadata["Description"] = String.IsNullOrEmpty("description") ? "unknown" : "description";
            blob.Metadata.Add(metadata);
            return blob;
        }

        public void AddFile(string bucketName, string keyName, string contentType, Stream stream)
        {
            var blob = Popuate(bucketName, keyName, contentType);
            blob.UploadFromStream(stream);
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="bucketName">Name of the bucket.</param>
        /// <param name="keyName">Name of the key.</param>
        public void DeleteFile(string bucketName, string keyName)
        {
            CloudBlob blob = GetBlob(bucketName, keyName);
            blob.DeleteIfExists();
        }

        /// <summary>
        /// Deletes the bucket.
        /// </summary>
        /// <param name="bucketName">Name of the bucket.</param>
        public void DeleteBucket(string bucketName)
        {
            //AzureBlobContainer container = GetProvider(bucketName);
            //container.DeleteIfExists();
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="bucketName"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public byte[] GetFile(string bucketName, string keyName)
        {
            CloudBlob blob = GetBlob(bucketName, keyName);
            return blob.DownloadByteArray();
        }

        /// <summary>
        /// Gets the BLOB.
        /// </summary>
        /// <param name="bucketName">Name of the bucket.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        private CloudBlob GetBlob(string bucketName, string keyName)
        {
            CloudBlobContainer container = GetProvider(bucketName);
            return container.GetBlobReference(keyName);
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="bucketName">Name of the bucket.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <returns></returns>
        public string GetUrl(string bucketName, string keyName)
        {
            throw new NotImplementedException();
        }
    }
}
