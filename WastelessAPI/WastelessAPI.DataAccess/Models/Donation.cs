using System;
using System.Collections.Generic;
using System.Text;

namespace WastelessAPI.DataAccess.Models
{
    public class Donation
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public Int32 CharityId { get; set; }
    }
}
