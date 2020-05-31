using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorememorytest.Entities
{
    public class TestModel
    {
        [Key, Column("Id")]
        public long Id { get; set; } = 0;

        public long Num1 { get; set; }
        public long Num2 { get; set; }
        public long Num3 { get; set; }
        public string A { get; set; }
        public string AA { get; set; }
        public string AAA { get; set; }
        public string AAAA { get; set; }
        public string AAAAA { get; set; }
        public string AAAAAA { get; set; }

        [Column(TypeName = "jsonb")]
        public IEnumerable<short> IEnumerableShortJsonB { get; set; }

        [Column(TypeName = "jsonb")]
        public IEnumerable<short> IEnumerableShortJsonBB { get; set; }

        public bool? BoolB { get; set; }
        public bool? BoolA { get; set; }
        public bool? BoolAA { get; set; }
        public bool? BoolAAA { get; set; }
        public bool? BoolAAAA { get; set; }
        public DateTimeOffset? ValidToA { get; set; }
        public DateTimeOffset? ValidToAA { get; set; }
        public DateTimeOffset? ValidToAAA { get; set; }
        public DateTimeOffset? ValidToAAAA { get; set; }
        public DateTimeOffset? ValidToAAAAA { get; set; }
        public DateTimeOffset? ValidToAAAAAA { get; set; }
        public Nested1TestModel Nested1TestModel { get; set; }

        [Column(TypeName = "jsonb")]
        public IEnumerable<Nested2TestModel> Nested2TestModel { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<Nested3TestModel> Nested3TestModel { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<Nested4TestModel> Nested4TestModel { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<Nested5TestModel> Nested5TestModel { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<Nested6TestModel> Nested6TestModel { get; set; }
    }
}