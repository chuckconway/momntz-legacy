using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Momntz.Worker.Core.Implementations.Media.MediaTypes
{
    public interface IMedia
    {
        MediaType Media { get; }

        void Process(MediaItem message);
    }
}
