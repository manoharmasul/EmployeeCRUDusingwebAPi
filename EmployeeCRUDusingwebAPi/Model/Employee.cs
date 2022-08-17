using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUDusingwebAPi.Model
{
    [Table("Emoloyee")]
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string empName { get; set; }
        public string empAddress { get; set; }
        public double empSalary { get; set; }
    }
}
