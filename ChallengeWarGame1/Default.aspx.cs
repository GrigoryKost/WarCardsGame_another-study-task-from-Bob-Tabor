using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeWarGame1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "<H1> Dealing cards!</H1></BR>";
            var Deck = new Deck();
            Displayresults(Deck);


        }

        protected void shuffleButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "<H1> Deck of cards has been shuffled!</H1></BR>";
            var Deck = new Deck();
            Deck.Shuffle(Deck.deck);

            Displayresults(Deck);

        }

        public void Displayresults(Deck deck)
        {
            foreach (var card in deck.deck)
            {
                resultLabel.Text += string.Format("{0}. &nbsp;{1} of {2} </BR>", card.Num, card.grade, card.suit);
            }
        }

        protected void distributeButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "<H1> Deck of cards has been shuffled!</H1></BR>";

            var Game = new Game("Grigory", "Venya");
            Game.Distribute();
            Displayresults(Game._deck);
            displayDistributedCards(Game);

            /*
            foreach (var card in Game._player1.PlayerDeck)
            {
                resultLabel.Text += string.Format("<tr><td></td><td>{0} is dealt the {1} of {2} </td></tr>" +
                    "",
                
                    Game._player1.Name, card.grade, card.suit);
                
            }
            */

        }

        private void displayDistributedCards(Game Game)
        {
            resultLabel.Text += "<H1> Dealing cards!</H1></BR>";

            resultLabel.Text += "</BR></BR><table><tr><td><b>"
                + Game._player1.Name.ToUpper() + "</b></td><td><b>" + Game._player2.Name.ToUpper() + "</b></td></tr>";
            for (int i = 0; i < Game._player1.PlayerDeck.Count; i++)
            {
                resultLabel.Text += string.Format("<tr><td>{0} of {1}</td><td>{2} of {3}</td></tr>" +
                    "", Game._player1.PlayerDeck.ElementAt(i).grade, Game._player1.PlayerDeck.ElementAt(i).suit,
                    Game._player2.PlayerDeck.ElementAt(i).grade, Game._player2.PlayerDeck.ElementAt(i).suit);
            }
            resultLabel.Text += "</table>";
        }



        protected void NumbersHexTextButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "\x0041\x0042";
            //string A = "A";
            
            for (int i = 0; i < 10000; i++)
            {
                resultLabel.Text += i + "&nbsp;&nbsp;" + i.ToString("X")+ "&nbsp;&nbsp;=" + "16*"+ Math.Floor((double)i/16) +"+" + (int)i%16 + " </BR>";
            }
            
        }

        protected void stringHexTestButton_Click(object sender, EventArgs e)
        {
            byte[] ba = Encoding.Default.GetBytes(inputTextBox.Text);
            var hexString = BitConverter.ToString(ba);
            resultLabel.Text = hexString.ToString();
            
        }

        protected void playButton_new_Click(object sender, EventArgs e)
        {

            resultLabel.Text = "<H1> Deck of cards has been shuffled!</H1></BR>";
            var Game = new Game("Grigory", "Venya");
            Game.Distribute();
            Displayresults(Game._deck);
            displayDistributedCards(Game);
            

            resultLabel.Text += Game.Play();
        }

        
    }
}