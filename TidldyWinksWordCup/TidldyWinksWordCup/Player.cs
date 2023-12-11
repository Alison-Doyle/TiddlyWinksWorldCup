namespace TidldyWinksWordCup
{
    internal class Player
    {
        // Attributes
        public string Name { get; set; }
        public string ResultRecord { get; set; }
        public int Points
        {
            get
            {
                int totalPoints = 0;

                // Cycle through each letter/result in result record
                for (int i = 0; i < ResultRecord.Length; i++)
                {
                    const char WinIndicator = 'W';
                    const char DrawIndicator = 'D';

                    int pointsToAdd = 0;

                    // Select appropriate points for result
                    if (ResultRecord[i] == WinIndicator)
                    {
                        pointsToAdd = 3;
                    }
                    else if (ResultRecord[i] == DrawIndicator)
                    {
                        pointsToAdd = 1;
                    }

                    totalPoints += pointsToAdd;
                }

                return totalPoints;
            }
        }

        // Constructors
        public Player ()
        {

        }

        public Player (string name, string results)
        {
            Name = name;
            ResultRecord = results;
        }

        // Methods
        public void UpdateResultRecord(char newResult)
        {
            string updatedResultString = ResultRecord;

            // Remove oldest result from beginning of string
            updatedResultString = updatedResultString.Remove(0, 1);

            // Add new result to end of string
            updatedResultString += newResult;

            ResultRecord = updatedResultString;
        }

        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {Points}";
        }
    }
}
