using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidldyWinksWordCup
{
    internal class Team
    {
        // Attributes
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        // Constructors
        public Team() {}

        public Team(string name)
        {
            Name = name;
        }

        // Methods
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
