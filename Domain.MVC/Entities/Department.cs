using Domain.MVC.Common;

namespace Domain.MVC.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
