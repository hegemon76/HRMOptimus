using HRMOptimus.Domain.Common;
using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Domain.Entities
{
    public class Address : EntityBase
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public Country Country { get; set; }
        public Employee Employee { get; set; }
    }
}
