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

        public void test_rank()
        {
            if (royal.check()) // Royal flush
            {
                Console.WriteLine("Royal Flush");
                //not implemented yet
            }
            else if (straight.check()) // Straight flush
            {
                Console.WriteLine("Straight Flush");
                //not implemented yet
            }
            else if (full.check()) // Full house
            {
                Console.WriteLine("Full House");
                //not implemented yet
            }
            else if (flush.check()) // Flush
            {
                Console.WriteLine("Flush");
                //not implemented yet
            }
            else if (straight.check()) // Straight
            {
                Console.WriteLine("Straight Flush");
                //not implemented yet
            }
            else if (two.check()) // Two pair
            {
                Console.WriteLine("Two Pairs");
                //not implemented yet
            }
            else if (pair.check()) // Pair
            {
                Console.WriteLine("Pair");
                //not implemented yet
            }
            else if (high.check()) // High card
            {
                Console.WriteLine("High card");
            }
        }
    }
}