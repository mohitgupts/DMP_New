using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMP.Models;
using DMP.ModelsView;
using DMP.Utils;

namespace DMP.Controllers {
    public class ReportingController : Controller {


        public ActionResult MonthWisePlanAndActual(IEnumerable<Target> targets) {
            var groupedTargetMonth = targets.GroupBy(x => x.Month);
            BarTargetModels model = new BarTargetModels();
            model.Models = groupedTargetMonth.Select(
               x => new BarTargetModel { Month = x.Key, T1 = x.Sum(y => y.T1), T2 = x.Sum(y => y.T2), Actual = x.Sum(y => y.Actual) }).ToList();
            var months=model.Models.Select(x => x.Month);
            var actuals=model.Models.Select(x => x.Actual);
            var t1=model.Models.Select(x => x.T1);
            var t2=model.Models.Select(x => x.T2);
            var Serializer=new System.Web.Script.Serialization.JavaScriptSerializer();
            ViewBag.months=Serializer.Serialize(months);
            ViewBag.actuals=Serializer.Serialize(actuals);
            ViewBag.t1 = Serializer.Serialize(t1);
            ViewBag.t2 = Serializer.Serialize(t2);
            return PartialView("MonthWisePlanAndActual");
        }

    }
}
