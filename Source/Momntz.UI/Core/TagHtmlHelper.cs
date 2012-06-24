using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Momntz.Model;

namespace Momntz.UI.Core
{
    public static class TagHtmlHelper
    {
        public static MvcHtmlString RenderTags(this List<Tag> tags, string username)
        {
            List<string> tgs = tags.Where(t => t.Kind == KindOfTag.Tag)
                .Select(tag => string.Format("<a href=\"/{0}/Tag/{1}\" title=\"View all momentos in {1}\" rel=\"category tag\">{1}</a>", username, tag.Name))
                .ToList();

            return new MvcHtmlString(string.Join(",", tgs));
        }
    }
}