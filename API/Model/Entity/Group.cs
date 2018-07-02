using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koombu_API.Models
{
    public class Group
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _private;
        public bool Private
        {
            get { return _private; }
            set { _private = value; }
        }

        private int _ownerId;
        public int OwnerId
        {
            get { return _ownerId; }
            set { _ownerId = value; }
        }

        public Group() {}

        public Group(int id, string name, bool @private, int ownerId)
        {
            Id = id;
            Name = name;
            Private = @private;
            OwnerId = ownerId;
        }
    }
}