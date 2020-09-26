using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedSystems2020.Models {
    public class BGTollModel {
        public BGTollVinette vignette { get; set; }
        public bool ok { get; set; }
    }

    public class BGTollVinette {
        public string licensePlateNumber { get; set; }
        public string vignetteNumber { get; set; }
        public string vehicleClass { get; set; }
        public string validityDateToFormated { get; set; }
    }
}