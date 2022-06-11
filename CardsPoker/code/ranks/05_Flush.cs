//Marcelo D. L. - 05/06/2022
//Cinco cartas de um mesmo naipe (sem ordem numérica).

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class Flush : Rank 
    {
        List<List<Card>> lists_tmp;
        List<Card> player;
        List<Card> flush;
        public Flush (List<List<Card>> h) : base (h)
        {
            lists_tmp = new List<List<Card>>();
            player = new List<Card>();
            flush = new List<Card>();
        }
        
        public override bool check()
        {
            bool find_ = false;
            List<Card> temp = new List<Card>();

            copy_cards();
            find_woner();
            
            //Caso 01: naipes iguais nas 2 cartas da pessoa
            if((player.Count == 2) && player[0].get_suit() == player[1].get_suit())
            {
                if(flush_01())
                {
                    find_ = true;
                    rank_find.AddRange(player);                    
                    rank_find.AddRange(flush);
                }
            }
            else//Caso 02: caso naipes diferentes
            {
                if(flush_02(player[0]))
                {
                    find_ = true;
                    rank_find.AddRange(player);
                    rank_find.AddRange(flush);
                }
                else if(flush_02(player[1]))
                {
                    find_ = true;
                    rank_find.AddRange(player);
                    rank_find.AddRange(flush);
                }
            }
            return find_;
        }
        
        private void copy_cards()
        {
            foreach (var list_ in lists)
            {
                if (list_.Count > 0)
                {
                    lists_tmp.Add(value_copy(list_));
                }
            }
        }
        
        private void find_woner()
        {
            foreach (var list_ in lists_tmp)
            {
                List<int> indexs = new List<int>();

                for (int i = 0 ; i < list_.Count ; i++)
                {
                    if (list_[i].get_owner() == 0)
                    {
                        indexs.Add(i);
                        player.Add(new Card(list_[i]));
                    }
                }
                foreach (var index  in indexs)
                {
                    list_.RemoveAt(index);
                }
            }
        }
    
        //Caso 01: naipes iguais nas 2 cartas da pessoa
        private bool flush_01()
        {
            string suit = player[0].get_suit();
            int count = 2;
            foreach (var list_ in lists_tmp)
            {
                foreach (var c in list_)
                {
                    if(c.get_suit() == suit)
                    {
                        flush.Add(new Card(c));
                        count++;
                        
                        if(count == 5)
                        {
                            return true;
                        }
                    }
                }
            }
            flush.Clear();
            return false;
        }

        private bool flush_02(Card c_)
        {
            string suit = c_.get_suit();
            int count = 1;
            
            foreach (var list_ in lists_tmp)
            {
                foreach (var c in list_)
                {
                    if(c.get_suit() == suit)
                    {
                        flush.Add(new Card(c));
                        count++;
                        
                        if(count == 5)
                        {
                            return true;
                        }
                    }
                }
            }
            flush.Clear();
            return false;
        }

    }
}