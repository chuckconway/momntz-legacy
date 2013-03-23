using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Momntz.UI.Areas.Api.Models
{
    public class AutoComplete
    {
        public AutoComplete(string r)
        {
            label = r;
            value = r;
        }

        public string label { get; set; }

        public string value { get; set; }
    }
}