using Microsoft.EntityFrameworkCore;
using MyDBOperations.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyDBOperations.Repository
{
    // IEmployeeRepository Interface
    public interface IEmployeeRepository
    {
        // Method Declaration to get a single employee
        Employee GetEmployeeDetails(int id);

        // Method Declaration to get list of all employees
        IEnumerable<Employee> GetAllEmployees();

        Employee SaveEmployee(Employee employee);

        // Method Declaration to delete an employee
        Employee DeleteEmployee(int id);
    }

    // EmployeeRepository Class
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Global Declaration
        // Declaration of DBContext object
        private readonly MyDBContext _context;
        #endregion

        #region EmployeeRepository class constructor
        // Constructor to initialize database context
        public EmployeeRepository(MyDBContext context) => _context = context;
        #endregion

        #region Delete Employee
        // Method to delete employee
        public Employee DeleteEmployee(int id)
        {
            Employee employee = _context.Employee.Where(e => e.Id == id).SingleOrDefault();
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }
        #endregion

        #region Get All Employees
        // Method to get data of all employees
        public IEnumerable<Employee> GetAllEmployees() => _context.Employee.Include(x => x.Department).ToList();
        #endregion

        #region Get a Employee using ID
        // Method to get employee details using ID
        public Employee GetEmployeeDetails(int id) => _context.Employee.Include(d => d.Department).SingleOrDefault(e => e.Id == id);
        #endregion

        #region Save Employee to database
        // Method to add or edit a employee in database
        public Employee SaveEmployee(Employee employee)
        {
            if (employee != null)
            {
                if (employee.Id == 0)
                    _context.Employee.Add(employee);
                else
                    _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return _context.Employee.Where(e => e.Name == employee.Name).FirstOrDefault();
        }
        #endregion
    }
}
