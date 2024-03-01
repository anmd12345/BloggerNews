using System.Collections.Generic;

namespace BloggerNews.Dao
{
    public class NewsDao
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Background { get; set; }
        public string DateSubmited { get; set; }
        public int View { get; set; }
        public int Share { get; set; }
        public List<CommentDao> ListComment { get; set; }
        public string Author { get; set; }
        public string TypeNews { get; set; }
        public bool Status { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
        public int TypeNewsId { get; internal set; }
        public int UserId { get; internal set; }
        public NewsDao ()
        {

        }
        public NewsDao (int Id, string Header, string Content, string Background, string DateSubmited, int? View, int? Share, List<CommentDao> ListComment, string Author, string TypeNews, bool? Status, string Keyword, string Description, int? TypeNewsId, int? UserId)
        {
            this.Id = Id;
            this.Share = (int)Share;
            this.Author = Author;
            this.TypeNews = TypeNews;
            this.Status = (bool)Status;
            this.Header = Header;
            this.Content = Content;
            this.Background = Background;
            this.DateSubmited = DateSubmited;
            this.View = (int)View;
            this.Share = (int)Share;
            this.UserId = (int)UserId;
            this.TypeNewsId = (int)TypeNewsId;
            this.Description = Description;
            this.Keyword = Keyword;
            this.ListComment = ListComment;
        }
    }
}