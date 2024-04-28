namespace MagicApp.Models
{
    public class CardViewModel
    {
        public List<Card> Cards { get; set; } = null!;
        public List<Color> Colors { get; set; } = null!;
        public List<CardColor> CardColors { get; set; } = null!;
        public List<CardType> CardTypes { get; set; } = null!;
        public List<CardCardType> CardCardTypes { get; set; } = null!;
        public List<SuperType> SuperTypes { get; set; } = null!;
        public List<CardSuperType> CardSuperTypes { get; set; } = null!;


    } // end class
} // end namespace
