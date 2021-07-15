using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProjectV2.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        //Device name
        [Display(Name = "Device Name:")]
        [Required]
        public string InvDeviceName { get; set; }

        //Device type
        [Display(Name = "Device Type:")]
        [Required]
        public string InvDeviceType { get; set; }

        //Device serial number
        //Must be between 6 and 8 numbers
        [Display(Name = "Device Serial No:")]
        [Range(100000, 99999999)]
        public int InvSerialNo { get; set; }

        //Date
        [Display(Name = "Warranty expiration:")]
        public DateTime WarrantyExpiration { get; set; }
    }
}
