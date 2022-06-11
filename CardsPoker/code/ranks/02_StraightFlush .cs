//Marcelo D.L. - 05/06/2022
//Sequência de mesmo naipe do exceto (14 até o 10)

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class StraightFlush : Rank
    {
        List<List<Card>>straight_; // armazenamento temporario de sequencia
        List<Card> player; // armazena cartas da pessoa
        //construtor
        public StraightFlush (List<List<Card>> h) : base (h) 
        {
            straight_ = new List<List<Card>>();
            player = new List<Card>();
        }
        
        //inplementacao especifica do metod abstrato nas classe base
        public override bool check()
        {
            if(find_straight() && find_woner())
            {                
                if(player.Count == 1)
                {
                    if(case_01())
                        return true;
                }
                else if(player.Count == 2)
                {
                    if(player[0].get_suit() == player[1].get_suit())
                    {
                        if(case_01())
                            return true;
                    }
                    else
                    {
                        if(case_02(player[0]) || case_02(player[1]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //procura sequencia no histogram
        // se encontrar salva em <straight_>
        private bool find_straight()
        {
            int count;
            for (int i = 1 ; i < 10 ; i++)
            {
                count = 0;
                straight_ = new List<List<Card>>();
                for (int j = i ; j < (i+5) ; j++)
                {
                    if(lists[j].Count > 0)
                    {
                        straight_.Add(value_copy(lists[j]));
                        count++;
                    }
                }
                
                if (count == 5)
                {
                    return true;
                }
            }
            return false;
        }

        // procura na sequiencia encontrada as cartas da pessoa
        //se encontrar adiciona em <player>
        private bool find_woner()
        {
            foreach (var list_ in straight_)
            {
                for (int i = 0; i < list_.Count ; i++)
                {
                    if(list_[i].get_owner() == 0)
                    {
                        player.Add(list_[i]);
                    }
                }
            }
            return player.Count > 0 ? true : false;
        }
        //caso so exista uma carta da pessoa na sequencia da
        //verifica se a sequencia tem mesmo naipe
        private bool case_01()
        {
            int cout = 1;
            string suit = player[0].get_suit();
            
            foreach (var list_ in straight_)
            {
                foreach (var c in list_)
                {
                    if(c == player[0])
                    {
                        rank_find.Add(c);
                    }
                    else if((c.get_suit() == suit) && (c.get_value() != player[0].get_value()))
                    {
                        rank_find.Add(c);
                        cout++;
                        if(cout == 5)
                            return true;
                    }
                }
            }
            return false; 
        }
        //Caso exista duas cartas da pessoa na sequencia
        //verifica mesmo naipeS
        private bool case_02(Card c_)
        {
            int cout = 0;
            string suit = c_.get_suit();
            
            foreach (var list_ in straight_)
            {
                foreach (var c in list_)
                {
                    if(c == c_)
                    {
                        rank_find.Add(c);
                        cout++;
                    }
                    else if((c.get_suit() == suit) )
                    {
                        rank_find.Add(c);
                        cout++;
                        if(cout == 5)
                            return true;
                    }
                }
            }
            return false;
        }
    }
}