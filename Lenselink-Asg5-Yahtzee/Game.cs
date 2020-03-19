using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenselink_Asg5_Yahtzee
{
    class Game
    {
        private int upperScore;
        private int lowerScore;
        private int bonusScore;
        private int rollNumber;
        private int turnNumber;

        public int UpperScore { get => upperScore; set => upperScore = value; }
        public int LowerScore { get => lowerScore; set => lowerScore = value; }
        public int BonusScore { get => bonusScore; set => bonusScore = value; }
        public int RollNumber { get => rollNumber; set => rollNumber = value; }
        public int TurnNumber { get => turnNumber; set => turnNumber = value; }

        public int getUpperScore()
        {
            return UpperScore;
        }

        public void addToUpper(int scoreToAdd)
        {
            UpperScore = UpperScore + scoreToAdd;
        }

        public void addToLower(int scoreToAdd)
        {
            LowerScore = LowerScore + scoreToAdd;
        }

        public void addToBonus(int scoreToAdd)
        {
            BonusScore = BonusScore + scoreToAdd;
        }

        public int getTotalScore()
        {
            int totalScore = UpperScore + LowerScore + BonusScore;
            return totalScore;
        }
    }
}
