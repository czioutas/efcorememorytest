using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorememorytest.Entities
{
    public class SubNested6TestModel1
    {
        [Key, Column("Id")]
        public long Id { get; set; }
    }
}