using System;
using System.Collections.Generic;

namespace MyApi.DA.EF
{
    public partial class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public int? State { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
