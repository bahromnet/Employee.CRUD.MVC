using Domain.MVC.Common;

namespace Domain.MVC.Entities;

public class Employee : BaseEntity
{
    public string FullName { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; } = DateTime.Now;
}
