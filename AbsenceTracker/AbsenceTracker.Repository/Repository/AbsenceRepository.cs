﻿using AbsenceTracker.Repository.Common.IGenericRepository;
using AbsenceTracker.Repository.Common.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AbsenceTracker.Model.Common.IDomainModels;
using AbsenceTracker.DAL;
using AbsenceTracker.Model.DomainModels;

namespace AbsenceTracker.Repository.Repository
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly IGenericRepository GenericRepository;

        public AbsenceRepository(IGenericRepository genericRepository)
        {
            this.GenericRepository = genericRepository;
        }

        //Add Absence
        public async Task<int> Add(IAbsenceDomain entity)
        {
            try
            {
                return await GenericRepository.Add(Mapper.Map<Absence>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //Delete Absence by Id
        public async Task<int> Delete(Guid id)
        {
            try
            {
                var item = await GenericRepository.Get<Absence>(id);

                if (item == null)
                    return 0;

                return await GenericRepository.Delete(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete Absence by Object
        public async Task<int> Delete(IAbsenceDomain entity)
        {
            try
            {
                return await GenericRepository.Delete(Mapper.Map<Absence>(entity));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get Absence by Id
        public async Task<IAbsenceDomain> Get(Guid id)
        {
            try
            {
                var response = Mapper.Map<AbsenceDomain>(await GenericRepository.Get<Absence>(id));
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get all Absences
        public async Task<IEnumerable<IAbsenceDomain>> GetAll()
        {
            try
            {
                var getData = Mapper.Map<IEnumerable<IAbsenceDomain>>(await GenericRepository.GetAll<Absence>());
                return getData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Get all Absences with type of sickness
        public async Task<IEnumerable<IAbsenceDomain>> GetAllSickness()
        {
            try
            {
                var getData = Mapper.Map<IEnumerable<IAbsenceDomain>>(GenericRepository.GetQueryable<Absence>());
                return getData.Where(x => x.Type == "Sickness");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get all Absences with type of Vacation
        public async Task<IEnumerable<IAbsenceDomain>> GetAllVacation()
        {
            try
            {
                var getData = Mapper.Map<IEnumerable<IAbsenceDomain>>(GenericRepository.GetQueryable<Absence>());
                return getData.Where(x => x.Type == "Vacation");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get all Absences with type of Compensation
        public async Task<IEnumerable<IAbsenceDomain>> GetAllCompensation()
        {
            try
            {
                var getData = Mapper.Map<IEnumerable<IAbsenceDomain>>(GenericRepository.GetQueryable<Absence>());
                return getData.Where(x => x.Type == "Compensation");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Update Absence
        public async Task<int> Update(IAbsenceDomain entity)
        {
            try
            {
                return await GenericRepository.Update(Mapper.Map<Absence>(entity));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
