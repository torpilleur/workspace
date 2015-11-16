using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAP
{
    class SampleData : System.Data.Entity.DropCreateDatabaseAlways<SNAP_DATABASE>
    {
        protected override void Seed(SNAP_DATABASE context)
        {
            new List<Entity_joueurs_db>
           {
               new Entity_joueurs_db
               {
                     Nom="Damien",
                     Surnom ="torpilleur",
                     Arme_primaire ="mp5",
                     Arme_secondaire="M92",
                     Profil ="meneur",
                },
               new Entity_joueurs_db
               {
                     Nom="Benjamin",
                     Surnom ="darkfenouil",
                     Arme_primaire ="colt",
                     Arme_secondaire="NA",
                     Profil ="looser",
                }

           }.ForEach(i => context.Db_Joueurs.Add(i));

        }
    }
}
