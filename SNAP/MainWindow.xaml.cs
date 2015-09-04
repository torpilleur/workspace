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
        

        }

       

        private void Popup_bouton_ajouter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //todo:
            //vider les champs
            Rens_nom.Document.Blocks.Clear();
            Rens_surnom.Document.Blocks.Clear();
            Rens_arme_primaire.Document.Blocks.Clear();
            Rens_arme_secondaire.Document.Blocks.Clear();
            Rens_profil.Document.Blocks.Clear();

            //récupérer les infos des text box (test si vide)
            //ajouter le joueur en base de donnée aprés vérification de l'existant (pas deux joueurs avec le meme nom)
           
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
            //récupération du nomm du joueur et suppression de la base de données aprés une demande de confirmation.
            //message de confirmation
        }

        private void panel_joueur_bouton_modifier_mouseleftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //todo:
            //rendre inactif les autres boutons
            button_ajouter_joueur.IsEnabled = false;
            button_supprimer_joueur.IsEnabled = false;
            bouton_stats.IsEnabled = false;
            bouton_configuration.IsEnabled = false;
            bouton_terrain.IsEnabled = false;
            bouton_partie.IsEnabled = false;
            //viderles champs:
            Modif_nom.Document.Blocks.Clear();
            Modif_Surnom.Document.Blocks.Clear();
            Modif_Arme_primaire.Document.Blocks.Clear();
            Modif_Arme_secondaire.Document.Blocks.Clear();
            Modif_Profil.Document.Blocks.Clear();
            

            //system de checkbox pour sélectionner un joueur?
            //Récupération des infos en base de données.

            //affichage d'une popup "modifier joueur" avec les champs préremplis
            Popup_Modif_Joueur.IsOpen = true;

        }

        private void Popup_Modif_bouton_modifier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //todo:
            // récupération des données
            //mise à jour de la bse de données
            //message de confirmation base de donnée à jour.

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
