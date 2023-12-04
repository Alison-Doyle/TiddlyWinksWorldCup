namespace TidldyWinksWordCup
{
    internal class Player
    {
        // Attributes
        public string Name { get; set; }
        public string ResultRecord { get; set; }

        // Constructos

        // Methods
        public int CalculatePoints()
        {
            int totalPoints = 0;

            // Cycle through each letter/result in result record
            for (int i = 0; i < ResultRecord.Length; i++)
            {
                int pointsToAdd = 0;

                // Select appropriate points for result
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

        public void UpdateResultRecord(char newResult)
        {
            string updatedResultString = ResultRecord;

            // Remove old result from string
            updatedResultString = updatedResultString.Remove(0, 1);

            // Add new result to string
            updatedResultString += newResult;

            ResultRecord = updatedResultString;
        }

        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {CalculatePoints()}";
        }
    }
}
