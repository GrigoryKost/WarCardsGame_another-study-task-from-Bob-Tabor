﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWarGame1
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> PlayerDeck { get; set; }
        public List<Card> PlayerBulk { get; set; }

        public Player()
        {
            
        }
    }


}