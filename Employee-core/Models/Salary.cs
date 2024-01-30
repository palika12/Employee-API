
//using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;

//namespace Employee_core.Models
//{
//    public class Salary
//    {
//        public int Id { get; set; }

//        // Foreign key property
//        [Required]
//        public int EmployeeId { get; set; }

//        // Navigation property
//        [JsonIgnore]
//        public Employee? Employee { get; set; }

//        public decimal Amount { get; set; }
//    }

//}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_core.Models
{
    public class Salary
    {
        public int Id { get; set; }

        // Foreign key property
        [Required]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

        // Navigation property
        [JsonIgnore]
        public Employee? Employee { get; set; }

        public decimal Amount { get; set; }
    }
}
