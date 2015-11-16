using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAP
{
    class Provider_joueurs_db
    {
        public Provider_joueurs_db()
        {

        }

        public List<Entity_joueurs_db> Get_All_Joueurs()
        {
            using (SNAP_DATABASE context = new SNAP_DATABASE())
            {
                return context.Db_Joueurs.ToList();
            }
        }
    }
}
