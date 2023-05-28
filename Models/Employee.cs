using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCTaskProject.Models
{
    public class Employee
    {
      
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]

            public int EmployeeId { get; set; }

            [Required]
            [MaxLength(100)]
            [Column("Name", TypeName = "Varchar")]

            public string Name { get; set; }

            [MaxLength(1000)]
            public string Address { get; set; }

            public int DepartmentId  { get; set; }
            [ForeignKey("DepartmentId")]
            public Department Department { get; set; }


       

    }
}