using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CashSavvyApi.Models
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
