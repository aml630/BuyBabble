﻿using AzureBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nager.AmazonProductAdvertising.Model;
using Nager.AmazonProductAdvertising;


namespace AzureBlog.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Category
        public ActionResult Post(string articleSlug)
        {

            var article = db.Articles.Where(x => x.ArticleSlug == articleSlug).Include(x => x.ArticleSegments).ToList();

            List<ProductModel> sortedProducts = db.Products.OrderByDescending(x => x.ProductPrice).ToList();

            ViewBag.Products = sortedProducts;
            ViewBag.First = sortedProducts.First();

            return View(article);
        }
        public ActionResult CreateArticle(string name, string slug)
        {
            var article = new ArticleModel();
            article.ArticleName = name;
            article.ArticleSlug = slug;
            article.ArticlePic = "http://cats.com/wp-content/uploads/2016/01/1200x280.jpg";
            article.ArticlePublished = false;
            article.Intro = "intro";
            article.FbShares = 0;
            article.TwitShares = 0;
            db.Articles.Add(article);

            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddSegment(int id, string Title, string Body, string Par2, string Par3, string Image, string Video, string ArticleSlug)
        {
            var newSegment = new ArticleSegmentModel();
            newSegment.ArticleId = id;
            newSegment.ArticleSegmentTitle = Title;
            newSegment.ArticleSegmentPar1 = Body;
            newSegment.ArticleSegmentPar2 = Par2;
            newSegment.ArticleSegmentPar3 = Par3;
            newSegment.ArticleSegmentImage = Image;
            newSegment.ArticleSegmentVideo = Video;

            db.ArticleSegments.Add(newSegment);
            db.SaveChanges();

            var article = db.Articles.Where(x => x.ArticleSlug == ArticleSlug).Include(x => x.ArticleSegments).ToList();


            return View("Post", article);
        }

        public ActionResult AddProduct(int segId, string ASIN, string artSlug)
        {



            var authentication = new AmazonAuthentication();
            authentication.AccessKey = "AKIAICYKGU63S3DNQMZQ";
            authentication.SecretKey = "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";

            var wrapper = new AmazonWrapper(authentication, AmazonEndpoint.US, "alexl0a-20");
            var result = wrapper.Lookup(ASIN);

            var changeNum = Double.Parse(String.Format("{0,0:N2}", Int32.Parse(result.Items.Item[0].OfferSummary.LowestNewPrice.Amount) / 100.0));

            var newProduct = new ProductModel();
            newProduct.ProductName = result.Items.Item[0].ItemAttributes.Title;
            newProduct.ProductSlug = "hey";
            newProduct.ProductImg = result.Items.Item[0].LargeImage.URL;
            newProduct.ProductLink = result.Items.Item[0].DetailPageURL;
            newProduct.ProductPrice = changeNum;
            newProduct.ProductDescription = result.Items.Item[0].CustomerReviews.IFrameURL;
            newProduct.ProductArticle = false;
            newProduct.CategoryId = 4;
            newProduct.ArticleId = segId;


            db.Products.Add(newProduct);

            db.SaveChanges();

            var article = db.Articles.Where(x => x.ArticleSlug == artSlug).Include(x => x.ArticleSegments).ToList();

            ViewBag.Products = db.Products.ToList();

            return View("Post", article);
        }

        public ActionResult UpVote(int segId, string artSlug)
        {

            ArticleSegmentModel thisSeg = db.ArticleSegments.FirstOrDefault(x => x.ArticleSegmentId == segId);
            thisSeg.Votes = thisSeg.Votes + 1;
            db.SaveChanges();

            //List<ArticleSegmentModel> sortedLiskt = new List<ArticleSegmentModel>();

            //var thisArticle = db.Articles.FirstOrDefault(x => x.ArticleSlug == artSlug);

            //var allSegments = db.ArticleSegments.OrderBy(x =>x.Votes).Where(s => s.Article.ToList();


            var article = db.Articles.Where(x => x.ArticleSlug == artSlug).Include(x => x.ArticleSegments).ToList();

            //var sortedArticles = article.OrderBy(segment => segment.ArticleSegments.Votes);

            ViewBag.Products = db.Products.ToList();

            return View("Post", article);
        }


    }
}