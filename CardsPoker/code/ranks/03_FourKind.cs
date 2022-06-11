//Marcelo D.L. - 05/06/2022
//Quatro cartas de mesmo valor numérico

using System;
using System.Collections.Generic;

namespace CardsPoker.code.ranks
{
    public class FourKind : Rank 
    {
        public FourKind (List<List<Card>> h) : base (h) {}
        //procura uma lista em <lists> com 4 cartas
        //se encontrar procura por uma carta da pessoa
        public override bool check()
        {
            foreach (var list_ in lists)
            {
                if(list_.Count == 4)
                {
                    foreach (var c in list_)
                    {
                        if(c.get_owner() == 0 )
                        {
                            rank_find.AddRange(list_);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}