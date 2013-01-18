using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMP.Models {
    public class BarTargetModel {
        public string Month { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int Actual { get; set; }
    }

    public class BarTargetModels {
        public IEnumerable<BarTargetModel> Models { get; set; }
    }
}