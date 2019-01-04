using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Employee.Models
{
    [Table("tbl_employees")]
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string EmployeeCity { get; set; }
        [Required(ErrorMessage = "*")]
        public int EmployeeSalary { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string EmployeePassword { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EmployeeDOJ { get; set; }
        public List<EmployeeLeavesModel> Leaves { get; set; }
    }
}