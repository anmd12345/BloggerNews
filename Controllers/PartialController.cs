using BloggerNews.Dao;
using BloggerNews.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloggerNews.Controllers
{
    public class PartialController : Controller
    {
        private NewsService newsService = new NewsService();
        private TypeNewsService typeNewsService = new TypeNewsService();
        private CurrentTypeNewsService CurrentTypeNewsService = new CurrentTypeNewsService();

        // GET: Partial
        public ActionResult ScriptPartial ()
        {
            return PartialView();
        }

        public ActionResult LinkPartial ()
        {
            return PartialView();
        }

        public ActionResult MetaPartial ()
        {
            return PartialView();
        }

        public ActionResult FooterPartial ()
        {
            List<TypeNewsDao> ListTypeNews = typeNewsService.GetAllTypeNews();
            ViewBag.ListTypeNews = ListTypeNews;
            ViewVisits();
            return PartialView();
        }

        public ActionResult MenuPartial ()
        {
            List<CurrentTypeNewsDao> ListCurrentTypeNewsDao = CurrentTypeNewsService.GetAllListCurrentTypeNewsByCurrentTypeNewsDescription("All");
            ViewBag.ListCurrentTypeNewsDao = ListCurrentTypeNewsDao;
            return PartialView();
        }

        public ActionResult FeedPartial ()
        {
            List<NewsDao> ListNewsFeed = newsService.GetListNewsByCountAndConditionIsOrderByDescendingCountView(10);
            ViewBag.ListNewsFeed = ListNewsFeed;
            return PartialView();
        }

        public void ViewVisits ()
        {
            string filePath = Server.MapPath("~/Views/Hits.txt");
            if (System.IO.File.Exists(filePath))
            {
                string content = System.IO.File.ReadAllText(filePath);
                ViewBag.Visits = int.Parse(content).ToString("N0");
            }
        }
    }
}