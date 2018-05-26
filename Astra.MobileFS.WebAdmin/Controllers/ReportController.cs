using Astra.MobileFS.WebAdmin.Facades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace Astra.MobileFS.WebAdmin.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportFacade _reportFacade;

        public ReportController(IReportFacade reportFacade)
        {
            _reportFacade = reportFacade;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Report
        [HttpPost]
        [ActionName("print-ticket-status")]
        public ActionResult PrintReportTicketStatus(IList<int> ids, bool exclude = false)
        {
            if (ids == null || ids.Count == 0)
                return HttpNotFound();

            var result = _reportFacade.GetTicketStatusReport(ids);
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

            var fName = string.Format("report-submit-problem-{0}.xls", DateTime.Now.ToString("s"));

            byte[] fileContents = Encoding.UTF8.GetBytes(xml);

            return File(fileContents, "application/vnd.ms-excel", fName);
        }
    }
}