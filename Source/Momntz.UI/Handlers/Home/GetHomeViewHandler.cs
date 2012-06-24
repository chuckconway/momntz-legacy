using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure;
using Momntz.UI.Core;

namespace Momntz.UI.Handlers.Home
{
    public class GetHomeViewHandler : HandlerBase, IQueryHandler<object, IList<MomentoWithMedia>>
    {
        private readonly IProjectionProcessor _processor;

        public GetHomeViewHandler(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        public IList<MomentoWithMedia> Handle(object args)
        {
            return _processor.Process<object, IList<MomentoWithMedia>>(args);
        }
    }
}