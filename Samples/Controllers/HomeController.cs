using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Samples.Models;
using Mvc.Ajax.DataTables;

namespace Samples.Controllers
{
    public class HomeController : Controller
    {
        FakeDatabase db = new FakeDatabase();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }



        public ActionResult SimpleMinimumConfiguration()
        {
            return View();
        }

        public ActionResult SimpleMinimumConfigurationJson()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetArrayData()
        {
            DataTableParameters dataTableParameters = new DataTableParameters(Request.QueryString);
            DataTableResult dataTableResult = new DataTableResult();
            int iTotalRecords, iTotalDisplayRecords;

            
            dataTableResult.aaData = ConvertBrowserInfoListToArray(db.GetData(dataTableParameters, out iTotalRecords, out iTotalDisplayRecords));

            dataTableResult.sEcho = dataTableParameters.Echo;
            dataTableResult.iTotalRecords = iTotalRecords;
            dataTableResult.iTotalDisplayRecords = iTotalDisplayRecords;

            return Json(dataTableResult, JsonRequestBehavior.AllowGet);
        }

        private Array ConvertBrowserInfoListToArray(List<BrowserInfo> browserInfoList)
        {
            List<string[]> stringArrayList = new List<string[]>();
            foreach (BrowserInfo browserInfo in browserInfoList)
                stringArrayList.Add(new string[6] {browserInfo.Id.ToString(), 
                                                   browserInfo.Engine,
                                                   browserInfo.Browser,
                                                   browserInfo.Platform,
                                                   browserInfo.Version.ToString(),
                                                   browserInfo.Grade});
            return stringArrayList.ToArray();
        }


        [HttpGet]
        public JsonResult GetJsonData()
        {
            DataTableParameters dataTableParameters = new DataTableParameters(Request.QueryString);
            DataTableResult dataTableResult = new DataTableResult();
            int iTotalRecords, iTotalDisplayRecords;

            dataTableResult.aaData = db.GetData(dataTableParameters, out iTotalRecords, out iTotalDisplayRecords).ToArray();

            dataTableResult.sEcho = dataTableParameters.Echo;
            dataTableResult.iTotalRecords = iTotalRecords;
            dataTableResult.iTotalDisplayRecords = iTotalDisplayRecords;

            return Json(dataTableResult, JsonRequestBehavior.AllowGet);
        }

        
    }





    class ClassA
    {
        public int p1 { get; set; }
        public int p2 { get; set; }
        public string p3 { get; set; }

        public ClassB ClassBInstance { get; set; }

        public int func1() { return 0; }
    }

    class ClassB
    {
        public bool p1 { get; set; }
        public bool? p2 { get; set; }
        //public DateTime p3 { get; set; }
    }

    class ClassC
    {
        public string p1 { get; set; }
        public string p2 { get; set; }
    }
}
