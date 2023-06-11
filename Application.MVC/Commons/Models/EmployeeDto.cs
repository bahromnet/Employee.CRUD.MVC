using Domain.MVC.Entities;

namespace Application.MVC.Commons.Models;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid DepartmentId { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}
