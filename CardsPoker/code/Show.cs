namespace CardsPoker.code
{
    public class Show
    {
        public static void show_menu()
        {
            //Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1 - Test");
            Console.WriteLine("2 - Game");
            Console.WriteLine("---------------------------------------------------");
        }

        public static void show_restart()
        {
            //Console.Clear();
            Console.WriteLine("---------------------------------------------------");            
            Console.WriteLine("Choose a option: ");
            Console.WriteLine("1 - Restart\n2 - Exit\n");
            Console.WriteLine("---------------------------------------------------");

        }

        public static void show_cards (List<Card> cards)
        {
            //Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("A list of cards");
            Console.WriteLine("---------------------------------------------------");
            foreach (var item in cards)
            {
                string tmp = item.ToString();
                Console.WriteLine(tmp);                
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("---------------------------------------------------");
            Console.ReadKey();
        }

        public static void show_histogram(List<List<Card>> histo)
        {
        	int ctrl = 0;

            //Console.Clear();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("A list of cards");
            Console.WriteLine("---------------------------------------------------");
        	foreach(var list in histo)
        	{
        		if (list.Count == 0)
        			Console.WriteLine($"Cards in index: {ctrl} - 0");
        		else
                {
                    Console.WriteLine($"Cards in index: {ctrl}");		
        			for (int i = 0 ; i < list.Count ; i++)        			
        				Console.WriteLine("\t" + list[i].ToString());
                }
        		ctrl++;
        	}
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("---------------------------------------------------");
            Console.ReadKey();
        }       
    }
}