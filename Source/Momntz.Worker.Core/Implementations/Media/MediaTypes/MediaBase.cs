using System;
using System.IO;
using Momntz.Worker.Core.Storage;

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
    }
}
