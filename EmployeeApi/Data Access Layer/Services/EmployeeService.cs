using Data_Logic_Layer.Entity;
using Data_Logic_Layer.Repository;

namespace Data_Logic_Layer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public bool Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public IEnumerable<Employee> GetEmployeesByFilters(string PropertyName, string PropertyValue)
        {
            return _employeeRepository.GetEmployeesByFilters(PropertyName, PropertyValue);
        }

        public bool Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
    }
}
