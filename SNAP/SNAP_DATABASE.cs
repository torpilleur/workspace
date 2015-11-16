using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SNAP
{
    public class SNAP_DATABASE :DbContext
    {
        public DbSet<Entity_joueurs_db> Db_Joueurs { get; set; }

        public SNAP_DATABASE() : base("SNAP_DATABASE")
        {
        }
    }
}
