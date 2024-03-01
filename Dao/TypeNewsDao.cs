using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews.Dao
{
    public class TypeNewsDao
    {
        public int Id { get; set; }
        public string TypeNews { get; set; }

        public string CurrentTypeNews { get; set; }

        public TypeNewsDao () { }
        public TypeNewsDao (int id, string typeNews, string currentTypeNews)
        {
            Id = id;
            TypeNews = typeNews;
            CurrentTypeNews = currentTypeNews;
        }
    }
}