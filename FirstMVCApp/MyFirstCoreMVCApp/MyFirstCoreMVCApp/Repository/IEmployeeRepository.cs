using MyFirstCoreMVCApp.Models;
using System.Collections.Generic;

namespace MyFirstCoreMVCApp.Repository
{
    public interface IEmployeeRepository
    {
        // Method Declaration to get a single employee
        Employee GetEmployeeDetails(int id);

        // Method Declaration to get list of all employees
        IEnumerable <Employee> GetAllEmployees();

        Employee SaveEmployee(Employee employee);

        // Method Declaration to delete an employee
        Employee DeleteEmployee(int id);
    }
}
