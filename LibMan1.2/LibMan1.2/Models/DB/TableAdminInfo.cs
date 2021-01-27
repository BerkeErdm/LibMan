using System;
using System.Collections.Generic;

namespace LibMan1._2.Models.DB
{
    public partial class TableAdminInfo
    {
        public int? Id { get; set; }
        public string Password { get; set; }

        public virtual TableUserInfo IdNavigation { get; set; }
    }
}
