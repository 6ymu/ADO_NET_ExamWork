using System;
using System.Collections.Generic;

#nullable disable

namespace ExamWork.Models
{
    public partial class Person
    {
        public int Artist_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birthday { get; set; }
        public char Sex { get; set; }

        public virtual Artist Artists { get; set; }
    }
}
