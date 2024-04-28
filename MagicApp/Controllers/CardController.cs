using Microsoft.AspNetCore.Mvc;
using MagicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicApp.Controllers
{
    public class CardController : Controller
    {
        // create a CardContext property
        public CardContext Context { get; set; }

        // constructer for CardController
        public CardController(CardContext context) { Context = context; } // end constructor

        // action for CardList View
        public IActionResult CardList()
        {
            var model = new CardViewModel
            {
                // get data from database with each ViewModel property
                Cards = Context.Cards.OrderBy(c => c.CardId).ToList(),
                Colors = Context.Colors.OrderBy(c => c.ColorId).ToList(),
                CardColors = Context.CardColors.OrderBy(cc => cc.CardId).ToList(),
                CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList(),
                CardCardTypes = Context.CardCardTypes.OrderBy(cct => cct.CardId).ToList(),
                SuperTypes = Context.SuperTypes.OrderBy(st => st.SuperTypeId).ToList(),
                CardSuperTypes = Context.CardSuperTypes.OrderBy(cst => cst.CardId).ToList()
            };
           
            return View(model);
        } // end action results

        [HttpGet]
        public IActionResult AddCard() {
            var model = new CardViewModel
            {
                // get data from database with each ViewModel property
                Card = new Card(),
                Cards = Context.Cards.OrderBy(c => c.CardId).ToList(),
                Colors = Context.Colors.OrderBy(c => c.ColorId).ToList(),
                CardColors = Context.CardColors.OrderBy(cc => cc.CardId).ToList(),
                CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList(),
                CardCardTypes = Context.CardCardTypes.OrderBy(cct => cct.CardId).ToList(),
                SuperTypes = Context.SuperTypes.OrderBy(st => st.SuperTypeId).ToList(),
                CardSuperTypes = Context.CardSuperTypes.OrderBy(cst => cst.CardId).ToList()
            };
            return View(model); 
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
                var model = new CardViewModel
                {
                    // get data from database with each ViewModel property
                    Card = new Card(),
                    Cards = Context.Cards.OrderBy(c => c.CardId).ToList(),
                    Colors = Context.Colors.OrderBy(c => c.ColorId).ToList(),
                    CardColors = Context.CardColors.OrderBy(cc => cc.CardId).ToList(),
                    CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList(),
                    CardCardTypes = Context.CardCardTypes.OrderBy(cct => cct.CardId).ToList(),
                    SuperTypes = Context.SuperTypes.OrderBy(st => st.SuperTypeId).ToList(),
                    CardSuperTypes = Context.CardSuperTypes.OrderBy(cst => cst.CardId).ToList()
                };
                return View(model);
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
            //var card = Context.Cards.Find(id);
            //ViewBag.Colors = Context.Colors.OrderBy(c => c.ColorId).ToList();
            //ViewBag.SuperTypes = Context.SuperTypes.OrderBy(c => c.SuperTypeId).ToList();
            //ViewBag.CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList();
            var model = new CardViewModel
            {
                // get data from database with each ViewModel property
                Card = Context.Cards.Find(id),
                Cards = Context.Cards.OrderBy(c => c.CardId).ToList(),
                Colors = Context.Colors.OrderBy(c => c.ColorId).ToList(),
                CardColors = Context.CardColors.OrderBy(cc => cc.CardId).ToList(),
                CardTypes = Context.CardTypes.OrderBy(ct => ct.TypeId).ToList(),
                CardCardTypes = Context.CardCardTypes.OrderBy(cct => cct.CardId).ToList(),
                SuperTypes = Context.SuperTypes.OrderBy(st => st.SuperTypeId).ToList(),
                CardSuperTypes = Context.CardSuperTypes.OrderBy(cst => cst.CardId).ToList()
            };
            return View(model);
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
