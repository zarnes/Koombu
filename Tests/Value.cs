using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class Value
    {
        [Key]
        public int Id { get; set; }

        public string Val { get; set; }
    }
}
