using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeWarGame1
{
    public class Card
    {
        public string suit { get; set; }
        public string grade { get; set; }
        public int gradeComparision { get; set; }
        public byte Num { get; set; }

        public Card()
        {
        }
        public Card(string suitt, int gradeComparision, byte Num): this()
        {
            string _grad;
            switch (gradeComparision)
            {
                case 11:
                    _grad = "Jack";
                    break;
                case 12:
                    _grad = "Queen";
                    break;
                case 13:
                    _grad = "King";
                    break;
                case 14:
                    _grad = "Ace";
                    break;
                default:
                    _grad =gradeComparision.ToString();
                    break;  
            }
            this.grade = _grad;
            this.suit = suitt;
            this.gradeComparision = gradeComparision;
            this.Num = Num;
        }


    }


}