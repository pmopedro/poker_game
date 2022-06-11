//Marcelo D.L. - 05/06/2022
//Duas cartas de mesmo valor numérico
using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class OnePair : Rank
    {
        public OnePair (List<List<Card>> h) : base (h) {}

        public override bool check()
        {
            bool find_ = false;
            List<Card> list_tmp = new List<Card>();

            foreach (var list_ in lists)
            {
                if(list_.Count >= 2 && (!find_)) 
                {
                    list_tmp = value_copy(list_);
                    //Console.WriteLine("One Pair");
                    
                    if(check_woner(list_tmp))
                    {
                        //Console.WriteLine("One Pair - owner");
                        if(list_tmp.Count > 2)
                        {
                            foreach (var c in list_tmp)
                            {
                                if(c.get_owner() == 1)
                                {
                                    list_tmp.Remove(c);
                                    rank_find = list_tmp;
                                    find_ = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            rank_find = list_tmp;
                            find_ = true;
                        }
                    }
                }
            }
            return find_;
        }
    }
}