using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BD_Lab7_Herasimenka
{
        public class Track
    {
        public int TrackId { get; set; }
        public string TrackTitle { get; set; }
        public TimeSpan TrackDuration { get; set; }
        public string ArtistName { get; set; }
        public string AlbumTitle { get; set; }
    }

}
