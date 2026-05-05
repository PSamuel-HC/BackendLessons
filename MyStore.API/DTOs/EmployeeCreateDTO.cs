using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class EmployeeCreateDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

    }
}
