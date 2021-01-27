using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibMan1._2.Models.DB
{
    public partial class TableUserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Date { get; set; }
        public byte[] Photo { get; set; }

        public string PhotoPath { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
