using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public DateTime HireDate { get; set; }

    }
}
