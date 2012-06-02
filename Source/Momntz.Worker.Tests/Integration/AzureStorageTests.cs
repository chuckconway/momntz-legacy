using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Momntz.Worker.Core;
using NUnit.Framework;

namespace Momntz.Worker.Tests.Integration
{
    [TestFixture]
    public class AzureStorageTests
    {
        [Test]
        public void Bucket_Create_BucketIsCreatedSuccessfully()
        {
            IStorage storage = new AzureStorage();
            string name = "img"; //Path.GetRandomFileName();
            storage.CreateBucket(name);
        }

        [Test]
        public void File_AddFile_FileIsAddedSuccessfully()
        {
            IStorage storage = new AzureStorage();
            storage.AddFile("img", Path.GetRandomFileName(), "image/jpg", new byte[128]);
        }
        
    }
}
