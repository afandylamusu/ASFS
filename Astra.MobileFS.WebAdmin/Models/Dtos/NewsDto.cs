using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Astra.MobileFS.WebAdmin.Models.Dtos
{
    public class NewsDto
    {
        public int Id { get; internal set; }
        public string Title { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Content { get; internal set; }

        public ICollection<RecipientDto> Recepients { get; set; }
    }

    public class RecipientDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Type { get; set; }
    }

}