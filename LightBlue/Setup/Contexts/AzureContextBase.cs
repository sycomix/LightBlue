﻿using System;

using LightBlue.Hosted;

using Microsoft.WindowsAzure.Storage.Auth;

namespace LightBlue.Setup.Contexts
{
    abstract class AzureContextBase : ILightBlueContext
    {
        private readonly AzureEnvironment _azureEnvironment;

        protected AzureContextBase(AzureEnvironment azureEnvironment)
        {
            _azureEnvironment = azureEnvironment;
        }

        public abstract string RoleName { get; }
        public abstract IAzureSettings Settings { get; }

        public AzureEnvironment AzureEnvironment
        {
            get { return _azureEnvironment; }
        }

        public IAzureStorage GetStorageAccount(string connectionString)
        {
            return new HostedAzureStorage(connectionString);
        }

        public IAzureBlobContainer GetBlobContainer(Uri containerUri)
        {
            return new HostedAzureBlobContainer(containerUri);
        }

        public IAzureBlobContainer GetBlobContainer(Uri containerUri, StorageCredentials storageCredentials)
        {
            return new HostedAzureBlobContainer(containerUri, storageCredentials);
        }

        public IAzureBlockBlob GetBlockBlob(Uri blobUri)
        {
            return new HostedAzureBlockBlob(blobUri);
        }

        public IAzureBlockBlob GetBlockBlob(Uri blobUri, StorageCredentials storageCredentials)
        {
            return new HostedAzureBlockBlob(blobUri, storageCredentials);
        }

        public IAzureQueue GetQueue(Uri queueUri)
        {
            return new HostedAzureQueue(queueUri);
        }
    }
}