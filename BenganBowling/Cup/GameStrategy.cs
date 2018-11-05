using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenganBowling.Cup
{
    /// <summary>

    /// The 'Strategy' abstract class

    /// </summary>
    public abstract class GameStrategy

    {
        public abstract int PlayGame(List<int> playerSetResult);
    }
}
