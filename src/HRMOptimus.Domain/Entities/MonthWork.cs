using System.Collections.Generic;

namespace HRMOptimus.Domain.Entities
{
    public class MonthWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<DayWork> DayWorks { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}