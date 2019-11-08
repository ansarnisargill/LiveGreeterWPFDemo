using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LiveGreeterWpfDemo.Models
{
    
        public class Vehicle
        {
            [Key]
            public int VehicleID { get; set; }
            [MaxLength(50)]
            public string RegNo { get; set; }
            [MaxLength(50)]

            public string Make { get; set; }
            [MaxLength(50)]
            public string Model { get; set; }
            [MaxLength(50)]
            public string Color { get; set; }
            [MaxLength(50)]
            public string EngineNo { get; set; }
            [MaxLength(50)]
            public string ChasisNo { get; set; }
            public DateTime DateOfPurchase { get; set; }
            public bool Active { get; set; }
        }
}
