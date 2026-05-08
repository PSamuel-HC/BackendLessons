using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public int PointsBalance { get; set; }

        public bool IsPremium { get; set; }

        public DateTime? LastPurchaseDate { get; set; }
    }
}
