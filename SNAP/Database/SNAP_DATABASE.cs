namespace SNAP.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SNAP_DATABASE : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Model1 » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « SNAP.Database.Model1 » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Model1 » dans le fichier de configuration de l'application.
        public SNAP_DATABASE()
            : base("name=SNAP_DATABASE")
        {
        }
  
        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<Entity_joueurs> Table_Joueurs { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class Entity_joueurs
    {
        public int ID { get; set; }

        public string Nom { get; set; }
        public string Surnom { get; set; }
        public string Arme_primaire { get; set; }
        public string Arme_secondaire { get; set; }
        public string Profil { get; set; }
    }
}