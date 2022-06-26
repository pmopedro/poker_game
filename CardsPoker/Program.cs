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
                        #region Game
                        Croupier dealer = new Croupier();
                        dealer.creat_cards();
                        dealer.shuffle();
                        dealer.set_deck();
                         
                        Person player1 = new Person("Goku");
                        Person player2 = new Person("Piccolo");
                        Person mesa = new Person("Mesa");

                        player1.set_card(dealer.get_card(), 1);
                        player1.set_card(dealer.get_card(), 1);
                        Console.WriteLine("Mão do Goku");
                        Show.show_cards(player1.get_hand());

                        player2.set_card(dealer.get_card(), 2);
                        player2.set_card(dealer.get_card(), 2);
                        Console.WriteLine("Mão do Piccolo");
                        Show.show_cards(player2.get_hand());

                        for (int i=0; i<5; i++){
                            mesa.set_card(dealer.get_card(), 0);
                        }
                        Console.WriteLine("Cartas da Mesa");
                        Show.show_cards(mesa.get_hand());

                        Test test1 = new Test(); // new Test object
                        // test1.load_cards();
                        test1.load_dealer_cards(player1.get_hand(),mesa.get_hand()); //load from file
                        test1.build_histogram();
                        int rank1 = test1.test_rank();

                        Test test2 = new Test(); // new Test object
                        test2.load_dealer_cards(player2.get_hand(),mesa.get_hand()); //load from file
                        test2.build_histogram();
                        int rank2 = test2.test_rank();

                        Console.WriteLine("Terminei de testar o ranking!");
                        
                        if(rank1 < rank2){
                            Console.WriteLine("Goku é o ganhador");
                        } else if(rank1 > rank2){
                            Console.WriteLine("Piccolo é o ganhador");
                        } else{
                            Console.WriteLine("Empate!!");
                        }

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