using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace AzureBlog.Models
{
    [Table("Voters")]

    public class VoterModel
    {
        [Key]
        public int VoterId { get; set; }
        public string VoterIPAddress { get; set; }
        public int ArticleSegmentId { get; set; }
    }
}
