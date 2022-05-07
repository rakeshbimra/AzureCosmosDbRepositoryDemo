using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;

namespace AzureCosmosDbRepositoryDemo.Models
{
    [PartitionKeyPath("/employeeId")]
    public class Employee : Item
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        protected override string GetPartitionKeyValue() => EmployeeId;
    }
}
