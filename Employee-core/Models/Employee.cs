using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_core.Models
{
    public class Employee
    {




        [Key]
    public int Id { get; set; }
        public string ?EmployeeName { get; set; }
        public int Age { get; set; }
        
        
        [JsonIgnore]
        public Salary ?Salary { get; set; }
    }
}
