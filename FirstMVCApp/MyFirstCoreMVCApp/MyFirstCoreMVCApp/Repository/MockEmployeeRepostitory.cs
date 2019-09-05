using MyFirstCoreMVCApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstCoreMVCApp.Repository
{
    public class MockEmployeeRepostitory : IEmployeeRepository
    {
        #region Global Declaration
        // Declaration of employee list variable
        private List<Employee> _employee;
        #endregion

        #region MockEmployeeRepository Class Constructor
        // Constructor to add data to the list of Employees
        public MockEmployeeRepostitory()
        {
            _employee = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Prerna Chachare", Department = "Development", Skills = Skills.Programming, Address = "Nashik", Gender = "Female", AcceptTerms = true },
                new Employee() { Id = 2, Name = "Shreya Shejwalkar", Department = "Development", Skills = Skills.ProjectManagement, Address = "Bandra, Mumbai", Gender = "Female", AcceptTerms = true },
                new Employee() { Id = 3, Name = "Snehal Chavan", Department = "RND", Skills = Skills.CommonOS, Address = "Satara", Gender = "Female", AcceptTerms = true }
            };
        }
        #endregion

        #region Get Employee Details by ID
        // Method to get employee details by ID
        public Employee GetEmployeeDetails(int id) => this._employee.Find(e => e.Id == id);
        #endregion

        #region Get List of All Employees
        // Get List of all Employees
        public IEnumerable<Employee> GetAllEmployees() => _employee;
        #endregion

        #region Delete a Employee
        // Delete a employee from list
        public Employee DeleteEmployee(int id)
        {
            Employee employee = _employee.Find(e => e.Id == id);
            if (employee != null)
                _employee.Remove(employee);
            return employee;
        }
        #endregion

        #region Save Employee Details
        // Save Employee Details
        public Employee SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                if (employee.Id == 0)
                {
                    employee.Id = _employee.Max(e => e.Id) + 1;
                    _employee.Add(employee);
                }
                else
                {
                    Employee emp = _employee.FirstOrDefault(e => e.Id == employee.Id);
                    emp.Name = employee.Name;
                    emp.Department = employee.Department;
                    emp.Skills = employee.Skills;
                    emp.Address = employee.Address;
                    emp.Gender = employee.Gender;
                    emp.AcceptTerms = employee.AcceptTerms;
                }
            }
            return _employee.Where(e => e.Name == employee.Name).FirstOrDefault();
        }
        #endregion
    }
}
