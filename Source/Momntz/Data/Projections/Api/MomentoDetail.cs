using System;
using System.Collections.Generic;
using Hypersonic.Attributes;
using Momntz.Model;

namespace Momntz.Data.Projections.Api
{
    public class MomentoDetail
    {
        public string Title { get; set; }

        public string Story { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public string Location { get; set; }

        public DateTime Added { get; set; }

        public string Username { get; set; }

        public string AddedUsername { get; set; }

        public string DisplayName { get; set; }
        
        [Ignore]
        public List<People> People { get; set; }

        [Ignore]
        public TagCollection Albums { get; set; }
    }

    public class People
    {
        public String DisplayName { get; set; }

        public string Username { get; set; }
    }
}
