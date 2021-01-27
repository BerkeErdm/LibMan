using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibMan1._2.Models.DB
{
    public partial class TableBookInfo
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int? PageNumber { get; set; }
        public byte[] Image { get; set; }
        public string Publisher { get; set; }
        public string Imagee { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string BookSummary { get; set; }
        public string Categories { get; set; }
        public string ReadingStatus { get; set; }
        public string UserName { get; set; }

    }
}
