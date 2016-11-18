﻿using AbsenceTracker.DAL.Common.IDatabaseModels;
using AbsenceTracker.Model.Common.IDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsenceTracker.Model.DomainModels
{
    public class AspNetUserClaimsDomain : IAspNetUserClaimsDomain
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual IAspNetUsersDomain AspNetUsers { get; set; }
    }
}
