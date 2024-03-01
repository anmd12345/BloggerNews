using BloggerNews.Dao;
using BloggerNews.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebGrease.Css.Extensions;

namespace BloggerNews.Service
{
    public class NewsService
    {
        private ConnectionWithDatabaseDataContext db = new ConnectionWithDatabaseDataContext();

        public NewsDao GetNewsHighestViews ()
        {
            var NewsRequest = db.News.OrderByDescending(n => n.CountView).Where(x => x.Status == true).FirstOrDefault();
            if (NewsRequest != null)
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                NewsRequest.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });
                return new NewsDao(NewsRequest.Id, NewsRequest.Header, NewsRequest.Content, NewsRequest.Background, NewsRequest.DateSubmited, NewsRequest.CountView, NewsRequest.CountShare, ListComment, NewsRequest.User.Username, NewsRequest.TypeNew.TypeNewsDescription, NewsRequest.Status, NewsRequest.Keyword, NewsRequest.Description, NewsRequest.TypeNewsId, NewsRequest.UserId);
            }
            return null;
        }

        public NewsDao GetNewsHighestShares ()
        {
            var NewsRequest = db.News.OrderByDescending(n => n.CountShare).Where(x => x.Status == true).FirstOrDefault();
            if (NewsRequest != null)
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                NewsRequest.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });
                return new NewsDao(NewsRequest.Id, NewsRequest.Header, NewsRequest.Content, NewsRequest.Background, NewsRequest.DateSubmited, NewsRequest.CountView, NewsRequest.CountShare, ListComment, NewsRequest.User.Username, NewsRequest.TypeNew.TypeNewsDescription, NewsRequest.Status, NewsRequest.Keyword, NewsRequest.Description, NewsRequest.TypeNewsId, NewsRequest.UserId);
            }
            return null;
        }

        public List<NewsDao> GetListNewNewsByTypeNews (string TypeNews)
        {
            var ListNews = db.News.OrderByDescending(x => x.DateSubmited).Where(x => x.TypeNew.TypeNewsDescription.Equals(TypeNews) && x.Status == true).ToList();
            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public List<NewsDao> GetAll (string TypeGet)
        {
            List<New> ListNews = null;
            if (TypeGet == "all")
            {
                ListNews = db.News.OrderByDescending(x => x.DateSubmited).ToList();
            }
            else
            {
                ListNews = db.News.OrderByDescending(x => x.DateSubmited).Where(x => x.Status == bool.Parse(TypeGet)).ToList();
            }

            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public List<NewsDao> GetListNewNewsByCountAndConditionIsOrderByDescendingDateSubmited (int count)
        {
            var ListNews = db.News.Take(count).OrderByDescending(x => x.DateSubmited).Where(x => x.Status == true).ToList();
            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public List<NewsDao> GetListNewsByTypeNewsDescription (string TypeNewsDescription, int count)
        {
            var ListNews = db.News.OrderByDescending(x => x.DateSubmited).Where(x => x.TypeNew.TypeNewsDescription == TypeNewsDescription && x.Status == true).Take(count).ToList();
            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public List<NewsDao> GetListNewsYourLikeByTypeNewsDescription (int IdCurrentNews, string TypeNewsDescription, int count)
        {
            var ListNews = db.News.OrderByDescending(x => x.DateSubmited).Where(x => x.TypeNew.TypeNewsDescription == TypeNewsDescription && x.Status == true && x.Id != IdCurrentNews).Take(count).ToList();
            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public List<NewsDao> GetListNewsByCountAndConditionIsOrderByDescendingCountView (int count)
        {
            var ListNews = db.News.Take(count).OrderByDescending(x => x.CountView).Where(x => x.Status == true).ToList();
            var ListNewsDao = new List<NewsDao>();
            ListNews.ForEach(item =>
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                item.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });

                ListNewsDao.Add(new NewsDao(item.Id, item.Header, item.Content, item.Background, item.DateSubmited, item.CountView, item.CountShare, ListComment, item.User.Username, item.TypeNew.TypeNewsDescription, item.Status, item.Keyword, item.Description, item.TypeNewsId, item.UserId));
            });
            return ListNewsDao;
        }

        public NewsDao UpdateCountViewByHeader (string Header)
        {
            New NewsRequest = db.News.FirstOrDefault(x => x.Header.Equals(Header));
            if (NewsRequest != null)
            {
                NewsRequest.CountView++;
                db.SubmitChanges();
                List<CommentDao> ListComment = new List<CommentDao>();
                NewsRequest.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });
                return new NewsDao(NewsRequest.Id, NewsRequest.Header, NewsRequest.Content, NewsRequest.Background, NewsRequest.DateSubmited, NewsRequest.CountView, NewsRequest.CountShare, ListComment, NewsRequest.User.Username, NewsRequest.TypeNew.TypeNewsDescription, NewsRequest.Status, NewsRequest.Keyword, NewsRequest.Description, NewsRequest.TypeNewsId, NewsRequest.UserId);
            }
            return null;
        }

        public void UpdateCountShareByHeader (string Header)
        {
            New NewsRequest = db.News.FirstOrDefault(x => x.Header.Equals(Header));
            if (NewsRequest != null)
            {
                NewsRequest.CountShare++;
                db.SubmitChanges();
            }
        }

        public NewsDao GetNewByHeader (string Header, string TypeGet)
        {
            New NewsRequest = null;
            if (TypeGet == "all")
            {
                NewsRequest = db.News.FirstOrDefault(x => x.Header.Equals(Header));
            }
            else
            {
                NewsRequest = db.News.FirstOrDefault(x => x.Header.Equals(Header) && x.Status == bool.Parse(TypeGet));
            }

            if (NewsRequest != null)
            {
                List<CommentDao> ListComment = new List<CommentDao>();
                NewsRequest.Comments.ForEach(x =>
                {
                    ListComment.Add(new CommentDao(x.Id, x.Fullname, x.DateCommented, x.CommentContent));
                });
                return new NewsDao(NewsRequest.Id, NewsRequest.Header, NewsRequest.Content, NewsRequest.Background, NewsRequest.DateSubmited, NewsRequest.CountView, NewsRequest.CountShare, ListComment, NewsRequest.User.Username, NewsRequest.TypeNew.TypeNewsDescription, NewsRequest.Status, NewsRequest.Keyword, NewsRequest.Description, NewsRequest.TypeNewsId, NewsRequest.UserId);
            }
            return null;
        }

        public void CreateNews (string Header, string Content, string Description, string Keyword, string Background, int TypeNewsId, int UserId, bool Status, string DateSubmited)
        {
            NewsDao NewsRequest = GetNewByHeader(Header, "all");
            if (NewsRequest == null)
            {
                New NewCreated = new New();
                NewCreated.Header = Header;
                NewCreated.Content = Content;
                NewCreated.Description = Description;
                NewCreated.Keyword = Keyword;
                NewCreated.Background = Background;
                NewCreated.TypeNewsId = TypeNewsId;
                NewCreated.UserId = UserId;
                NewCreated.Status = Status;
                NewCreated.DateSubmited = DateSubmited;
                NewCreated.CountShare = 0;
                NewCreated.CountView = 0;
                db.News.InsertOnSubmit(NewCreated);
                db.SubmitChanges();
            }
        }

        public void UpdateNews (New News)
        {
            var NewsRequest = GetNewsById(News.Id);
            NewsRequest.Header = News.Header;
            NewsRequest.Background = News.Background;
            NewsRequest.Content = News.Content;
            NewsRequest.DateSubmited = News.DateSubmited;
            NewsRequest.CountView = News.CountView;
            NewsRequest.CountShare = News.CountShare;
            NewsRequest.TypeNewsId = News.TypeNewsId;
            NewsRequest.UserId = News.UserId;
            NewsRequest.Status = News.Status;
            NewsRequest.Keyword = News.Keyword;
            NewsRequest.Description = News.Description;
            db.SubmitChanges();
        }

        public New GetNewsById (int NewsId)
        {
            return db.News.FirstOrDefault(x => x.Id == NewsId);
        }
    }
}

