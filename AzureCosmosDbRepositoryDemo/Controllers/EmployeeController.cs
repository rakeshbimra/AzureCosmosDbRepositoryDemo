using AzureCosmosDbRepositoryDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;

namespace AzureCosmosDbRepositoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeController(IRepositoryFactory factory)
        {
            _repository = factory.RepositoryOf<Employee>();
        }

        [HttpGet(Name = nameof(GetEmployees))]
        public ValueTask<IEnumerable<Employee>> GetEmployees() =>
            _repository.GetByQueryAsync(queryDefinition: new Microsoft.Azure.Cosmos.QueryDefinition("SELECT * FROM c"));

        [HttpGet("{id}", Name = nameof(GetEmployeeById))]
        public ValueTask<Employee> GetEmployeeById(string id) =>
            _repository.GetAsync(id, "1");

        [HttpPost]
        public async ValueTask<IEnumerable<Employee>> AddEmployees([FromBody] params Employee[] employees)
        {
            try
            {

                return await _repository.CreateAsync(employees);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
