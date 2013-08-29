using System.Collections.Generic;
using Momntz.Data.Projections;
using Momntz.Infrastructure.Configuration;

namespace Momntz.Data.ProjectionHandlers
{
    public class BaseGroupItem
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings">The settings.</param>
        /// <param name="items">The items.</param>
        /// <returns>List{IGroupItem}.</returns>
        public List<IGroupItem> GetItems<T>(ISettings settings, List<T> items) where T: IGroupItem
        {
            var rootUrl = settings.CloudUrl;
            var results = new List<IGroupItem>(); 

            foreach (var result in items)
            {
                result.Url = string.Format("{0}/{1}", rootUrl, result.Url);
                results.Add(result);
            }

            return results;
        }
    }
}
