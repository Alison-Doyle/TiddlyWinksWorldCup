using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TidldyWinksWordCup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Team> teams = new ObservableCollection<Team>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            // Create sample teams
            Team frenchTeam = new Team("France");
            Team spanishTeam = new Team("Spain");
            Team italianTeam = new Team("Italy");

            // Add teams to observable collection
            teams.Add(frenchTeam);
            teams.Add(spanishTeam);
            teams.Add(italianTeam);

            // Bind observable collection to listbox for user
            lbxTeams.ItemsSource = teams;
        }
    }
}
