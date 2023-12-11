using System;
using System.Collections.Generic;

namespace TidldyWinksWordCup
{
    internal class Team : IComparable<Team>
    {
        // Attributes
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        // Constructors
        public Team ()
        {

        }

        public Team(string name, List<Player> players)
        {
            Name = name;
            Players = players;
        }

        // Methods
        int CalculateTotalTeamPoints()
        {
            int totalPoints = 0;

            foreach (Player player in Players)
            {
                totalPoints += player.Points;
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
