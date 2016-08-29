using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorld.Models
{
    public class PopularMovies
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public string title { get; set; }
            public int year { get; set; }
            public Ids ids { get; set; }
        }

        public class Ids
        {
            public int trakt { get; set; }
            public string slug { get; set; }
            public string imdb { get; set; }
            public int tmdb { get; set; }
        }

    }
}