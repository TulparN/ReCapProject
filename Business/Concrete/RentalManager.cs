﻿using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("car.list, admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity) 
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("car.list,admin")]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail(), Messages.Listed);
        }
        public IDataResult<List<Rental>> GetRentalById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
        }

        [SecuredOperation("car.list,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.Updated);

        }
    }
}
