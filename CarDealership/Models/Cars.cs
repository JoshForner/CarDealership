using System;
using System.Collections.Generic;

namespace CarDealership.Models
{
    public partial class Cars
    {
        public int Id { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public DateTime CarYear { get; set; }
        public string CarColor { get; set; }
    }
}
