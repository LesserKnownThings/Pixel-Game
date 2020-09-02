using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player
{
    public static class PlayerStats
    {
        public static int playerLives = 5;

        public static void GetHit()
        {
            playerLives--;
        }
    }
}
