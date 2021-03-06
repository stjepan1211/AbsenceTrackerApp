﻿using AbsenceTracker.Model.Common.IDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsenceTracker.Repository.Common.IRepository
{
    public interface IAspNetUserRepository
    {
        Task<int> Add(IAspNetUserDomain entity);
        Task<int> Delete(string id);
        Task<int> Delete(IAspNetUserDomain entity);
        Task<IAspNetUserDomain> Get(string id);
        Task<IEnumerable<IAspNetUserDomain>> GetAll();
        Task<int> Update(IAspNetUserDomain entity);
        Task<IAspNetUserDomain> GetByUsername(string username);
    }
}
