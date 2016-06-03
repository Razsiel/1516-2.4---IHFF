using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Interfaces;
using IHFF.Repositories;

using System.Net.Mail;

namespace IHFF.Controllers
{
    public class WishlistController : Controller
    {
        IWishlistRepository wishlistRepository = new WishlistRepository();
        IMovieRepository moviesRepository = new MoviesRepository();

        public ActionResult Index()
        {
            return View(Wishlist.Instance);
        }

        [HttpPost]
        public ActionResult AmountChange(int Amount, int WishlistItemId)
        {
            WishlistItem item = Wishlist.Instance.WishlistItems.First(x => x.WishlistItemId == WishlistItemId);
            item.Amount = Amount;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult SelectedChange(bool Selected, int WishlistItemId)
        {
            WishlistItem item = Wishlist.Instance.WishlistItems.First(x => x.WishlistItemId == WishlistItemId);
            item.Selected = Selected;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult GetWishlist(string UID)
        {
            Wishlist.Instance = wishlistRepository.GetWishlist(UID);
            return RedirectToAction(nameof(Index));
        }
        
        public ActionResult SaveWishlist(string Name, string Email)
        {
            if (ModelState.IsValid)
            {
                Wishlist.Instance.Name = Name;
                Wishlist.Instance.Email = Email;
                //wishlistRepository.SaveWishlist(Wishlist.Instance);  //Uncomment when RestaurantReservation work
                //SendEmail(Wishlist.Instance);
                return PartialView("_PopupSave", Wishlist.Instance);
            }
            return View(Wishlist.Instance);
        }

        public ActionResult Checkout(string Name, string Email)
        {
            if (ModelState.IsValid)
            {
                Wishlist.Instance.Name = Name;
                Wishlist.Instance.Email = Email;
                wishlistRepository.Checkout(Wishlist.Instance);
                return PartialView("_PopupOrder", Wishlist.Instance);
            }
            return RedirectToAction(nameof(Index));
        }
        
        public ActionResult RemoveItem(int WishlistItemId)
        {
            WishlistItem item = Wishlist.Instance.WishlistItems.First(x => x.WishlistItemId == WishlistItemId);
            wishlistRepository.Remove(Wishlist.Instance, item);
            return RedirectToAction(nameof(Index));
        }

        public bool SendEmail(Wishlist wishlist)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("system@IHFF.com");
            mail.To.Add(wishlist.Email);
            mail.Subject = "IHHF Wishlist code";
            mail.IsBodyHtml = true;

            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("<h2></h2>", wishlist.Name));
            sb.Append(string.Format("<h2></h2>", wishlist.UID));
            string html = sb.ToString();

            mail.Body = html;

            SmtpClient smtpClient = new SmtpClient("localhost");

            int count = 0;
            int maxTries = 3;
            while (count < maxTries)
            {
                try
                {
                    smtpClient.Send(mail);
                    return true;
                }
                catch (Exception)
                {
                    count++;
                }
            }
            return false;
        }
    }
}