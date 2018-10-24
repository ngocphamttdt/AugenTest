using SampleAssignment.Implement;
using SampleAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAssignment.Controllers
{
    public class HomeController : Controller
    {
        SampleData _sampleData = new SampleData();
        public ActionResult Index()
        {
            var path = Server.MapPath(@"~/FileData/SampleData.csv");
            //show first page
            var employees = _sampleData.PagingEmployee(1, 50, path);
            var partitionSections = _sampleData.Partition(500, 50);
            var data = new IndexModel
            {
                Employees = employees,
                Partitions = partitionSections
            };
            return View(data);
        }

        public ActionResult Search(string keyword)
        {
            var path = Server.MapPath(@"~/FileData/SampleData.csv");
            var result = _sampleData.SearchData(keyword, path);
            return PartialView("~/Views/Home/_Search.cshtml", result);
        }

        public ActionResult Paging(int fromIndex, int toIndex)
        {
            var path = Server.MapPath(@"~/FileData/SampleData.csv");
            var result = _sampleData.PagingEmployee(fromIndex, toIndex, path);
            return PartialView("~/Views/Home/_Search.cshtml", result);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}