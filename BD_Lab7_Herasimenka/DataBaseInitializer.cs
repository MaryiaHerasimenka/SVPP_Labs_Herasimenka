using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BD_Lab7_Herasimenka
{
    class DataBaseInitializer : DropCreateDatabaseIfModelChanges<TrackContext>
    {
        protected override void Seed(TrackContext context)
        {
            context.Tracks.AddRange(new Track[] {
                new Track
                {
                    TrackTitle = "Enter Sandman",
                    TrackDuration = new TimeSpan(0, 5, 31),
                    ArtistName = "Metallica",
                    AlbumTitle = "Metallica"
                },
                new Track
                {
                    TrackTitle = "Bohemian Rhapsody",
                    TrackDuration = new TimeSpan(0, 5, 55),
                    ArtistName = "Queen",
                    AlbumTitle = "A Night at the Opera"
                },
                new Track
                {
                    TrackTitle = "Imagine",
                    TrackDuration = new TimeSpan(0, 3, 4),
                    ArtistName = "John Lennon",
                    AlbumTitle = "Imagine"
                }
        });
        }
    }
}