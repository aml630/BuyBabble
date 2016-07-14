using AzureBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureBlog.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index(int id)
        {
            var clickedProduct = db.Products.FirstOrDefault(x => x.ProductId == id);
            //ViewBag.Products = db.Products.Where(x => x.CategoryId == clickedProduct.CategoryId);
            return View(clickedProduct);
        }


        //public ActionResult AddReview(int productId, int testStars, string reviewText, string reviewAuthor, string categorySlug)
        //{

        //    string thisIp = GetUserIP();

        //    var alreadyReviewed = db.Reviews.FirstOrDefault(review => review.ReviewIP == thisIp && review.ProductId ==productId);

        //         if(alreadyReviewed == null)
        //    {
        //        var newReview = new ReviewModel();
        //        newReview.ProductId = productId;
        //        newReview.ReviewStars = testStars;
        //        newReview.ReviewText = reviewText;
        //        newReview.ReviewAuthor = reviewAuthor;
        //        newReview.ReviewIP = thisIp;

        //        db.Reviews.Add(newReview);
        //        db.SaveChanges();
        //    }

       
        //    return RedirectToAction("Index", "Category", new { id = categorySlug});
        //}


        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}