using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenselink_Asg5_Yahtzee
{
    class Hand
    {
        private List<Die> hand = new List<Die>();

        public Hand()
        {
        }

        public void resetHand()
        {
            hand.Clear();

            for(int i = 0; i < 5; i++)
            {
                hand.Add(new Die());
            }
        }

        public void roll5Dice()
        {
            resetHand();
            for (int i = 0; i < 5; i++)
            {
                hand[i].rollDie();
            }
        }

        public void rollDice()
        {
            for (int i = 0; i < 5; i++)
            {
                if (hand[i].Keep != true)
                {
                    hand[i].rollDie();
                }
            }
        }

        public int getDieValue(int handIndex)
        {
            int dieValue = hand[handIndex].Value;

            return dieValue;
        }

        public void addDieToHand(Die die)
        {
            hand.Add(die);
        }

        public Die getDieFromHand(int handIndex)
        {
            Die die = hand[handIndex];

            return die;
        }

        public void removeDieFromHand(int handIndex)
        {
            hand.RemoveAt(handIndex);
        }

        public void insertDieIntoHand(Die die, int i)
        {
            hand.Insert(i, die);
        }

        public void toggleKeep(int handIndex)
        {
            Die die = getDieFromHand(handIndex);

            die.Keep = !die.Keep;
        }


    }
}
