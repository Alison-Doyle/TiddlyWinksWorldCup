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
        int CalculatePoints()
        {
            int totalPoints = 0;

            for (int i = 0; i < ResultRecord.Length; i++)
            {
                int pointsToAdd = 0;
                if (ResultRecord[i] == 'W')
                {
                    pointsToAdd = 3;
                }
                else if (ResultRecord[i] == 'D')
                {
                    pointsToAdd = 1;
                }

                totalPoints += pointsToAdd;
            }

            return totalPoints;
        }

        public override string ToString()
        {
            return $"{Name} - {CalculatePoints()}";
        }
    }
}
