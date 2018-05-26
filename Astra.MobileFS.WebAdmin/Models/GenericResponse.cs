using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;

namespace Astra.MobileFS.WebAdmin.Models
{
    public class GenericResponse
    {
        public GenericResponse()
        {

        }

        public bool Success { get; internal set; }

        public string Message { get; internal set; }
    }

    public class GenericResponse<T> : GenericResponse
    {
        public GenericResponse()
        {

        }

        public T Data { get; internal set; }
    }


    public class GenericPageResult<T> : PageResult<T>
    {
        public GenericPageResult(IEnumerable<T> items, Uri nextPageLink, long? count) : base(items, nextPageLink, count)
        {
        }

        public bool Success { get { return true; } }
    }
}