using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChallengeWarGame1
{
    public class Game
    {
        public Player _player1 { get; set; }
        public Player _player2 { get; set; }
        public Random _random { get; set; }
        public Deck _deck { get; set; }
        public StringBuilder _sb { get; set; }
        private List<Card> _bounty;

        public Game(string playerName1, string playerName2)
        {
            _player1 = new Player();
            _player1.Name = playerName1;
            _player1.PlayerDeck = new List<Card>();

            _player2 = new Player();
            _player2.Name = playerName2;
            _player2.PlayerDeck = new List<Card>();

            _deck = new Deck();
            _deck.Shuffle(_deck.deck);
            _sb = new StringBuilder();
            _bounty = new List<Card>();


        }

        public void Distribute()
        {
            int orderOfDistribution = 1;
           foreach (var card in _deck.deck)
            {
                
               if (!IsEven(orderOfDistribution))
                {
                    _player1.PlayerDeck.Add(card);
                }
               else
                {
                    _player2.PlayerDeck.Add(card);
                }


                orderOfDistribution++;
            }
        }
        private static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        public string Play()
        {
            _sb.Append("<H2>Game begins!</H2></BR><Table>");
            int round = 0;
            while (_player1.PlayerDeck.Count !=0 && _player2.PlayerDeck.Count !=0)
            {
                /*
                Card CurrentCard1 = _player1.PlayerDeck.ElementAt(0);
                Card CurrentCard2 = _player2.PlayerDeck.ElementAt(0);
                */
                Card CurrentCard1 = getCard(_player1);
                Card CurrentCard2 = getCard(_player2);

                performEvaluation(CurrentCard1, CurrentCard2);
              

                round++;
                    if (round > 20) break;

                
            }

            string result = determineWinner();
            _sb.Append("</TABLE>");
            _sb.Append("<br/> " + result + "</br>");
            result = _sb.ToString();
            return result;
        }

        

        private Card getCard(Player player)
        {
            Card card = player.PlayerDeck.ElementAt(0);
            player.PlayerDeck.Remove(card);
            _bounty.Add(card);

            return card;
        }

        private void putCard(Player winner, Card winnerCard, Card bountyCard)
        {
            //taking winnerCard and putting it back to transfer it to the end of the deck
            winner.PlayerDeck.Remove(winnerCard);
            winner.PlayerDeck.Add(winnerCard);
            winner.PlayerDeck.AddRange(_bounty);
            _bounty.Clear();
            _sb.Append("<TR><TD>Winner: " + winner.Name +"</TD><TD>"+ winnerCard.grade + " of " + winnerCard.suit
                + " </ TD ><TD>  vs </TD><TD>" + 
                bountyCard.grade + " of " + bountyCard.suit + "</TD></TR>");

        }
        private void performEvaluation(Card card1, Card card2)
        {
            if (card1.gradeComparision > card2.gradeComparision)
            {
                putCard(_player1, card1, card2);
            }
            else if (card1.gradeComparision < card2.gradeComparision)
            {
                putCard(_player2, card1, card2);
            }
            else if (card1.gradeComparision == card2.gradeComparision)
            {
                Battle.Skirmish(_player1, _player2);
            };
        }
        private string determineWinner()
        {
            string result = "";
            if (_player1.PlayerDeck.Count > _player2.PlayerDeck.Count)
                result += "</br>"+ _player1.Name +" wins";
            else
                result += "</br>" + _player2.Name + " wins";

            result += "</br>Player "+_player1.Name+ ": " + _player1.PlayerDeck.Count +
                " Player " + _player2.Name + ": " + _player2.PlayerDeck.Count;
            return result;
        }

    }
}