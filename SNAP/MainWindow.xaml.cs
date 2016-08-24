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
        public Grid_data_panel_joueurs Grid_panel_joueurs = new Grid_data_panel_joueurs();
        
       
      
       

        /**************************************GESTION DES EVENEMENTS DU SOFT********************************/


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
            panel_partie.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
            Grid_panel_joueurs.Afficher_Joueurs(Ctx_database_SNAP, dataGrid);
        

        }

        private void bouton_stats_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_stats.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_terrain.Visibility = Visibility.Hidden;
            panel_partie.Visibility = Visibility.Hidden;
            panel_joueur.Visibility = Visibility.Hidden;
        }

        private void bouton_terrain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_terrain.Visibility = Visibility.Visible;
            panel_configuration.Visibility = Visibility.Hidden;
            panel_joueur.Visibility = Visibility.Hidden;
            panel_partie.Visibility = Visibility.Hidden;
            panel_stats.Visibility = Visibility.Hidden;
        }

        private void bouton_video_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            panel_partie.Visibility = Visibility.Visible;
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
            panel_partie.Visibility = Visibility.Hidden;
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
            Success_ajout_joueur= Grid_panel_joueurs.Ajouter_Joueurs(Ctx_database_SNAP, Rens_nom.Text.ToString(), Rens_surnom.Text.ToString(), Rens_arme_primaire.Text.ToString(), Rens_arme_secondaire.Text.ToString(), Rens_profil.Text.ToString());
            Grid_panel_joueurs.Afficher_Joueurs(Ctx_database_SNAP, dataGrid);
        
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
            
            button_ajouter_joueur.IsEnabled = false;
            button_modifier_joueur.IsEnabled = false;
            bouton_stats.IsEnabled = false;
            bouton_configuration.IsEnabled = false;
            bouton_terrain.IsEnabled = false;
            bouton_partie.IsEnabled = false;
            //récupération du nomm du joueur et suppression de la base de données aprés une demande de confirmation.
            Grid_data_panel_joueurs Grid_panel_joueurs_selected = (Grid_data_panel_joueurs)dataGrid.SelectedItem;
            if(Grid_panel_joueurs_selected != null)
            {
                Grid_panel_joueurs.Supprimer_Joueurs(Ctx_database_SNAP, Grid_panel_joueurs_selected);
                Grid_panel_joueurs.Afficher_Joueurs(Ctx_database_SNAP, dataGrid);
            }
            else {
                MessageBox.Show("Veuillez séléctionner un joueur dans la liste");
               

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
            
            // récupération des données
            //mise à jour de la base de données
            bool Success_modif_joueur = Grid_panel_joueurs.Modifier_Joueurs(Ctx_database_SNAP, Modif_Nom.Text, Modif_Surnom.Text, Modif_Arme_primaire.Text, Modif_Arme_secondaire.Text, Modif_Profil.Text);
            
            Grid_panel_joueurs.Afficher_Joueurs(Ctx_database_SNAP, dataGrid);
        
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
