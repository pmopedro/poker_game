using CardsPoker.code.ranks;
namespace CardsPoker.code
{
    public class Test
    {
        private List<Card> card_list;
        Histogram histo;
        HighCard high;
        OnePair pair;
        TwoPair two;
        ThreeKind three;
        Straight straight;
        Flush flush;
        FullHouse full;
        FourKind four;
        StraightFlush straightFlush;
        RoyalFlush royal;
        public Test()
        {
            card_list = new List<Card>();
            // histo = new Histogram();
        }

        public List<Card> get_cards()
        {
            return card_list;
        }

        public void load_cards()
        {
            card_list = Load.load_hand();
        }

        public void load_dealer_cards(List<Card> cardsList, List<Card> dealerList){
            card_list = cardsList.Concat(dealerList).ToList();;
        }

        public void build_histogram()
        {
            histo = new Histogram(get_cards());
            histo.count_values();
            high = new HighCard(histo.get_histogram());
            pair = new OnePair(histo.get_histogram());
            two = new TwoPair(histo.get_histogram());
            three = new ThreeKind(histo.get_histogram());

            straight = new Straight(histo.get_histogram());
            flush = new Flush(histo.get_histogram());
            full = new FullHouse(histo.get_histogram());
            four = new FourKind(histo.get_histogram());

            straightFlush = new StraightFlush(histo.get_histogram());
            royal = new RoyalFlush(histo.get_histogram());
        }

        public int test_rank()
        {
            if (royal.check()) // Royal flush
            {
                Console.WriteLine("Royal Flush");
                return 1;
            }
            else if (straight.check()) // Straight flush
            {
                Console.WriteLine("Straight Flush");
                return 2;//not implemented yet
            }
            else if (four.check()) // Full house
            {
                Console.WriteLine("Full House");
                return 3;
            }
            else if (full.check()) // Full house
            {
                Console.WriteLine("Full House");
                return 4;
            }
            else if (flush.check()) // Flush
            {
                Console.WriteLine("Flush");
                return 5; //not implemented yet
            }
            else if (straight.check()) // Straight
            {
                Console.WriteLine("Straight Flush");
                return 6; //not implemented yet
            }
            else if (three.check()) // Two pair
            {
                Console.WriteLine("Two Pairs");
                return 7;//not implemented yet
            }
            else if (two.check()) // Two pair
            {
                Console.WriteLine("Two Pairs");
                return 8;//not implemented yet
            }
            else if (pair.check()) // Pair
            {
                Console.WriteLine("Pair");
                return 9;//not implemented yet
            }
            else if (high.check()) // High card
            {

                Console.WriteLine("High card");
                return 10;
            }
            return 11;
        }
    }
}