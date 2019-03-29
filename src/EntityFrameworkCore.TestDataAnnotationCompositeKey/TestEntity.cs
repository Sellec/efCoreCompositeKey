using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCore.TestDataAnnotationCompositeKey
{
    public class TestEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key1 { get; set; }

        [Key]
        public int Key2 { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
