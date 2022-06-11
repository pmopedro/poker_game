//Marcelo D.L. - 05/06/2022
//Classe que le arquivos de texto
using System.Runtime.InteropServices;
namespace CardsPoker.code
{
    public class Load
    {
        //this fuction ask for a file name (path)
        //return a list of cards build by file read
        public static List<Card> load_hand()
	    {
            List<Card> cards = new List<Card>();
            string path_file = Directory.GetCurrentDirectory();
            Console.WriteLine("\nDigite o nome do arquivo");
            
            //testa em qual sistema operacional o código está executando
            //linux e windows tem diferença na escrita do caminho
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path_file += "/cards_files/";

            }else
            {
                path_file += "\\cards_files\\";
            }
            
            
            path_file += Console.ReadLine();
            //this statement read all lines in file and returs a array
            //every array positiion conrrespond a one line  in file            
            string[] readText = File.ReadAllLines(path_file);


            foreach(var s in readText)
            {
                //this statement get a line s and split the values by separetor
                //every array position have a one peace
                string[] line = s.Split(';');
                {                    
                    Card card = new Card
                    (
                        int.Parse(line[0]),
                        int.Parse(line[1]),
                        line[2]
                    );
                    cards.Add(card);
        	    }
            }
            return cards;
        }
    }
}