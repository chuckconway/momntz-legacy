using System;
using System.IO;
using Chucksoft.Storage;


namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public abstract class MediaBase
    {
        private readonly IStorage _storage;

        protected MediaBase(IStorage storage)
        {
            _storage = storage;
        }

        protected void AddToStorage(string storageContainer, string contenType, MediaItem item)
        {
            string type = item.Extension.TrimStart('.');
            string name = string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(item.Filename), DateTime.Now.Ticks, item.Extension);

            _storage.AddFile(storageContainer, name, string.Format("{0}/{1}", contenType, type), item.Bytes);
        }

        //private byte[] HexToBinary(string hex)
        //{
        //    Convert.FromBase64String(hex);
        //    //string binaryval = Convert.ToString(Convert.ToInt64(hex, 16), 2);

        //}
    }
}
