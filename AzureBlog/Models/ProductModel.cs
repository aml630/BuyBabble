using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AzureBlog.Models
{
    [Table("Products")]

    public class ProductModel
    {
            [Key]
            public int ProductId { get; set; }

            public string ProductName { get; set; }
            public string ProductSlug { get; set; }
            public string ProductImg { get; set; }
            public string ProductLink { get; set; }
            public double ProductPrice { get; set; }
            public string ProductDescription { get; set; }
            public bool ProductArticle { get; set; }
            public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public int ArticleId { get; set; }

        //public int ArticleSegmentId { get; set; }
        public virtual ArticleSegmentModel ArticleSegment { get; set; }

        public virtual ICollection<ReviewModel> Reviews { get; set; }


    }
}