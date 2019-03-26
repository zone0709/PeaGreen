﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class PaymentPartner
    {
        public int Id { get; set; }
        public string PartnerName { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
    }
}
