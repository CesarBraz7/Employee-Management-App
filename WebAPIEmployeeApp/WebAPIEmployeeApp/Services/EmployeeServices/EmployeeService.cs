using Microsoft.EntityFrameworkCore;
using WebAPIEmployeeApp.DataContext;
using WebAPIEmployeeApp.Models;

namespace WebAPIEmployeeApp.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDBContext _context;
        public EmployeeService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                if (newEmployee == null) //caso as informacoes sejam nulas
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "provide the data";
                    serviceResponse.Success = false;
                }

                _context.Add(newEmployee); //adicionar na tabela as informacoes dadas
                await _context.SaveChangesAsync(); //salvar as mudancas

                serviceResponse.Data = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    serviceResponse.Message = "employee not found";
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
                serviceResponse.Message = "employee " + employee.Id + " was deleted";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployee()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Data = _context.Employees.ToList(); //listando tudo presente na tabela

                if (serviceResponse.Data.Count == 0) //verificacao caso nao tenha nenhum funcionario
                {
                    serviceResponse.Message = "data not found";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                serviceResponse.Data = _context.Employees.Find(id); //procurando todos com o id igual ao informado

                if (serviceResponse.Data == null) //caso o id nao seja encontrado no banco
                {
                    serviceResponse.Message = "employee not found";
                }

                if (id == null) //verificacao se o campo de id for nulo
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "provide the data";
                    serviceResponse.Success = false;
                }

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    serviceResponse.Message = "employee not found";
                }

                employee.IsActive = false;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
                serviceResponse.Message = "employee " + employee.Id + " was inactived";

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel updatedEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == updatedEmployee.Id);

                if (employee == null)
                {
                    serviceResponse.Message = "employee not found";
                }

                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(updatedEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
                serviceResponse.Message = "employee " + employee.Id + " was updated";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> ActiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.Find(id);

                if (employee == null)
                {
                    serviceResponse.Message = "employee not found";
                }

                employee.IsActive = true;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
                serviceResponse.Message = "employee " + employee.Id + " was activated";

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
