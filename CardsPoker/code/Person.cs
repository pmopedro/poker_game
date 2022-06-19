namespace CardsPoker.code
{
    public class Person
    {
        private string name;
        private List<Card> hand;

        public Person(string name_)
        {
            name = name_;
            hand = new List<Card>();
        }
        public string get_name()
        {
            return name;
        }
        public void set_card(Card c, int owner)
        {
            c.set_owner(owner);
            hand.Add(c);
        }
        public List<Card> get_hand ()
        {
            return hand;
        }
    }
}