using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BD_Lab7_Herasimenka
{
     class TrackContext : DbContext
    {
        public TrackContext(string TrackDbConnection) : base(TrackDbConnection)
        {
            Database.SetInitializer(new DataBaseInitializer());
        }

        public DbSet<Track> Tracks { get; set; }
    }
}
