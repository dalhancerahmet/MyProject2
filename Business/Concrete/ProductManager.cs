using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckOfDateTime(),CheckOfCategoryCount());
            if (result != null)
            {
                return result;
            }
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id),Messages.GetByCategoryIdListed);
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
    }

}
