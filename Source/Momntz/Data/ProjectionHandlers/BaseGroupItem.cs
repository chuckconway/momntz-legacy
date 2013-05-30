using System.Collections.Generic;
using Momntz.Data.Projections;
using Momntz.Infrastructure.Configuration;

namespace Momntz.Data.ProjectionHandlers
{
    public class BaseGroupItem
    {
        public List<IGroupItem> GetItems<T>(ISettings settings, List<T> items) where T: IGroupItem
        {
            string rootUrl = settings.CloudUrl;

            List<IGroupItem> results = new List<IGroupItem>(); 

            foreach (var result in items)
            {
                result.Url = string.Format("{0}/{1}", rootUrl, result.Url);
                results.Add(result);
            }

            return results;
        }
    }
}
