using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TidldyWinksWordCup
{
    internal class Player
    {
        // Attributes
        public string Name { get; set; }
        public string ResultRecord { get; set; }

        // Constructos

        // Methods
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
