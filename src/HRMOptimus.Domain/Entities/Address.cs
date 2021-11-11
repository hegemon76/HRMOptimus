﻿using HRMOptimus.Domain.Common;

namespace HRMOptimus.Domain.Entities
{
    public class Address : EntityBase
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Country { get; set; }
        public Employee Employee { get; set; }
    }
}