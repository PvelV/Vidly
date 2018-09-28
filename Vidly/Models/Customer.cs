﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }
        public DateTime? Birthday { get; set; }
        public bool IsSubscribed { get; set; }

        public byte MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }
    }
}