using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models
{
    public class Post
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private string _picture;
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _groupId;
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private string _attachment;
        public string Attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }

        public Post() { }

        public Post(int id, string title, string content, string picture, int userId, int groupId, string attachment)
        {
            Id = id;
            Title = title;
            Content = content;
            Picture = picture;
            UserId = userId;
            GroupId = groupId;
            Attachment = attachment;
        }
    }
}