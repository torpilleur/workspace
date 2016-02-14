using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SNAP.Database;

namespace SNAP
{
    /// <summary>
    /// Logique d'intéraction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        //création de la base de donnée pour le projet SNAP.

        public SNAP_DATABASE Ctx_database_SNAP = new SNAP_DATABASE();
        
        


        /**************************************FONCTIONS ajoutées par administrateur**************************/
        public void Afficher_Joueurs()
        {

            List<Entity_joueurs> List_table_joueur = Ctx_database_SNAP.Table_Joueurs.ToList();
            dataGrid.Items.Clear();
          
            for (int i = 0; i < List_table_joueur.Count(); i++)
            {
                Grid_data_panel_joueurs joueur_i=new Grid_data_panel_joueurs();
                joueur_i.Nom = List_table_joueur[i].Nom;
                joueur_i.Surnom = List_table_joueur[i].Surnom;
                joueur_i.Arme_primaire = List_table_joueur[i].Arme_primaire;
                joueur_i.Arme_secondaire = List_table_joueur[i].Arme_secondaire;
                joueur_i.Profil = List_table_joueur[i].Profil;

                dataGrid.Items.Add(joueur_i);
            }
        



        }
        public bool Ajouter_Joueurs(SNAP_DATABASE Contexte_database,string Nom_joueur, string Surnom_joueur, string Arme_primaire_joueur, string Arme_secondaire_joueur,string Profil_joueur)
        {
            //regarder si les chanmps ne sont pas vides
            if (Nom_joueur != "" && Surnom_joueur != "" && Arme_primaire_joueur != "" && Arme_secondaire_joueur != "" && Profil_joueur != "")
            //regarder si le joueur est déjà présent
            {
                var Liste_joueurs = Contexte_database.Database.SqlQuery<string>("SELECT Surnom FROM Entity_joueurs").ToList();
                for(int i =0;i<Liste_joueurs.Count();i++)
                {
                    if (Liste_joueurs.ElementAt(i).ToString().Equals(Surnom_joueur))
                    {
                        MessageBox.Show("Ce surnom est déjà utilisé. Choisir un autre surnom");
                        return false;
                    }
                }
                    Entity_joueurs Joueur = new Entity_joueurs
                {

                    Nom = Nom_joueur,
                    Surnom = Surnom_joueur,
                    Arme_primaire = Arme_primaire_joueur,
                    Arme_secondaire = Arme_secondaire_joueur,
                    Profil = Profil_joueur,
                };

                Contexte_database.Table_Joueurs.Add(Joueur);
                Contexte_database.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Les champs ne doivent pas être vides"+"\nLes champs non applicables doivent être remplis avec NA" );
                return false;
            }

        }
        public bool Modifier_Joueurs(SNAP_DATABASE Contexte_database, string Nom_joueur, string Surnom_joueur, string Arme_primaire_joueur, string Arme_secondaire_joueur, string Profil_joueur)
        {

            //regarder si les chanmps ne sont pas vides
            if (Nom_joueur != "" && Surnom_joueur != "" && Arme_primaire_joueur != "" && Arme_secondaire_joueur != "" && Profil_joueur != "")

            {
                //récupération de l'ID unique grâce au surom
                var index_joueur = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + Surnom_joueur + "'").ToList().ElementAt(0);
                //Récupération du joueur et de ses paramètres.
                var Joueur_tomodify = Contexte_database.Table_Joueurs.Find(index_joueur);
                //Modifier le joueur grâce à une nouvelle entrée.
                Entity_joueurs updatedUser = Joueur_tomodify;
                updatedUser.Nom = Nom_joueur;
                updatedUser.Surnom = Surnom_joueur;
                updatedUser.Arme_primaire = Arme_primaire_joueur;
                updatedUser.Arme_secondaire = Arme_secondaire_joueur;
                updatedUser.Profil = Profil_joueur;

                // mise à jour et sauvegarde du contexte.
                Contexte_database.Entry(Joueur_tomodify).CurrentValues.SetValues(updatedUser);
                Contexte_database.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("Les champs ne doivent pas être vides" + "\nLes champs non applicables doivent être remplis avec NA");
                return false;
            }
        }
        public void Supprimer_Joueurs(SNAP_DATABASE Contexte_database,Grid_data_panel_joueurs Joueur_selected)
        {
             //récupération de l'ID unique grâce au surom
           var index_joueur = Contexte_database.Database.SqlQuery<int>("SELECT id FROM Entity_Joueurs WHERE Surnom ='" + Joueur_selected.Surnom.ToString() + "'").ToList().ElementAt(0);
            //récupération de l'entité du joueur à supprimer
           Entity_joueurs Joueur_to_delete = Contexte_database.Table_Joueurs.Find(index_joueur);
            //suppression du joueur en base de donnée et sauvegarde
            Contexte_database.Table_Joueurs.Remove(Joueur_to_delete);
            Contexte_database.SaveChanges();      
        }

        /**************************************FIN FONCTIONS ajoutées par administrateur********************************/


        private void button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void bouton_joueurs_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_joueur.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_terrain.Visibility = Visibility.Hidden;
            panel_video.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
            Afficher_Joueurs();

        }

        private void bouton_stats_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_stats.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_terrain.Visibility = Visibility.Hidden;
            panel_video.Visibility = Visibility.Hidden;
            panel_joueur.Visibility = Visibility.Hidden;
        }

        private void bouton_terrain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_terrain.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_joueur.Visibility = Visibility.Hidden;
            panel_video.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
        }

        private void bouton_video_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_video.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_terrain.Visibility = Visibility.Hidden;
            panel_joueur.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
        }

        private void bouton_configuration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_configuration.Visibility = Visibility.Visible;
            panel_joueur.Visibility = Visibility.Hidden;
            panel_terrain.Visibility = Visibility.Hidden;
            panel_video.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
         
        }

    

     
        private void Panel_joueur_bouton_ajouter_joueur_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            //afficher la popup
            Popup_Rens_Joueur.IsOpen = true;
            //rendre inactif les autres boutons
            button_modifier_joueur.IsEnabled = false;
            button_supprimer_joueur.IsEnabled = false;
            bouton_stats.IsEnabled = false;
            bouton_configuration.IsEnabled = false;
            bouton_terrain.IsEnabled = false;
            bouton_partie.IsEnabled = false;

            //vider les champs
            Rens_nom.Text = "";
            Rens_surnom.Text = "";
            Rens_arme_primaire.Text = "";
            Rens_arme_secondaire.Text = "";
            Rens_profil.Text = "";


        }

       

        private void Popup_bouton_ajouter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool Success_ajout_joueur = false;
            
            //ajouter le joueur en base de donnée aprés vérification de l'existant (pas deux joueurs avec le meme nom)
            Success_ajout_joueur= Ajouter_Joueurs(Ctx_database_SNAP, Rens_nom.Text.ToString(), Rens_surnom.Text.ToString(), Rens_arme_primaire.Text.ToString(), Rens_arme_secondaire.Text.ToString(), Rens_profil.Text.ToString());
            Afficher_Joueurs();
            if (Success_ajout_joueur == true)
            {
                //fermer la popup
                Popup_Rens_Joueur.IsOpen = false;
                //rendre les autres bouons actifs
                button_modifier_joueur.IsEnabled = true;
                button_supprimer_joueur.IsEnabled = true;
                bouton_stats.IsEnabled = true;
                bouton_configuration.IsEnabled = true;
                bouton_terrain.IsEnabled = true;
                bouton_partie.IsEnabled = true;
            }
        }

        private void Popup_bouton_annuler_MouseleftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //pas de récupération de données => fermer la popup
            Popup_Rens_Joueur.IsOpen = false;
            //rendre les autres boutons actifs
            button_modifier_joueur.IsEnabled = true;
            button_supprimer_joueur.IsEnabled = true;
            bouton_stats.IsEnabled = true;
            bouton_configuration.IsEnabled = true;
            bouton_terrain.IsEnabled = true;
            bouton_partie.IsEnabled = true;
        }

        private void Panel_joueur_bouton_supprimer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //todo:
            //system de checkbox pour sélectionner un joueur?
            button_ajouter_joueur.IsEnabled = false;
            button_modifier_joueur.IsEnabled = false;
            bouton_stats.IsEnabled = false;
            bouton_configuration.IsEnabled = false;
            bouton_terrain.IsEnabled = false;
            bouton_partie.IsEnabled = false;
            //récupération du nomm du joueur et suppression de la base de données aprés une demande de confirmation.
            Grid_data_panel_joueurs Joueur_selected = (Grid_data_panel_joueurs)dataGrid.SelectedItem;
            if(Joueur_selected!=null)
            {
                Supprimer_Joueurs(Ctx_database_SNAP, Joueur_selected);
                Afficher_Joueurs();

            }
            else {
                MessageBox.Show("Veuillez séléctionner un joueur dans la liste");
                //rendre inactif les autres boutons


            }
            button_ajouter_joueur.IsEnabled = true;
            button_modifier_joueur.IsEnabled = true;
            bouton_stats.IsEnabled = true;
            bouton_configuration.IsEnabled = true;
            bouton_terrain.IsEnabled = true;
            bouton_partie.IsEnabled = true;
        }

        private void panel_joueur_bouton_modifier_mouseleftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            //rendre inactif les autres boutons
            button_ajouter_joueur.IsEnabled = false;
            button_supprimer_joueur.IsEnabled = false;
            bouton_stats.IsEnabled = false;
            bouton_configuration.IsEnabled = false;
            bouton_terrain.IsEnabled = false;
            bouton_partie.IsEnabled = false;
            //viderles champs de la popup:
            Modif_Nom.Text = "";
            Modif_Surnom.Text = "";
            Modif_Arme_primaire.Text = "";
            Modif_Arme_secondaire.Text = "";
            Modif_Profil.Text = "";


            //system de checkbox pour sélectionner un joueur?
     
            int index = dataGrid.SelectedIndex;
            
            if (index != -1)
            {
                var Liste_joueurs = Ctx_database_SNAP.Database.SqlQuery<string>("SELECT Surnom FROM Entity_joueurs").ToList();
                string _Surnom = Liste_joueurs.ElementAt(index);

                IEnumerable<Entity_joueurs> mds = Ctx_database_SNAP.Table_Joueurs.Where(
                              p => p.Surnom == _Surnom);
                Entity_joueurs Joueur_to_modify = mds.ElementAt(0);

                //récupération du nom et du surnom
                Modif_Nom.Text = Joueur_to_modify.Nom;
                Modif_Surnom.Text = Joueur_to_modify.Surnom;
                Modif_Arme_primaire.Text = Joueur_to_modify.Arme_primaire;
                Modif_Arme_secondaire.Text = Joueur_to_modify.Arme_secondaire;
                Modif_Profil.Text = Joueur_to_modify.Profil ;

                //affichage d'une popup "modifier joueur" avec les champs préremplis
                Popup_Modif_Joueur.IsOpen = true;

            }
            else {
                MessageBox.Show("Veuillez séléctionner un joueur dans la liste");
                //rendre inactif les autres boutons
                button_ajouter_joueur.IsEnabled = true;
                button_supprimer_joueur.IsEnabled = true;
                bouton_stats.IsEnabled = true;
                bouton_configuration.IsEnabled = true;
                bouton_terrain.IsEnabled = true;
                bouton_partie.IsEnabled = true;

            }
            dataGrid.SelectedValue = null;


        }

        private void Popup_Modif_bouton_modifier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //todo:
            // récupération des données
            //mise à jour de la base de données
            bool Success_modif_joueur = Modifier_Joueurs(Ctx_database_SNAP, Modif_Nom.Text, Modif_Surnom.Text, Modif_Arme_primaire.Text, Modif_Arme_secondaire.Text, Modif_Profil.Text);
            //message de confirmation base de donnée à jour.
            Afficher_Joueurs();
            if (Success_modif_joueur == true)
            {
                //fermer la popup
                Popup_Modif_Joueur.IsOpen = false;
                //rendre les autres boutons actifs
                button_ajouter_joueur.IsEnabled = true;
                button_supprimer_joueur.IsEnabled = true;
                bouton_stats.IsEnabled = true;
                bouton_configuration.IsEnabled = true;
                bouton_terrain.IsEnabled = true;
                bouton_partie.IsEnabled = true;
            }
            

        }

        private void Popup_Modif_bouton_annuler_MouseleftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //fermer la popup sans récupération des données.
            Popup_Modif_Joueur.IsOpen = false;
            //rendre les autres boutons actifs
            button_ajouter_joueur.IsEnabled = true;
            button_supprimer_joueur.IsEnabled = true;
            bouton_stats.IsEnabled = true;
            bouton_configuration.IsEnabled = true;
            bouton_terrain.IsEnabled = true;
            bouton_partie.IsEnabled = true;
        }

    }
}
