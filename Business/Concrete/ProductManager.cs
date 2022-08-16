using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Performance;
using Core.CrossCuttingConcerns.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //[ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        //[TransactionScopeAspect] Bu aspect core.utilites.interceptor altında otomatik tüm metotlara uygulanmıştır. Metotların üzerine yazarsak da sadece o metoda uygular.
        //[PerformanceAspect(5)] Bu aspect core.utilites.interceptor altında otomatik tüm metotlara uygulanmıştır. Metotların üzerine yazarsak da sadece o metoda uygular.
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckOfDateTime(),CheckOfCategoryCount(), CheckOfContainsName(product));
            if (result != null)
            {
                return result;
            }
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
        }

        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAll()
        {
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id),Messages.GetByCategoryIdListed);
        }

        public IDataResult<List<Product>> GetAllUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max),Messages.ProductListedByUnitPrice);
        }

        public IDataResult<List<Product>> GetByName(string name)
        {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ProductName.Contains(name)),Messages.ProductListedByName);
            
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductListedByDetails);
        }

        private IResult CheckOfDateTime()
        {
            if (DateTime.Now.Hour == 00) 
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult(Messages.ProductAdded);
        }
        private IResult CheckOfCategoryCount()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count>=100)
            {
                return new ErrorResult(Messages.CategoryLimitedExceeded);
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckOfContainsName(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Count();
            if (result > 0)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult(Messages.ProductAdded);
        }
        
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public int ProductCountOfCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId).Count();
        }
    }

}
