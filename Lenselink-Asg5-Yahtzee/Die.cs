using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenselink_Asg5_Yahtzee
{
    class Die
    {
        private int value;
        private bool keep;

        public int Value { get => value; set => this.value = value; }
        public bool Keep { get => keep; set => keep = value; }

        public Die()
        {

        }

        public void rollDie()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int randomNumber = random.Next(0, 6);
            randomNumber = randomNumber + 1;
            Value = randomNumber;
        }
    }
}
