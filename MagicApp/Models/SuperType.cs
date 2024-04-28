namespace MagicApp.Models
{
    public class SuperType
    {
        public int SuperTypeId { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = [];
        public List<CardSuperType> SuperTypes { get; set;} = []; 
    } // end class model
} // end namespace
