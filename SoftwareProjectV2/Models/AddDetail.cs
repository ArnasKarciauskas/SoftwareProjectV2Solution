using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProjectV2.Models
{
    public class AddDetail
    {
        private ICollection<AddEquipment> _AddEquipments;
        public AddDetail()
        {
            _AddEquipments = new List<AddEquipment>();
        }

        /*
          Variables are using input validation on all fields to avoid injection of malicious
          scripts and avoid user errors. Some variables are missing [Required] in cases of
          it being an integer or date which is mandatory by default.           
        */

        //DetailId is used as a key in the generated DB hence the [Key] entry.
        [Key]
        public int DetailId {get;set;}

        //Employee first name
        [Display(Name = "Employee Name:")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 20 characters.")]
        [Required]
        public string EmployeeName { get; set; }

        //Employee second name
        [Display(Name = "Employee Second Name:")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Second Name must be between 1 and 30 characters.")]
        [Required]
        public string EmployeeSecondName { get; set; }

        //Employee number.
        [Display(Name = "Employee Number:")]
        public int EmployeeNumber { get; set; }

        //PPS
        [Display(Name = "Employee PPS:")]
        [Range(10000000, 19999999, ErrorMessage = "Must be a valid PPS number, PPS numbers start with 1 and contain 8 numbers.")]
        public int EmployeePPS { get; set; }

        //Email
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "E-mail length must be between 5 and 50 characters.")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        //Phone
        [Display(Name = "Phone No:")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a number.")]
        [Range(0800000000, 0899999999, ErrorMessage = "Must be a valid mobile format starting with 08/8")]
        public int Mobile { get; set; }

        //Date
        [Display(Name = "Start Date:")]
        public DateTime EmployeeStartDate { get; set; }

        //Add to a collection for use later when inputting data into DB.
        public virtual ICollection<AddEquipment> AddEquipments
        {
            get { return _AddEquipments; }
            set { _AddEquipments = value; }
        }

    }
}
