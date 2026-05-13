using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Service.DTOs.CustomerDTOs
{
    public abstract class CustomerDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsPremium { get; set; }
    }
}
