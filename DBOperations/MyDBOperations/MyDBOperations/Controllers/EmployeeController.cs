using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDBOperations.Models;
using MyDBOperations.Repository;
using System.Linq;

namespace MyDBOperations.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        #region Global Declaration
        // The employee repository interface instance
        readonly IEmployeeRepository _employeeRepository;
        readonly MyDBContext _context;
        #endregion

        #region Constructor of Home Controller
        // Home Controller Constructor with employee repository interface object
        public EmployeeController(MyDBContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Action to Display List of Employees
        [Route("/")]
        [Route("Index")]
        public IActionResult Index() => View(_employeeRepository.GetAllEmployees());
        #endregion

        #region Action to Save Employee Details
        [Route("Save")]
        public IActionResult Save(int id)
        {
            ViewBag.DepartmentId = _context.Department.Select(e => new SelectListItem()
            {
                Value = e.Id.ToString(),
                Text = e.Name.ToString()
            });
            var employee = _employeeRepository.GetEmployeeDetails(id);
            if (employee == null)
                employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(Employee employee)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", _employeeRepository.SaveEmployee(employee));
            return View();
        }
        #endregion

        #region Action to view Employee Details
        [Route("Details")]
        // Action to display employee details
        public IActionResult Details(int id) => View(_employeeRepository.GetEmployeeDetails(id));
        #endregion

        #region Action to Delete a Employee
        [Route("Delete")]
        // Action to delete a employee
        public IActionResult Delete(int id) => View(_employeeRepository.GetEmployeeDetails(id));

        [HttpPost, ActionName("Delete")]
        [Route("Delete")]
        public IActionResult DeleteConfirmed(int id) =>
            RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        #endregion
    }
}