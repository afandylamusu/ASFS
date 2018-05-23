using Backend.Web.Facades;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace Backend.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportFacade _reportFacade;

        public ReportController(IReportFacade reportFacade)
        {
            _reportFacade = reportFacade;
        }

        // GET: Report
        [HttpPost]
        [ActionName("print-ticket-status")]
        public ActionResult PrintReportTicketStatus(int[] ids, bool exclude = false)
        {
            var result = _reportFacade.GetTicketStatusReport(new int[] { 1, 12 });
            string xml = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();

            XmlSerializer xmlSerializer = new XmlSerializer(result.GetType());

            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, result);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                xml = xmlDoc.InnerXml;
            }

            var fName = string.Format("report-submit-problem-{0}", DateTime.Now.ToString("s"));

            byte[] fileContents = Encoding.UTF8.GetBytes(xml);

            return File(fileContents, "application/vnd.ms-excel", fName);
        }
    }
}