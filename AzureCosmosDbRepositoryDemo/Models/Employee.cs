using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Attributes;
using Newtonsoft.Json;

namespace AzureCosmosDbRepositoryDemo.Models
{
    //[Container("Employee")]
    [PartitionKeyPath("/EmployeeId")]
    
    public class Employee : Item
    {
        [JsonProperty("EmployeeId")]
        public string EmployeeId { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }
        protected override string GetPartitionKeyValue() => EmployeeId;
    }
}
