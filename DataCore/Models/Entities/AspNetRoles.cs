﻿using System;
using System.Collections.Generic;

namespace DataCore.Models.Entities
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            MenuRole = new HashSet<MenuRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<MenuRole> MenuRole { get; set; }
    }
}
