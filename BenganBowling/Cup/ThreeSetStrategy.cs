using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Cup
{
    /// <summary>

    /// A 'ConcreteStrategy' class

    /// </summary>
    public class ThreeSetStrategy : GameStrategy

    {
        public override int PlayGame(List<int>playerSetResult)
        {
            var playerTotalResult = 0;
            foreach (var result in playerSetResult)
            {
                playerTotalResult += result;
            }

            return playerTotalResult;
        }
    }
}
