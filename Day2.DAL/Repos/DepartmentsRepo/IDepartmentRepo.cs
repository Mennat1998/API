using Day2.DAL.Data.Models;


namespace Day2.DAL.Repos.DepartmentsRepo
{
   public interface IDepartmentRepo
    {
        Departments? GetDetailsCustomFromDb(int id);
    }
}
