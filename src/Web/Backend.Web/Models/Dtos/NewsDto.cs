using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Web.Models.Dtos
{
    public class NewsDto
    {
        public class Recepient
        {
            public int Id { get; set; }
            public string Alias { get; set; }
            public string EmailAddress { get; set; }
        }

        public int Id { get; internal set; }
        public string Title { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Content { get; internal set; }

        public ICollection<Recepient> Recepients { get; set; }
    }

}