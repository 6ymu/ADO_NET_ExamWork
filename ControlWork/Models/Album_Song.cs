using System;
using System.Collections.Generic;

#nullable disable

namespace ExamWork.Models
{
    public partial class Album_Song
    {
        public int Album_id { get; set; }
        public int Song_id { get; set; }
        public int Track_number { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual Album Albums { get; set; }
    }
}
