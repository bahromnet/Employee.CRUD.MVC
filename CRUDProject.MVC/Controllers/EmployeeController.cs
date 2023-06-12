using Application.MVC.Commons.Models;
using Application.MVC.UseCases.Employees.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.MVC.Controllers
{
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

            this.ViewBag.PaginatedList = paginatedList;

            return View(employees);
        }
    }
}
