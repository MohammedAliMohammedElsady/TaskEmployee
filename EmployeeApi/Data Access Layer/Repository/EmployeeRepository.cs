using Data_Logic_Layer.Data;
using Data_Logic_Layer.Entity;

namespace Data_Logic_Layer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee.Id > 0 ? true : false;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    return false;
                }
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return false;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return new List<Employee>();
            }
        }

        public Employee GetById(int id)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
                return employee == null ? new Employee() : employee;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return new Employee();
            }
        }

        public IEnumerable<Employee> GetEmployeesByFilters(string PropertyName, string PropertyValue)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                if (PropertyName.ToLower() == nameof(Employee.FirstName).ToLower())
                {
                    employees = _context.Employees.Where(e => e.FirstName == PropertyValue).ToList();
                }
                else if (PropertyName.ToLower() == nameof(Employee.LastName).ToLower())
                {
                    employees = _context.Employees.Where(e => e.LastName == PropertyValue).ToList();
                }
                else if (PropertyName.ToLower() == nameof(Employee.Email).ToLower())
                {
                    employees = _context.Employees.Where(e => e.Email.ToLower() == PropertyValue.ToLower()).ToList();
                }
                else if (PropertyName.ToLower() == nameof(Employee.Position).ToLower())
                {
                    employees = _context.Employees.Where(e => e.Position.ToLower() == PropertyValue.ToLower()).ToList();
                }
                return employees;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return employees;
            }
        }

        public bool Update(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return false;
            }
        }
    }
}