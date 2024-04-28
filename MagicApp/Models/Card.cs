using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MagicApp.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string Rarity { get; set; }
        [Required]
        public int ManaCost { get; set; }
        public int? Power { get; set; }
        public int? Toughness { get; set; }

        // properties to configure many to many relationship with Color table
        [ValidateNever]
        public List<Color> Colors { get; set; }
        [ValidateNever]
        public List<CardColor> CardColors { get; set; }

        // properties to configure many to many relationship with SuperType table
        [ValidateNever]
        public List<SuperType> SuperTypes { get; set; }
        [ValidateNever]
        public List<CardSuperType> CardSuperTypes { get; set; }

        // properties to configure many to many relationship with CardType table
        [ValidateNever]
        public List<CardType> CardTypes { get; set; }
        [ValidateNever]
        public List<CardCardType> CardCardTypes { get; set; }

        //public int SetId { get; set; }
        //[ValidateNever]
        //public MagicSet MagicSet { get; set; } = null!;

    } // end class
} // end namespace
