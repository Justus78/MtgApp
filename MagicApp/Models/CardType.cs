using System.ComponentModel.DataAnnotations;

namespace MagicApp.Models
{
    public class CardType
    {
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }

        public List<Card> Cards { get; set; }
        public List<CardCardType> CardTypes { get; set; }
    } // end model
} // end namespace
