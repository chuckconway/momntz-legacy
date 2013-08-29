using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Momntz.Messaging.Models;

namespace Momntz.Media
{
    public interface IMediaSaga
    {
        void Consume(MediaMessage message);
    }
}
