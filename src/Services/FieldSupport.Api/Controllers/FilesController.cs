using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FieldSupport.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/files")]
    public class FilesController : ApiController
    {
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("upload/image")]
        public async Task<HttpResponseMessage> UploadImage()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, dict));
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return await Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, dict));
                        }
                        else
                        {

                            var filePath = HttpContext.Current.Server.MapPath("~/Userfiles/" + postedFile.FileName + extension);

                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return await Task.FromResult(Request.CreateErrorResponse(HttpStatusCode.Created, message1));
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound, dict));
            }
            catch (Exception)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound, dict));
            }
        }
    }
}