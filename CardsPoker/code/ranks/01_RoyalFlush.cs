//Marcelo D. L. - 05/06/2022
//Sequência de mesmo naipe do 14 até o 10

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class RoyalFlush : Rank 
    {
        List<Card> player; // armazena as cartas da pessoa
        List<List<Card>> royal; // temporaria para a sequencia especifica
        //construtor da classe atual e da classe base
        public RoyalFlush (List<List<Card>> h) : base (h) 
        {
            player = new List<Card>();
            royal = new List<List<Card>>();
        }


        //implementacao especifica da classe RoyalFlush
        //para o metodo abstrato da classe base
        public override bool check()
        {
            if(chek_straight())
            {
                if(faind_woner())                
                {
                    if((player.Count == 1) && (case_02(player[0])))
                    {
                        return true;    
                    }
                    else if (player.Count == 2) 
                    {
                        if (case_02(player[0]))
                            return true;
                        
                        if (case_02(player[1]))
                            return true;
                    }
                }
            }
            return false;
        }

        //verifica se existem cartas nas posicoes que satisfacam 
        //a sequencia 10/11/12/13/14 
        private bool chek_straight()
        {
            int cout = 0;
            if(lists[1].Count > 0 )
            {
                cout++;
            }
            for (int i = 10 ; i < 14 ; i++)
            {
                if(lists[i].Count > 0 )
                {
                    cout++;
                }
            }       
            return cout == 5 ? true : false;
        }

        //separa de <lists> as listas especificas da sequencia
        //e coloca em <royal> 
        //verifica se existe em <royal> uma ou duas cartas da pessoa
        //caso exista coloca em <player>
        private bool faind_woner()
        {
            for (int i = 10; i < 14; i++)
            {
                royal.Add(value_copy(lists[i]));
            }
            royal.Add(lists[1]);

            foreach(var list_ in royal)
            {
                foreach (var card in list_)
                {
                    if(card.get_owner() == 0)
                    {
                        player.Add(card);
                    }
                }
            }
            if(player.Count > 0)
                return true;
            else
                return false;
        }
    
        /*
        private bool case_01()
        {
            string suite = player[0].get_suit();
            int count = 0;

            foreach(var list_ in royal)
            {
                foreach (var card in list_)
                {
                    if(card == player[0])
                    {
                        count++;
                        rank_find.Add(card);
                    }
                    else if (card.get_suit() == suite)
                    {
                        rank_find.Add(card);
                        count++;
                        
                        if (count == 5)
                            return true;
                    }
                }
            }
            if (count < 5)
                rank_find.Clear();
            
            return false;
        }*/

        //recebe uma das cartas da pessoa
        // procura por cartas na sequncia com mesmo naipe
        private bool case_02(Card c)
        {
            string suite = c.get_suit();
            int count = 0;
            
            foreach(var list_ in royal)
            {
                foreach (var card in list_)
                {
                    Console.WriteLine("card: " + card.ToString());
                    Console.ReadKey();
                    if(card == c)
                    {
                        count++;
                        rank_find.Add(card);
                    }
                    else if (card.get_suit() == suite)
                    {
                        rank_find.Add(card);
                        count++;
                    }
                }
            }
            if (count < 5)
            {
                rank_find.Clear();
                return false;
            }
            else if (count == 5) 
            {
                return true;
            }
            else
            {
                Console.WriteLine("Logic error");
                Console.ReadKey();
                return false;
            }
        }
    }
}