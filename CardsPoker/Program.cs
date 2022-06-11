using System;
using CardsPoker.code.ranks;
namespace CardsPoker.code
{    
    public class Program
    {
        //----------------------------------------------------------------------
        static void Main(string[] args)
        {
            //game
            //test

            bool go = true;
            int option = 0;
            Console.Clear();
            //Card c1 = new Card(1,1,"Spades");

            //Card temp = new Card(CardsPokerEmJogo[i]);

            while(go)
            {
                Show.show_menu();
                option = get_option();

                switch (option)
                {
                    //----------------------------------------------------------
                    case 1:
                       
                        #region Test
                        Test test = new Test(); // new Test object
                        test.load_cards(); //load from file
                        Show.show_cards(test.get_cards()); //show a list of cards
                        
                        test.build_histogram();
                        test.test_rank();

                        #endregion
                        break;
                    //----------------------------------------------------------
                    //----------------------------------------------------------
                    case 2:
                        #region Hand
                        Hand hand = new Hand(); // new Test object
                        hand.load_cards(); //load from file
                        Show.show_cards(hand.get_cards()); //show a list of all cards
                        Console.WriteLine("Mostrei as cartas");
                        hand.build_histogram();
                        Console.WriteLine("Terminei de montar o histograma");
                        hand.test_rank();
                        Console.WriteLine("Terminei de testar o ranking!");
                        #endregion
                        break;
                    //----------------------------------------------------------
                    //----------------------------------------------------------
                    default:
                        break;
                    //----------------------------------------------------------
                }
                
    			Show.show_restart();
                option = get_option();

                // expression (true or false) ? (in true case) : (in false case)
                go = option == 2 ? false : true;
                
            }            
        }

        //----------------------------------------------------------------------
        //método da classe Progrman
        public static int get_option()
        {
            //
            int opt = 0;                      
            while (true)
            {
                Int32.TryParse(Console.ReadLine(), out opt);

                if(opt >= 1 && opt <= 2)
                    break;
                else
                    Console.WriteLine("Valid options: 1 or 2");
            }
            return opt;
        }
    }
}