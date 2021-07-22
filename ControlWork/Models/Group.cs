using System;
using System.Collections.Generic;

#nullable disable

namespace ExamWork.Models
{
    public partial class Group
    {
        public int Artist_id { get; set; }
        public string Group_name { get; set; }

        public virtual Artist Artists { get; set; }
    }
}
