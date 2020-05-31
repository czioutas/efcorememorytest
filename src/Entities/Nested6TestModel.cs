using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorememorytest.Entities
{
    public class Nested6TestModel
    {
        public string A { get; set; }


        [Column(TypeName = "jsonb")]
        public IEnumerable<SubNested6TestModel1> SubNested6TestModel1 { get; set; }
    }
}