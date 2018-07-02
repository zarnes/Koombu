using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models
{
    public class Comment
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _postId;
        public int PostId
        {
            get { return _postId; }
            set { _postId = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Comment() {}

        public Comment(int id, int postId, int userId, string content)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Content = content;
        }
    }
}