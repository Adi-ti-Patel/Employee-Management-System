using EMS.DBContext;
using EMS.Interface;
using EMS.Model;

namespace EMS.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MainDbContext dbContext;
        public DepartmentRepository(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Department DeleteDepartment(int id)
        {
            var dept = this.dbContext.Department.FirstOrDefault(x => x.Id == id);
            this.dbContext.Department.Remove(dept);
            this.dbContext.SaveChangesAsync();
            return dept;
        }

        public List<Department> GetActiveDepartments()
        {
            return this.dbContext.Department.Where(x => x.IsActive == true).ToList();
        }

        public List<Employee> GetAllEmployeeByDepartment(int id)
        {
            return this.dbContext.Employee.Where(x => x.Id == id).ToList();
        }

        public Department GetDepartmentDetailById(int id)
        {
            return this.dbContext.Department.FirstOrDefault(x => x.Id == id);
        }

        public List<Department> GetDepartments()
        {
            return this.dbContext.Department.ToList();
        }
    }
}
