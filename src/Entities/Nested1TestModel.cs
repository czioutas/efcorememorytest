using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorememorytest.Entities
{
    public class Nested1TestModel
    {
        [Key, Column("Id")]
        public long Id { get; set; }
    }
}