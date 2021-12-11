﻿using HRMOptimus.Domain.Common;
using System;

namespace HRMOptimus.Domain.Entities
{
    public class WorkRecord : EntityBase
    {
        public string Name { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public TimeSpan Duration { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}