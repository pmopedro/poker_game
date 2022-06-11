//Marcelo D. L. - 05/06/2022
//Três cartas de um mesmo valor numérico e
//duas cartas de outro valor numérico.

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class FullHouse : Rank
    {
        private List<Card> player; // cartas da pessoa
        private List<Card> full_houe; // temporario para o full house
        private List<List<Card>> lists_full; // temporario para listas com cartas
        //construtor
        public FullHouse (List<List<Card>> h) : base (h) 
        {
            full_houe = new List<Card>();
            player = new List<Card>();
            lists_full = new List<List<Card>>();
        }
        
        //implementação especifica da funcao abstrata
        public override bool check()
        {
            player = copy_woner();
            copy_();

            Console.WriteLine("Player" );
            Show.show_cards(player);
            Console.ReadKey();

            if (player[0].get_value() == player[1].get_value())
            {
                if(find_01())
                {
                    return true;
                }
            }
            else 
            {
                if(find_02(player[0] , 1))
                    return true;

                else if(find_02(player[1] , 0))
                    return true;
            }
            return false;
        }

        //copia as listas de <lists>, sem as cartas da pessoa
        //adiciona em <lists_full>
        private void copy_()
        {
            foreach (var list_ in lists)
            {
                List<Card> tmp = new List<Card>();

                foreach (var c in list_)
                {
                    if ((player[0] != c) && (player[1] != c))
                    {
                        tmp.Add(new Card (c));
                    }
                }
                lists_full.Add(tmp);
            }
        }

        //caso as duas cartas da pessoa tenham o mesmo valor
        private bool find_01()
        {
            int value = player[0].get_value();
            
            if(lists_full[value].Count == 1)
            {
                rank_find.AddRange(player);
                rank_find.Add(lists_full[value][0]);

                foreach (var list_ in lists_full)
                {
                    if(list_.Count >= 2)
                    {
                        rank_find.Add(list_[0]);
                        rank_find.Add(list_[1]);
                    }
                }
                if(rank_find.Count == 5)
                    return true;
            }

            foreach (var list_ in lists_full)
            {
                if(list_.Count >= 3)
                {
                    rank_find.AddRange(player);

                    if(list_.Count == 3)
                    {
                        rank_find.AddRange(list_);
                    }
                    else
                    {
                        rank_find.Add(list_[0]);
                        rank_find.Add(list_[1]);
                        rank_find.Add(list_[2]);
                    }
                    return true;
                }
            }
            rank_find.Clear();
            return false;
        }
    
        //caso as cartas da pessoa tenham valores numericos difernetes
        private bool find_02 (Card c, int other)
        {
            int value = c.get_value();
            
            if(lists_full[value].Count == 3 || lists_full[value].Count == 2 )
            {
                rank_find.Add(new Card (c));
                rank_find.Add(lists_full[value][0]);
                rank_find.Add(lists_full[value][1]);

                for(int i = 0 ; i < lists_full.Count ; i++)
                {
                    if ((i != value) && (lists_full[i].Count == 2))
                    {
                        rank_find.AddRange(lists_full[i]);
                    }
                }

                if(rank_find.Count == 5)
                    return true;

            }
            else if(lists_full[value].Count == 1)
            {
                Console.WriteLine("find_02 - 1" );
                rank_find.Add(new Card (c));
                rank_find.Add(lists_full[value][0]);

                Show.show_cards(rank_find);
                Console.ReadKey();

                for(int i = 0 ; i < lists_full.Count ; i++)
                {
                    if ((i != value) && (lists_full[i].Count >= 3))
                    {
                        rank_find.Add(lists_full[i][0]);
                        rank_find.Add(lists_full[i][1]);
                        rank_find.Add(lists_full[i][2]);
                    }
                    else if((i != value) && (lists_full[i].Count == 2))
                    {
                        if(lists_full[i][0].get_value() == player[other].get_value())
                        {
                            rank_find.Add(lists_full[i][0]);
                            rank_find.Add(lists_full[i][1]);
                            
                            rank_find.Add(player[other]);
                        }
                    }
                }

                if(rank_find.Count == 5)
                    return true;

            }
            rank_find.Clear();        
            return false;
        }
    }
}