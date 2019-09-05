using Microsoft.AspNetCore.Mvc;
using MyFirstCoreMVCApp.Models;
using MyFirstCoreMVCApp.Repository;

namespace MyFirstCoreMVCApp.Controllers
{
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        #region Global Declaration
        // The employee repository interface instance
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor of Home Controller
        // Home Controller Constructor with employee repository interface object
        public EmployeeController(IEmployeeRepository employeeRepository) =>
            _employeeRepository = employeeRepository;
        #endregion

        #region Action to return Hello World
        [Route("Main")]
        // Action to display Hello World
        public IActionResult Main() => Content("Hello World");
        #endregion

        #region Action to return JSON Data
        [Route("JsonDetails")]
        // Action to return a JSON Data
        public JsonResult JsonDetails() => Json(new { Name = "Nikhil Patil", Department = "R&D" });
        #endregion

        #region Action to Display List of Employees
        [Route("/")]
        [Route("[action]")]
        // Action to show list of employees
        public IActionResult Index() => View(_employeeRepository.GetAllEmployees());
        #endregion

        #region Action to view Employee Details
        [Route("Details")]
        // Action to display employee details
        public IActionResult Details(int id) => View(_employeeRepository.GetEmployeeDetails(id));
        #endregion

        #region Action to Save Employee Details
        [Route("Save")]
        // Action to save employee details
        public IActionResult Save(int id)
        {
            var employee = _employeeRepository.GetEmployeeDetails(id);
            if (employee == null)
                employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(Employee employee)
        {
            if(ModelState.IsValid)
                return RedirectToAction("Index", _employeeRepository.SaveEmployee(employee));
            return View();
        }
        #endregion

        #region Action to Delete a Employee
        [Route("Delete")]
        // Action to delete a employee
        public IActionResult Delete(int id) => View(_employeeRepository.GetEmployeeDetails(id));

        [HttpPost, ActionName("Delete")]
        [Route("DeleteEmployee")]
        public IActionResult DeleteConfirmed(int id) => 
            RedirectToAction("Index", _employeeRepository.DeleteEmployee(id));
        #endregion
    }
}