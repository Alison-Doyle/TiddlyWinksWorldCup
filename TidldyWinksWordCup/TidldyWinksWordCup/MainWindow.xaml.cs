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
        private List<Team> teams = new List<Team>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayTeamPlayers(lbxTeams.SelectedIndex);
        }

        private void btnRecordWin_Click(object sender, RoutedEventArgs e)
        {
            int teamIndex = lbxTeams.SelectedIndex == null ? -1 : lbxTeams.SelectedIndex;
            int playerIndex = lbxPlayers.SelectedIndex == null ? -1 : lbxPlayers.SelectedIndex;

            if (teamIndex != -1 && playerIndex != -1)
            {
                teams[teamIndex].Players[playerIndex].UpdateResultRecord('W');
            }
            else
            {
                MessageBox.Show("Please ensure you have selected a team and player", "Error");
            }

        }

        private void btnRecordLoss_Click(object sender, RoutedEventArgs e)
        {
            int teamIndex = lbxTeams.SelectedIndex == null ? -1 : lbxTeams.SelectedIndex;
            int playerIndex = lbxPlayers.SelectedIndex == null ? -1 : lbxPlayers.SelectedIndex;

            if (teamIndex != -1 && playerIndex != -1)
            {
                teams[teamIndex].Players[playerIndex].UpdateResultRecord('L');
            }
            else
            {
                MessageBox.Show("Please ensure you have selected a team and player", "Error");
            }
        }

        private void btnRecordDraw_Click(object sender, RoutedEventArgs e)
        {
            int teamIndex = lbxTeams.SelectedIndex == null ? -1 : lbxTeams.SelectedIndex;
            int playerIndex = lbxPlayers.SelectedIndex == null ? -1 : lbxPlayers.SelectedIndex;

            if (teamIndex != -1 && playerIndex != -1)
            {
                teams[teamIndex].Players[playerIndex].UpdateResultRecord('D');
            }
            else
            {
                MessageBox.Show("Please ensure you have selected a team and player", "Error");
            }
        }

        private void DisplayTeamPlayers(int teamIndex)
        {
            ObservableCollection<Player> players = new ObservableCollection<Player>(teams[teamIndex].Players);

            lbxPlayers.ItemsSource = players;
        }

        private void GetData()
        {

            // Create sample teams
            Team t1 = new Team() { Name = "France", Players = new List<Player>() };
            Team t2 = new Team() { Name = "Italy", Players = new List<Player>() };
            Team t3 = new Team() { Name = "Spain", Players = new List<Player>() };

            // Create sample players and add them to appropriate team
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };
            t1.Players.Add(p1);
            t1.Players.Add(p2);
            t1.Players.Add(p3);

            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };
            t2.Players.Add(p4);
            t2.Players.Add(p5);
            t2.Players.Add(p6);

            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };
            t3.Players.Add(p7);
            t3.Players.Add(p8);
            t3.Players.Add(p9);

            // Add teams to teams observable collection
            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            // Update listbox
            UpdateTeamsListBox();
        }
    
        void UpdateTeamsListBox()
        {
            // Order teams in descending order by points
            teams.Sort();

            // Update listbox
            lbxTeams.ItemsSource = null;
            lbxTeams.ItemsSource = teams;
        }
    }
}
