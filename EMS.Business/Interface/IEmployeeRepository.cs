using EMS.Model;

namespace EMS.Interface
{
    public interface IEmployeeRepository
    {
        public Employee GetEmployeeDetailById(int id);

        public List<Employee> GetActiveEmployee();

        public Employee UpdateEmployeeDetail( Employee employee);

        public Employee CreateEmployeeDetail(Employee employee);

        public Employee DeleteEmployee(int id);
    }
}
