using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidldyWinksWordCup
{
    internal class Team : IComparable<Team>
    {
        // Attributes
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        // Constructors

        // Methods
        int CalculateTotalTeamPoints()
        {
            int totalPoints = 0;

            foreach (Player player in Players)
            {
                totalPoints += player.CalculatePoints();
            }

            return totalPoints;
        }

        public override string ToString()
        {
            return $"{Name} - {Players.Count} - {CalculateTotalTeamPoints()}";
        }

        public int CompareTo(Team other)
        {
            return other.CalculateTotalTeamPoints().CompareTo(this.CalculateTotalTeamPoints());
        }
    }
}
