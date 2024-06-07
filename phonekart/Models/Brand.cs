﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PHONEKART.Models
{
    [Table("Brand")]
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string BrandName { get; set; }
        public List<Phone> Phone { get; set; }
    }
}
