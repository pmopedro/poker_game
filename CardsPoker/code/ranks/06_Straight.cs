//Marcelo D.L. - 05/06/2022
//Sequência numérica de cinco cartas
//(sem considerar naipe).

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class Straight : Rank
    {
        public Straight (List<List<Card>> h) : base (h) {}

        List<List<Card>> straight_ = new List<List<Card>>();
        public override bool check()
        {
            int index = -1;
            bool find_ = false;
            Card[] cards_tmp = new Card[5];
            find_straight();

            if (straight_.Count == 5)
            {
                for (int i = 0 ; i < 5 ; i++)
                {
                    if(check_woner(straight_[i]))
                    {
                        index = i;
                        foreach(var c in straight_[i])
                        {
                            if(c.get_owner() == 0)
                            {
                                cards_tmp[i] = new Card(c);
                            }
                        }
                    }
                }

                if (index != -1)
                {
                    for (int i = 0 ; i < 5 ; i++)
                    {
                        if(i != index)
                        {
                            cards_tmp[i] = new Card(straight_[i][0]);
                        }
                    }
                    find_ = true;
                    rank_find.AddRange(cards_tmp);
                }
            }
            return find_;
        }

        private void find_straight()
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
                    break;
                }
            }
        }
    }
}