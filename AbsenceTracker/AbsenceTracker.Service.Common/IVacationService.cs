﻿using AbsenceTracker.Model.Common.IDomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsenceTracker.Service.Common
{
    public interface IVacationService
    {
        Task<int> Add(IVacationDomain entry);
        Task<int> Delete(string id);
        Task<int> Delete(IVacationDomain entry);
        Task<IVacationDomain> Read(string id);
        Task<IEnumerable<IVacationDomain>> ReadAll();
        Task<int> Update(IVacationDomain entry);
    }
}
