using BloggerNews.Dao;
using BloggerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews.Service
{
    public class TypeNewsService
    {
        private ConnectionWithDatabaseDataContext db = new ConnectionWithDatabaseDataContext();

        public List<TypeNewsDao> GetAllTypeNews ()
        {
            var ListTypeNews = db.TypeNews.ToList();
            List<TypeNewsDao> ListTypeNewsDao = new List<TypeNewsDao>();
            ListTypeNews.ForEach(item =>
            {
                ListTypeNewsDao.Add(new TypeNewsDao(item.Id, item.TypeNewsDescription, item.CurrentTypeNew.CurrentTypeNewsDescription));
            });
            return ListTypeNewsDao;
        }

        public TypeNewsDao GetTypeNewsByDescription (string Description)
        {
            var TypeNews = db.TypeNews.FirstOrDefault(x => x.TypeNewsDescription == Description);
            if (TypeNews != null)
            {
                return new TypeNewsDao(TypeNews.Id, TypeNews.TypeNewsDescription, TypeNews.CurrentTypeNew.CurrentTypeNewsDescription);
            }
            return null;
        }

        public TypeNew GetTypeNewById (int id)
        {
            return db.TypeNews.FirstOrDefault(x => x.Id == id);
        }

        public TypeNew CreateTypeNew (string TypeNewsDescription, int CurrentTypeNewsId)
        {
            TypeNew NewTypeNews = new TypeNew();
            NewTypeNews.TypeNewsDescription = TypeNewsDescription;
            NewTypeNews.CurrentTypeNewsId = CurrentTypeNewsId;
            db.TypeNews.InsertOnSubmit(NewTypeNews);
            db.SubmitChanges();
            return NewTypeNews;
        }


        public TypeNew GetTypeNewByTypeNewsDescription (string TypeNewsDescription)
        {
            return db.TypeNews.FirstOrDefault(x => x.TypeNewsDescription == TypeNewsDescription);
        }
        public void UpdateTypeNews (TypeNew TypeNew)
        {
            TypeNew TypeNewRq = GetTypeNewById(TypeNew.Id);
            if (TypeNewRq != null)
            {
                TypeNewRq.TypeNewsDescription = TypeNew.TypeNewsDescription;
                TypeNewRq.CurrentTypeNewsId = TypeNew.CurrentTypeNewsId;
                db.SubmitChanges();
            }
        }
    }
}