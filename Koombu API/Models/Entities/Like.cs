using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models
{
    public class Like
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

        public Like() {}

        public Like(int id, int postId, int userId)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
        }
    }
}