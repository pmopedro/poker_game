namespace CardsPoker.code
{
    public class Card
    {
        private int value, owner;
        private string suit;
        public Card (int v, int o, string s)
        {
            value = v;
            owner = o;
            suit  = s;
        }
        public Card (Card c) 
        {
            value = c.get_value();
            owner = c.get_owner();
            suit = c.get_suit();
        }


        public static bool operator == (Card a, Card b)
        {
            if (
                    a.get_value() == b.get_value() &&
                    a.get_owner() == b.get_owner() &&
                    a.get_suit()  == b.get_suit()
               )
               { return true;}
            
            return false;
        }

        public static bool operator != (Card a, Card b)
        {
            if (
                    a.get_value() != b.get_value() ||
                    a.get_owner() != b.get_owner() ||
                    a.get_suit()  != b.get_suit()
               )
               { return true;}
            
            return false;
        }
        public int get_value()
        {
            return value;
        }
        public int get_owner()
        {
            return owner;
        }
        public void set_owner(int o)
        {   
            owner = o;
        }
        public string get_suit()
        {
            return suit;
        }

        public override string ToString()
        {
            string card_text = "Suit: " + suit;
            card_text += "\tValue: " + value;
            card_text += "\tOwner: " + owner;            
            return  card_text;
        }        
    }
}