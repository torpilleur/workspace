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

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //panel_configuration.Visibility = Visibility.Hidden;
            //panel_joueur.Visibility = Visibility.Hidden;
            //panel_terrain.Visibility = Visibility.Hidden;
            //panel_video.Visibility = Visibility.Hidden;
            //panel_stats.Visibility = Visibility.Hidden;
        }

        
    }
}
