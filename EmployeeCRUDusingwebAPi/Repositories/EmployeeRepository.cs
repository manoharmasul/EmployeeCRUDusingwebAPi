using Dapper;
using EmployeeCRUDusingwebAPi.Context;
using EmployeeCRUDusingwebAPi.Model;
using EmployeeCRUDusingwebAPi.Repositories.Interface;

namespace EmployeeCRUDusingwebAPi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context; 
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            int result = 0;
            string qry = "update Employee set empName=@empName,empAddress=@empAddress,empSalary=@empSalary where empId=@empId";
            using (var connection=_context.CreateConnection())
            {
                result = await connection.ExecuteAsync(qry, employee);
                return result;
               
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            string qry = "select * from Employee";
            using(var connection=_context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(qry);
                return employee.ToList();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            string qry = "select * from Employee where empId=@empId";
            using(var connection=_context.CreateConnection())
            {
                var employee=await connection.QueryAsync<Employee>(qry,new {empId=id});
                return employee.FirstOrDefault();
            }
        }

        public async Task<int> AddnewEmployee(Employee employee)
        {
            int result = 0;
            string qry = "insert into Employee(empName,empAddress,empSalary) values(@empName,@empAddress,@empSalary)";
            using(var connection=_context.CreateConnection())
            {
                result=await connection.QuerySingleAsync<int>(qry, employee);
                return result;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var qry = "delete Employee where empId=@empId";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(qry, new { empId = id });
                return result;
            }
        }
    }
}
