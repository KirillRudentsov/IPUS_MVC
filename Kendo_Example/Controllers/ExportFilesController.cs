using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo_Example.Controllers
{
    public class ExportFilesController : Controller
    {
        // GET: ExportFiles
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExportFile(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}