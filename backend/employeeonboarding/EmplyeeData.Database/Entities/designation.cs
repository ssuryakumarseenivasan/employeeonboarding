using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmplyeeData.Database.Entities
{
    [Table("designation")]

    public class designation
    {
        [Key]
        public int id { get; set; }
        public string desc_name { get; set; }
        public bool is_active { get; set; }
    }
}
