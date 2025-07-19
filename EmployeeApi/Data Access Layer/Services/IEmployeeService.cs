using Data_Logic_Layer.Entity;

namespace Data_Logic_Layer.Services
{
    public interface IEmployeeService
    {
        bool Add(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        IEnumerable<Employee> GetEmployeesByFilters(string PropertyName, string PropertyValue);
        bool Update(Employee employee);
    }
}
