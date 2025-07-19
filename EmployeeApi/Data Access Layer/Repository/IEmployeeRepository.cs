using Data_Logic_Layer.Entity;

namespace Data_Logic_Layer.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        IEnumerable<Employee> GetEmployeesByFilters(string PropertyName, string PropertyValue);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
    }
}
