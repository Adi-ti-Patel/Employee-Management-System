using EMS.Model;

namespace EMS.Interface
{
    public interface IDepartmentRepository
    {
        public List<Department> GetDepartments();

        public List<Department> GetActiveDepartments();

        public Department GetDepartmentDetailById(int id);

        public List<Employee> GetAllEmployeeByDepartment(int id);

        public Department DeleteDepartment(int id);
    }
}
