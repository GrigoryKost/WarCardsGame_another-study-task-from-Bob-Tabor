using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWarGame1
{
    public class Deck
    {
        public List<Card> deck { get; set; }
        public Random _random { get; set; }

        public Deck()
        {
            List<Card> initialDeck = new List<Card>();
            
            Cycling(initialDeck, "Spade");
            Cycling(initialDeck, "Heart");
            Cycling(initialDeck, "Club");
            Cycling(initialDeck, "Diamond");

            _random = new Random();
            this.deck = initialDeck;
        }

        private void Cycling(List<Card> initialDeck, string suitt)
        {
            for (int i = 2; i < 15; i++)
            {
                initialDeck.Add(new Card (suitt, i, (byte)(initialDeck.Count+1)));
            }
        }
            public void Shuffle(List<Card> deck)
        {
            Card temp;
            int k;
            for (int i = 0; i < deck.Count; i++)
            {
                k = _random.Next(0, deck.Count);
                temp = deck[i];
                deck[i] = deck[k];
                deck[k] = temp;
            }
        }
        public Deck(Player player)
        {
            List<Card> initialDeck = new List<Card>();
            this.deck = initialDeck;
        }

    }

    
}