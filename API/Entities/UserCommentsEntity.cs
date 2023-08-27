using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class UserCommentsEntity
    {
        public IEnumerable<Comment> Comments { get; set; }
        public int TotalItems {get;set;}
    }
}