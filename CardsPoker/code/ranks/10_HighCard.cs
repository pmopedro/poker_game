//Marcelo D.L. - 05/06/2022
//Maior valor numérico
namespace CardsPoker.code.ranks
{
    public class HighCard : Rank
    {
        public HighCard (List<List<Card>> h) : base (h) {}

        public override bool check()
        {
            bool find = true;
            List<Card> temp_list = new List<Card>();

            foreach (var list in lists)
            {
                foreach (var c in list)
                {
                    if (c.get_owner() == 0)
                        temp_list.Add(new Card(c));
                }
            }

            Card c1_tmp = temp_list[0];
            Card c2_tmp = temp_list[1];

            if (c1_tmp.get_value() == 1)
                rank_find.Add(new Card(c1_tmp));
            
            else if (c2_tmp.get_value() == 1)
                rank_find.Add(new Card(c2_tmp));
            
            else if (c1_tmp.get_value() >= c2_tmp.get_value())
                rank_find.Add(new Card(c1_tmp));

            else
                rank_find.Add(new Card(c2_tmp));

            return find;
        }
    }
}