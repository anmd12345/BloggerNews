using BloggerNews.dao;
using BloggerNews.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace BloggerNews.Controllers
{
    public class HomeController : Controller
    {
        private NewsService newsService = new NewsService();
        private TypeNewsService typeNewsService = new TypeNewsService();

        public ActionResult Index ()
        {
            return Redirect("/trang-chu");
        }

        [HttpGet]
        [Route("trang-chu")]
        public ActionResult Home ()
        {
            Session["Category"] = "Trang chủ";

            UpdateVisits();

            NewsDao NewsHighestViews = newsService.GetNewsHighestViews();
            ViewBag.NewsHighestViews = NewsHighestViews;

            NewsDao NewsHighestShares = newsService.GetNewsHighestShares();
            ViewBag.NewsHighestShares = NewsHighestShares;

            List<NewsDao> ListNewNews = newsService.GetListNewNewsByCountAndConditionIsOrderByDescendingDateSubmited(10);
            ViewBag.ListNewNews = ListNewNews;

            List<NewsDao> ListNews = newsService.GetListNewsByCountAndConditionIsOrderByDescendingCountView(7);
            ViewBag.ListNews = ListNews;

            List<NewsDao> ListCToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.C_AND_C_PLUS_PLUS, 6);
            ViewBag.ListCToDay = ListCToDay;

            List<NewsDao> ListJavaToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.JAVA, 6);
            ViewBag.ListJavaToDay = ListJavaToDay;

            List<NewsDao> ListJavascriptToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.JAVASCRIPT, 6);
            ViewBag.ListJavascriptToDay = ListJavascriptToDay;

            List<NewsDao> ListCShapToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.C_SHAP, 6);
            ViewBag.ListCShapToDay = ListCShapToDay;

            List<NewsDao> ListRubyToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.RUBY, 6);
            ViewBag.ListRubyToDay = ListRubyToDay;

            List<NewsDao> ListCssToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.CSS, 6);
            ViewBag.ListCssToDay = ListCssToDay;

            List<NewsDao> ListPhpToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.PHP, 6);
            ViewBag.ListPhpToDay = ListPhpToDay;

            List<NewsDao> ListGoToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.GO, 6);
            ViewBag.ListGoToDay = ListGoToDay;

            List<NewsDao> ListSwiftToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.SWIFT, 6);
            ViewBag.ListSwiftToDay = ListSwiftToDay;

            List<NewsDao> ListHtmlToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.HTML, 6);
            ViewBag.ListHtmlToDay = ListHtmlToDay;

            List<NewsDao> ListPythonToDay = newsService.GetListNewsByTypeNewsDescription(AppConstant.DEFINE_TEXT.PYTHON, 6);
            ViewBag.ListPythonToDay = ListPythonToDay;

            return View();
        }

        [HttpGet]
        [Route("bai-viet")]
        public ActionResult TabNews (string c)
        {
            Session["Category"] = c;
            List<NewsDao> ListNews = newsService.GetListNewNewsByTypeNews(c);
            ViewBag.ListNews = ListNews;
            ViewBag.Category = c;
            return View();
        }

        public void UpdateVisits ()
        {
            string filePath = Server.MapPath("~/Views/Hits.txt");
            string content = System.IO.File.ReadAllText(filePath);
            string UpdateVisits = (int.Parse(content) + 1).ToString();
            System.IO.File.WriteAllText(filePath, UpdateVisits);
        }


    }
}