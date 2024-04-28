namespace MagicApp.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public List<Card> Cards { get; set; } = [];
        public List<CardColor> CardCOlors { get; set; } = [];
    } // end class
} // end namespace
