//Marcelo D.L. - 05/06/202
//Três cartas de um mesmo valor numérico
//(sem considerar naipe).

using System;
using System.Collections.Generic;


namespace CardsPoker.code.ranks
{
    public class ThreeKind : Rank
    {
        List<List<Card>> three;
        public ThreeKind (List<List<Card>> h) : base (h) 
        {
            three = new List<List<Card>>();
        }

        public override bool check()
        {
            bool find_ = false;
            List<Card> list_tmp = new List<Card>();
            int index = -1;

            find_three();

            if(three.Count > 0)
            {
                for(int i = 0 ; i < three.Count ; i++)
                {
                    if(check_woner(three[i]))
                    {
                        list_tmp = value_copy(three[i]);
                        find_ = true;
                    }
                }
                
                if (find_)
                {
                    for(int i = 0 ; i < list_tmp.Count ; i++)
                    {
                        if(list_tmp[i].get_owner() == 0)
                        {
                            index = i;
                            rank_find.Add(list_tmp[i]);
                        }
                    }
                    list_tmp.RemoveAt(index);
                    rank_find.Add(list_tmp[0]);
                    rank_find.Add(list_tmp[1]);                    
                }
            }
            return find_;
        }

        private void find_three()
        {
            foreach (var list in lists)
            {
                if(list.Count >= 3)
                {
                    three.Add(value_copy(list));
                }
            }
        }
    }
}