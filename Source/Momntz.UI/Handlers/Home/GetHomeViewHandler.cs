using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Infrastructure;
using Momntz.Model.Configuration;
using Momntz.UI.Core;

namespace Momntz.UI.Handlers.Home
{
    public class GetHomeViewHandler : HandlerBase, IQueryHandler<object, IList<HomepageMomento>>
    {
        private readonly IProjectionProcessor _processor;
        private readonly ISettings _settings;

        public GetHomeViewHandler(IProjectionProcessor processor, ISettings settings)
        {
            _processor = processor;
            _settings = settings;
        }

        public IList<HomepageMomento> Handle(object args)
        {
            var items = _processor.Process<object, IList<HomepageMomento>>(args);
            string rootUrl = _settings.CloudUrl;

            foreach (var item in items)
            {
                item.Media.Url = string.Format("{0}/{1}", rootUrl, item.Media.Url);
            }

            return items;
        }
    }
}