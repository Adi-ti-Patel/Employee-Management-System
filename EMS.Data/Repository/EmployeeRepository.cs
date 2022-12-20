using EMS.DBContext;
using EMS.Interface;
using EMS.Model;

namespace EMS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MainDbContext dbContext;
        public EmployeeRepository(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee CreateEmployeeDetail(Employee employee)
        {
            this.dbContext.Add(employee);
            this.dbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var emp = this.dbContext.Employee.FirstOrDefault(x => x.Id == id);
            this.dbContext.Employee.Remove(emp);
            this.dbContext.SaveChangesAsync();
            return emp;
        }

        public List<Employee> GetActiveEmployee()
        {
            return this.dbContext.Employee.Where(x => x.IsActive == true).ToList();
        }

        public Employee GetEmployeeDetailById(int id)
        {
            return this.dbContext.Employee.Where(x => x.Id == id).FirstOrDefault();
        }

        public Employee UpdateEmployeeDetail( Employee employee)
        {
            var employees = this.dbContext.Employee.Any(x => x.Id == employee.Id);
            this.dbContext.Employee.Update(employee);
            this.dbContext.SaveChanges();
            return employee;
        }
    }
}
