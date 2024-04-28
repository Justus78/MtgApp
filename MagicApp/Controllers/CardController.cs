using Microsoft.AspNetCore.Mvc;
using MagicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicApp.Controllers
{
    public class CardController : Controller
    {
        public CardContext Context { get; set; }
        public CardController(CardContext context) { Context = context; }
        public IActionResult CardList()
        {
            ViewBag.CardColors = Context.CardColors.OrderBy(c => c.CardId).ToList();
            ViewBag.CardSuperTypes = Context.CardSuperTypes.OrderBy(c => c.CardId).ToList();
            ViewBag.CardCardTypes = Context.CardCardTypes.OrderBy(ct => ct.CardId).ToList();
            var cards = Context.Cards.OrderBy(ca => ca.CardName).ToList();            
            return View(cards);
        } // end action results

        [HttpGet]
        public IActionResult AddCard() {
            ViewBag.Colors = Context.Colors.OrderBy(c => c.ColorId).ToList();
            ViewBag.SuperTypes = Context.SuperTypes.OrderBy(c => c.SuperTypeId).ToList();
            ViewBag.CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList();
            return View(new Card()); 
        } // end get action

        [HttpPost]
        public IActionResult AddCard(Card card, int[] selectedSuperType, int[] selectedCardType, int[] selectedColor) {
            if (ModelState.IsValid) {
                
                Context.Add(card);
                Context.SaveChanges();

                foreach (var i in selectedSuperType) {
                    var cc = new CardSuperType { CardId = card.CardId, SuperTypeId = i };
                    Context.CardSuperTypes.Add(cc);
                } // end foreach to add supertypes

                foreach (var ct in selectedCardType) {
                    var cc = new CardCardType { CardId = card.CardId, CardTypeId = ct };
                    Context.CardCardTypes.Add(cc);
                } // end foreach to add supertypes
                
                foreach (var i in selectedColor) {
                    var cc = new CardColor { CardId = card.CardId, ColorId = i };
                    Context.CardColors.Add(cc);
                } // end foreach to add colors

                Context.SaveChanges();
                return RedirectToAction("CardList", "Card");
            } else {
                ViewBag.SuperTypes = Context.SuperTypes.OrderBy(c => c.SuperTypeId).ToList();
                ViewBag.Colors = Context.Colors.OrderBy(c => c.ColorId).ToList();
                ViewBag.CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList();
                return View();
            } // end if else            
        } // end post action

        [HttpGet]
        public IActionResult DeleteCard(int id)
        {
            var card = Context.Cards.Find(id);
            return View(card);
        } // end get delete

        [HttpPost]
        public IActionResult DeleteCard(Card card)
        {
            Context.Cards.Remove(card);
            Context.SaveChanges();
            return RedirectToAction("CardList", "Card");
        } // end post delete

        [HttpGet]
        public IActionResult EditCard(int id)
        {
            var card = Context.Cards.Find(id);
            ViewBag.Colors = Context.Colors.OrderBy(c => c.ColorId).ToList();
            ViewBag.SuperTypes = Context.SuperTypes.OrderBy(c => c.SuperTypeId).ToList();
            ViewBag.CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList();
            return View(card);
        } // end get edit

        [HttpPost]
        public IActionResult EditCard(Card card, int[] selectedSuperType, int[] selectedCardType, int[] selectedColor)
        {
            if (ModelState.IsValid)
            {
                Context.Cards.Update(card);
                Context.SaveChanges();

                // remove all fields from CardColors table with CardId
                var cardColors = Context.CardColors.OrderBy(c => c.CardId).ToList();
                foreach (var c in cardColors) {
                    if (card.CardId == c.CardId) {
                        Context.CardColors.Remove(c);
                        //Context.SaveChanges();
                    } // end if
                } // end foreach

                // remove all fields from CardCardColors table with CardId
                var cardTypes = Context.CardCardTypes.OrderBy(ct => ct.CardId).ToList();
                foreach (var ct in cardTypes) {
                    if (card.CardId == ct.CardId) {
                        Context.Remove(ct);
                    } // end if 
                } // end foreach

                // remove all fields from CardSuperTypes table with CardId
                var superTypes = Context.CardSuperTypes.OrderBy(st => st.CardId);
                foreach(var type in superTypes) {
                    if (card.CardId == type.CardId) {
                        Context.CardSuperTypes.Remove(type);
                        //Context.SaveChanges();
                    } // end if
                } // end foreach

                // add new CardColors to the CardColor table for CardId
                foreach (var i in selectedColor) {
                    var cc = new CardColor { CardId = card.CardId, ColorId = i };
                    Context.CardColors.Add(cc);
                    //Context.SaveChanges();
                } // end foreach

                // add new CardCardTypes to the CardCardType tables for cardId
                foreach (var i in selectedCardType) {
                    var cc = new CardCardType { CardId = card.CardId, CardTypeId = i };
                    Context.CardCardTypes.Add(cc);
                } // end foreach to add supertypes

                // add new CardSuperTypes to the CardSuperType table fot CardId
                foreach (var i in selectedSuperType) {
                    var cc = new CardSuperType { CardId = card.CardId, SuperTypeId = i };
                    Context.CardSuperTypes.Add(cc);
                } // end foreach to add supertypes

                Context.SaveChanges();
                return RedirectToAction("Cardlist", "Card");
            } else
            {
                ViewBag.Colors = Context.Colors.OrderBy(c => c.ColorId).ToList();
                ViewBag.SuperTypes = Context.SuperTypes.OrderBy(c => c.SuperTypeId).ToList();
                ViewBag.CardCardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList();
                return View(card);
            } // end if else
        } // end post edit


    } //end controller
} // end namespace
