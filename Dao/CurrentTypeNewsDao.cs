using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews.Dao
{
    public class CurrentTypeNewsDao
    {
        public int Id { get; set; }
        public string CurrentTypeNewsDescription { get; set; }
        public List<TypeNewsDao> ListSubTypeNews { get; set; }
        public CurrentTypeNewsDao () { }
        public CurrentTypeNewsDao (int id, string currentTypeNewsDescription, List<TypeNewsDao> listSubTypeNews)
        {
            Id = id;
            CurrentTypeNewsDescription = currentTypeNewsDescription;
            ListSubTypeNews = listSubTypeNews;
        }
    }
}