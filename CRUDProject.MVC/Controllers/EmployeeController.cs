using Application.MVC.Commons.Models;
using Application.MVC.UseCases.Employees.Commands;
using Application.MVC.UseCases.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.MVC.Controllers;

public class EmployeeController : BaseController
{
    [HttpGet("getall")]
    public async Task<IActionResult> Index(int pg = 1)
    {
        const int pageSize = 10;
        if (pg < 1)
            pg = 1;
        int recsCount = context.Employees.Count();
        var paginatedList = new PaginatedList(recsCount, pg, pageSize);
        int recSkip = (pg - 1) * pageSize;
        IEnumerable<EmployeeDto> allEmployees = await mediator.Send(new GetAllEmployeeQuery());
        List<EmployeeDto> employees = allEmployees.Skip(recSkip).Take(paginatedList.PageSize).ToList();
        ViewBag.PaginatedList = paginatedList;
        return View(employees);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand employee)
    {
        await mediator.Send(employee);
        return RedirectToAction("Index", "Employee");
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UpdateEmployeeCommand employee)
    {
        await mediator.Send(employee);
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Delete([FromForm] DeleteEmployeeCommand employee)
    {
        await mediator.Send(employee);
        return NoContent();
    } 
}
