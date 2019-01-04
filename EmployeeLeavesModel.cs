using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Employee.Models
{
    [Table("tbl_employeeleaves")]
    public class EmployeeLeavesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeavesID { get; set; }
        [Required(ErrorMessage = "*")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "*")]
        public string LeaveType { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LeaveApplyDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LeaveStartDate { get; set; }
        [Required(ErrorMessage = "*")]
        public int NoOfDays { get; set; }
        [ForeignKey("EmployeeID")]
        public EmployeeModel Employee { get; set; }


    }
}