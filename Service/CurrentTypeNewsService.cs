using BloggerNews.Dao;
using BloggerNews.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews.Service
{
    public class CurrentTypeNewsService
    {
        private ConnectionWithDatabaseDataContext db = new ConnectionWithDatabaseDataContext();
        public List<CurrentTypeNewsDao> GetAllListCurrentTypeNewsByCurrentTypeNewsDescription (string CurrentTypeNewsDescription)
        {
            List<CurrentTypeNew> ListCurrentTypeNewsDb = null;

            if (CurrentTypeNewsDescription == "All")
            {
                ListCurrentTypeNewsDb = db.CurrentTypeNews.ToList();
            }
            else
            {
                ListCurrentTypeNewsDb = db.CurrentTypeNews.Where(x => x.CurrentTypeNewsDescription.Equals(CurrentTypeNewsDescription)).ToList();
            }

            List<CurrentTypeNewsDao> ListCurrentTypeNewsDao = new List<CurrentTypeNewsDao>();

            ListCurrentTypeNewsDb.ForEach(x =>
            {
                List<TypeNewsDao> ListTypeNewsDao = new List<TypeNewsDao>();
                x.TypeNews.ForEach(y =>
                {
                    ListTypeNewsDao.Add(new TypeNewsDao(y.Id, y.TypeNewsDescription, y.TypeNewsDescription));
                });
                ListCurrentTypeNewsDao.Add(new CurrentTypeNewsDao(x.Id, x.CurrentTypeNewsDescription, ListTypeNewsDao));
            });
            return ListCurrentTypeNewsDao;
        }

        public CurrentTypeNewsDao GetCurrentTypeNewByCurrentTypeNewsDescription (string Description)
        {
            var x = db.CurrentTypeNews.FirstOrDefault(i => i.CurrentTypeNewsDescription == Description);
            if (x != null)
            {
                List<TypeNewsDao> ListTypeNewsDao = new List<TypeNewsDao>();
                x.TypeNews.ForEach(y =>
                {
                    ListTypeNewsDao.Add(new TypeNewsDao(y.Id, y.TypeNewsDescription, y.TypeNewsDescription));
                });
                return new CurrentTypeNewsDao(x.Id, x.CurrentTypeNewsDescription, ListTypeNewsDao);
            }
            return null;
        }
    }
}