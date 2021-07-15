using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProjectV2.Models
{
    public class AddEquipment
    {
        private ICollection<AddDetail> _AddDetailsI;
        public AddEquipment()
        {
            _AddDetailsI = new List<AddDetail>();
        }
        //Key is automatically added to DB
        [Key]
        public int EquipmentId { get; set; }

        //Device name
        [Display(Name = "Device Name:")]
        [Required]
        public string DeviceName { get; set; }

        //Device type
        [Display(Name = "Device Type:")]
        [Required]
        public string DeviceType { get; set; }

        //Ints are required by default
        //Device serial number
        //Must be between 6 and 8 numbers
        [Display(Name = "Device Serial No:")]
        [Range(100000, 99999999)]
        public int SerialNo { get; set; }


        [Display(Name = "Assigned To: (Employee No)")]
        public int AssignedTo { get; set; }

        //Date
        [Display(Name = "Date assigned:")]
        public DateTime AssignedDate { get; set; }

        public virtual ICollection<AddDetail> _AddDetailsIC
        {
            get { return _AddDetailsIC; }
            set { _AddDetailsIC = value; }
        }
    }
}
