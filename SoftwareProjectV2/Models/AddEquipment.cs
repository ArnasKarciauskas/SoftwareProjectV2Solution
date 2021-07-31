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

        /*
          Variables are using input validation on all fields to avoid injection of malicious
          scripts and avoid user errors. Some variables are missing [Required] in cases of
          it being an integer or date which is mandatory by default.           
        */

        //EquipmentId is used as a key in the generated DB hence the [Key] entry.
        [Key]
        public int EquipmentId { get; set; }

        //Device name
        [Display(Name = "Device Name:")]
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Device name must not exceed 20 characters")]
        public string DeviceName { get; set; }

        //Device type
        [Display(Name = "Device Type:")]
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Device type must not exceed 20 characters")]
        public string DeviceType { get; set; }

        //Ints are required by default
        //Device serial number
        //Must be between 6 and 8 numbers
        [Display(Name = "Device Serial No:")]
        [Range(100000, 99999999)]
        public int SerialNo { get; set; }


        [Display(Name = "Assigned To: (Employee No)")]
        [Range(10000000, 99999999, ErrorMessage = "Employee numbers must contain 8 numbers.")]
        public int AssignedTo { get; set; }

        //Date
        [Display(Name = "Date assigned:")]
        public DateTime AssignedDate { get; set; }

        //Add to a collection for use later when inputting data into DB.
        public virtual ICollection<AddDetail> _AddDetailsIC
        {
            get { return _AddDetailsIC; }
            set { _AddDetailsIC = value; }
        }
    }
}
