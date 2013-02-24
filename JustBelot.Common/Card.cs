﻿namespace JustBelot.Common
{
    public struct Card
    {
        public Card(CardType type, CardSuit suit)
            : this()
        {
            this.Type = type;
            this.Suit = suit;
        }

        public CardType Type { get; set; }

        public CardSuit Suit { get; set; }

        public static Card operator ++(Card card)
        {
            var newCard = new Card(card.Type, card.Suit);

            if (newCard.Suit != CardSuit.Spades)
            {
                newCard.Suit++;
            }
            else
            {
                if (newCard.Type == CardType.Ace)
                {
                    newCard.Type = CardType.Seven;
                    newCard.Suit = CardSuit.Clubs;
                }
                else
                {
                    newCard.Type++;
                    newCard.Suit = CardSuit.Clubs;
                }
            }

            return newCard;
        }

        public override int GetHashCode()
        {
            return ((int)this.Type * 8) + (int)this.Suit;
        }

        public override string ToString()
        {
            var type = CardsHelper.CardTypeToString(this.Type);
            var color = CardsHelper.CardSuitToString(this.Suit);
            return string.Format("{0}{1}", type, color);
        }
    }
}