using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AzureBlog.Models
{
    [Table("ArticleSegments")]

    public class ArticleSegmentModel
    {

        [Key]
      
        public int ArticleSegmentId { get; set; }
        public string ArticleSegmentTitle { get; set; }
        public string ArticleSegmentPar1 { get; set; }
        public string ArticleSegmentPar2 { get; set; }
        public string ArticleSegmentPar3 { get; set; }
        public string ArticleSegmentPar4 { get; set; }
        public string ArticleSegmentPar5 { get; set; }
        public string ArticleSegmentPar6 { get; set; }
        public string ArticleSegmentPar7 { get; set; }

        public string ArticleSegmentImage { get; set; }
        public string ArticleSegmentVideo { get; set; }

        public string ArticleSegmentAuthor { get; set; }
        public string ArticleSegmentEmail { get; set; }
        public string ArticleSegmentWebsite { get; set; }




        public bool Published { get; set; }

        public int Votes { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public virtual ArticleModel Article { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

    }
}