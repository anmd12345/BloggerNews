using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerNews.Dao
{
    public class CommentDao
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string DateCommented { get; set; }
        public string Comment { get; set; }

        public CommentDao () { }
        public CommentDao (int id, string author, string dateCommented, string comment)
        {
            this.Id = id;
            this.Author = author;
            this.DateCommented = dateCommented;
            this.Comment = comment;
        }
    }
}