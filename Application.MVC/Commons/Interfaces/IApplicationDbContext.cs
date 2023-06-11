using Domain.MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.MVC.Commons.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
