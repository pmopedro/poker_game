//Marcelo D.L. - 05/06/2022
//Duas cartas valores numéricos iguais,
//mais duas cartas de mesmo valor numérico
// (diferente do primeiro valor).

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class TwoPair : Rank
    {
        protected List<List<Card>> pair_list;
        public TwoPair (List<List<Card>> h) : base (h)
        {
            pair_list = new List<List<Card>>();
        }
        
        public override bool check()
        {
            bool find_ = false;
            List<Card> pair1 = new List<Card>();
            List<Card> pair2 = new List<Card>();

            find_pair();

            if(pair_list.Count >= 2)
            {
                int index = -1;

                for (int i = 0 ; i < pair_list.Count ; i++)
                {
                    //procura woner
                    if(check_woner(pair_list[i]))
                    {
                        pair1 = value_copy(pair_list[i]);
                        index = i;
                    }
                }
                pair_list.RemoveAt(index);
                pair2 = value_copy(pair_list[0]);
            }

            if(pair1.Count > 0 && pair2.Count > 0)
            {

                find_ = true;
                if (pair1.Count > 2)
                {
                    foreach (var c in pair1)
                    {
                        if (c.get_owner() == 0)
                        {
                            rank_find.Add(new Card(c));
                            pair1.Remove(c);

                            rank_find.Add(new Card(pair1[0]));

                            break;
                        }
                    }
                }
                else
                {
                    rank_find.Add(pair1[0]);
                    rank_find.Add(pair1[1]);
                    rank_find.Add(pair2[0]);
                    rank_find.Add(pair2[1]);
                }
            }
            return find_;
        }

        protected void find_pair()
        {
            foreach(var list in lists)
            {
                if (list.Count >= 2)
                {
                    pair_list.Add(value_copy(list));
                }
            }
        }
    }
}