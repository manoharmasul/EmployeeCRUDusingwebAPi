

using EmployeeCRUDusingwebAPi.Model;

namespace EmployeeCRUDusingwebAPi.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();
        public Task<Employee> GetEmployeeById(int id);
        public Task<int> UpdateEmployee(Employee employee);
        public Task<int> AddnewEmployee(Employee employee);
        public Task<int> DeleteEmployee(int id);
       
    }
}
