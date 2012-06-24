using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure;
using Momntz.Model.Configuration;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Users.Handlers.Index
{
    public class GetMomentosUserPageHandler : HandlerBase, IQueryHandler<string, List<MomentoWithMedia>>
    {
        private readonly IProjectionProcessor _processor;
        private readonly ISettings _settings;

        public GetMomentosUserPageHandler(IProjectionProcessor processor, ISettings settings)
        {
            _processor = processor;
            _settings = settings;
        }

        public List<MomentoWithMedia> Handle(string args)
        {
            return _processor.Process<string, List<MomentoWithMedia>>(args);
        }
    }
}