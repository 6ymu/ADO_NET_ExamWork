using System;
using System.Collections.Generic;

#nullable disable

namespace ExamWork.Models
{
    public partial class Artist
    {
        public Artist()
        {
         
        }

        public int Artist_id { get; set; }
        public int Genre_id { get; set; }
        public int Country_id { get; set; }
        public string Artist_Site_URL { get; set; }
        

        public virtual Country Countries { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Genre>  Genres { get; set; }
        
        
    }
}
