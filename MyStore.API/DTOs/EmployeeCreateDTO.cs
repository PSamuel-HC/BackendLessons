using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public decimal HourlyRate { get; set; }
        public DateTime HireDate { get; set; }

    }
}
