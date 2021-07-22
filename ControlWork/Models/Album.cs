using System;
using System.Collections.Generic;

#nullable disable

namespace ExamWork.Models
{
    public partial class Album
    {
        public Album()
        {
            Artists = new HashSet<Artist>();
        }

        public int Album_id { get; set; }
        public int Artist_id { get; set; }
        public string Album_title { get; set; }
        public int Album_year { get; set; }
        public int Album_tracks { get; set; }
        public virtual ICollection<Artist>  Artists { get; set; }
    }
}
