using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Usando o Entity Framework para mapear a clesse Employee com a tabela Employees no banco (pois o banco já está 
pronto, se não estivesse poderia usar "code first")

**DICA**: para ver os dados da tabela use `SELECT TOP 10 * FROM Employees`
*/

namespace WebApiDotNetCore.Models
{
    [Table("Employees")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Identity indica que é o ID
        [Required]// Required indica que é um campo NOT NULL
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
    }

}