using WebAPIEmployeeApp.Models;

namespace WebAPIEmployeeApp.Services.EmployeeServices
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployee();
        Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee);
        Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id);
        Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updatedEmployee);
        Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id);
        Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id);
        Task<ServiceResponse<List<EmployeeModel>>> ActiveEmployee(int id);
    }
}
