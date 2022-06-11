using CardsPoker.code;
namespace CardsPoker.code.ranks
{
    public class Histogram
    {
        // member variables
		List<Card> to_organaize; // hold the cards to evaluate
		// a list of lists, 
		List<List<Card>> histogram;

//----------------------------------------------------------------
//constructor method
		public Histogram(List<Card> c_list)
		{
			to_organaize = new List<Card>();
			foreach (var c in c_list)
				to_organaize.Add(new Card(c));

			histogram = new List<List<Card>>();

			for (int i = 0 ; i < 14 ; i++)				
				histogram.Add(new List<Card>());
		}
//----------------------------------------------------------------

//----------------------------------------------------------------
//build quantification for rank
		//places a card on the list, in a specific index
		//according:  index/card value
		public void count_values()
		{
			for (int i = 0 ; i < to_organaize.Count; i++ )
			{
				//value variable kept the card value
				int value = to_organaize[i].get_value();
				//the card value is used por index position
				histogram[value].Add(new Card(to_organaize[i]));
			}
		}
//----------------------------------------------------------------
//get access 
		public List<List<Card>> get_histogram()
		{return histogram;}

		public List<Card> get_organized()
		{return to_organaize;}

//----------------------------------------------------------------

    }
}