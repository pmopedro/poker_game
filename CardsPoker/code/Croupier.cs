
namespace CardsPoker.code
{
    public class Croupier
    {
        private List<Card> cards_list;
        private Stack<Card> deck;

        public Croupier ()
        {
            cards_list = new List<Card>();
            deck = new Stack<Card>();
        }

        public List<Card> get_list()
        {
            return cards_list;
        }

        public Card get_card() 
        {
            return deck.Pop();
        }
        
        public void creat_cards()
        {
            for (int i = 0 ; i < 13 ; i++)
            {
                Card c1 = new Card((i+1), 0, "Hearts");
                Card c2 = new Card((i+1), 0, "Diamonds");
                Card c3 = new Card((i+1), 0, "Clubs");
                Card c4 = new Card((i+1), 0, "Spades");

                cards_list.Add(c1);
                cards_list.Add(c2);
                cards_list.Add(c3);
                cards_list.Add(c4);
            }
        }

        public void shuffle()
        {
            // Creating a object
            // for Random class
            Random rnd = new Random();
            
            // Start from the last element and
            // swap one by one. We don't need to
            // run for the first element
            // that's why i > 0
            for (int i = cards_list.Count - 1; i > 0; i--)
            {                
                // Pick a random index
                // from 0 to i
                int j = rnd.Next(0, i+1);
                
                // Swap arr[i] with the
                // element at random index
                Card temp = new Card (cards_list[i]);
                cards_list[i] = cards_list[j];
                cards_list[j] = temp;
            }            
        }

        public void set_deck ()
        {
            for (int i = 0 ; i < cards_list.Count ; i++)
            {
                deck.Push(cards_list[i]);
            }
        }
    }
}