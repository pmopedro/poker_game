namespace CardsPoker.code.ranks
{
    public abstract class Rank
    {
        protected List<List<Card>> lists; // histogram
        protected List<Card> rank_find; // em caso de achar a sequenciaS

        public Rank(List<List<Card>> l)
        {
            lists = l;
            rank_find = new List<Card>();
        }

        public List<Card> get_find()
        {
            return rank_find;
        }

        //verifica se na lista passada existe uma carta com owner == 0
        protected bool check_woner(List<Card> l)
        {
            foreach (var c in l)
            {
                if (c.get_owner() == 0)
                    return true;
            }
            return false;
        }

        //Percorre a lista de listas e retorna uma lista
        //com as duas cartas da pessoa
        protected List<Card> copy_woner()
        {
            List<Card> list = new List<Card>();

            foreach (var l in lists)
            {
                foreach (var c in l)
                {
                    if(c.get_owner() == 0)
                    {
                        list.Add(new Card (c));
                    }
                }
            }
            return list;
        }
        
        //Retorna uma copia (valores nao referencia) da lista
        //passada por parametro
        protected List<Card> value_copy (List<Card> l)
        {
            List<Card> list_copy = new List<Card>();
            
            foreach (var c in l)
            {
                list_copy.Add(new Card(c));
            }
            return list_copy;
        }
        
        //metodo abstrato, toda classe que herda precisa 
        //implementar sua versao
        public abstract bool check ();
    }
}