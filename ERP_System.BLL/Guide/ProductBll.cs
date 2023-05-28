﻿using ERP_System.Common;
using ERP_System.DAL;
using ERP_System.DTO.Guide;
using ERP_System.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ERP_System.Tables;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ERP_System.BLL.Guide
{
    public class ProductBll
    {
        private const string _spProduct = "Guide.[spProducts]";
        private readonly IRepository<Product> _repoProduct;
        private readonly IRepository<Attachment> _repoAttatchment;
        private readonly IMapper _mapper;
        private readonly HelperBll _helperBll;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductBll(IRepository<Attachment> repoAttatchment, IWebHostEnvironment webHostEnvironment, IRepository<Product> repoProduct, IMapper mapper, HelperBll helperBll)
        {
            _repoProduct = repoProduct;
            _mapper = mapper;
            _helperBll = helperBll;
            _repoAttatchment = repoAttatchment;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Get
        public ProductDTO GetById(Guid id)
        {
            return _repoProduct.GetAllAsNoTracking().Include(p => p.Attachments.Any(x => x.IsActive && !x.IsDeleted)).Include(x => x.Unit).Where(p => p.ID == id).Select(x => new ProductDTO
            {
                ID = x.ID,
                Name = x.Name,
                BarCodeText = x.BarCodeText,
                GroupId = x.GroupId,
                Price = x.Price,
                QtyInStock = x.QtyInStock,
                ProductImages = x.Attachments.ToList(),
                UnitId = x.UnitId,
                UnitName = x.Unit.Name,
                GroupName = x.Group.Name
            }).FirstOrDefault();

        }

        public object GetByBarCodeOrName(string text)
        {
            var data = _repoProduct.GetAllAsNoTracking().Include(x => x.Unit).Where(p => p.Name == text || p.BarCodeText == text && p.IsActive && !p.IsDeleted).Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                BarCodeText = x.BarCodeText,
            }).FirstOrDefault();

            return data;

        }
        public ProductDTO GetByProductBarCode(string barcode)
        {
            return _repoProduct.GetAllAsNoTracking().Include(p => p.Group).Include(p => p.Unit)
                .Where(p => p.BarCodeText.Trim().ToLower() == barcode.Trim().ToLower() && p.IsActive && !p.IsDeleted)
                .Select(p => new ProductDTO
                {
                    ID = p.ID,
                    Name = p.Name,
                    BarCodeText = p.BarCodeText,
                    GroupId = p.GroupId,
                    Price = p.Price,
                    QtyInStock = p.QtyInStock,
                    ProductImages = p.Attachments.ToList(),
                    UnitId = p.UnitId,
                    UnitName = p.Unit.Name,
                    GroupName = p.Group.Name
                }).FirstOrDefault();
        }

        public IQueryable<SelectListDTO> GetSelect()
        {
            var data = _repoProduct.GetAllAsNoTracking().Where(x => x.IsActive && !x.IsDeleted).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
            return data.Distinct();

        }
        public IQueryable<ProductDTO> GetAllByGroupId(Guid? id)
        {
            return _repoProduct.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive && x.GroupId == id)
                .Select(x => new ProductDTO
                {

                    ID = x.ID,
                    Name = x.Name,
                    BarCodeText = x.BarCodeText,
                    GroupId = x.GroupId,
                    Price = x.Price,
                    QtyInStock = x.QtyInStock,
                    ProductImages = x.Attachments.ToList(),
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name,
                    GroupName = x.Group.Name

                });
        }
        public IQueryable<ProductDTO> GetAll()
        {

            return _repoProduct.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive)
                .Select(x => new ProductDTO
                {
                    ID = x.ID,
                    Name = x.Name,
                    BarCodeText = x.BarCodeText,
                    GroupId = x.GroupId,
                    Price = x.Price,
                    QtyInStock = x.QtyInStock,
                    ProductImages = x.Attachments.ToList(),
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name,
                    GroupName = x.Group.Name
                });
        }

        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoProduct.ExecuteStoredProcedure<ProductTableDTO>
                (_spProduct, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { AaData = data, ITotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Save 
        public ResultViewModel Save(ProductDTO productDto)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };
            var BarCodeFoldeName = "\\ProductsBarCode\\";
            var ImagesFoldeName = "\\Images\\Products\\";

            var data = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == productDto.ID).FirstOrDefault();
            if (data != null)
            {

                if (_repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == productDto.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }

                var tbl = _mapper.Map<Product>(productDto);
                if (string.IsNullOrEmpty(productDto.BarCodeText))
                {
                    tbl.BarCodePath = data.BarCodePath;
                    tbl.BarCodeText = data.BarCodeText;
                }
                else
                {
                    tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
                    tbl.BarCodeText = productDto.BarCodeText;
                }
                tbl.AddedBy = data.AddedBy;

                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoProduct.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoProduct.UserId;
                }
                if (_repoProduct.Update(tbl))
                {
                    if (productDto.images != null && productDto.images.Length > 0)
                    {
                        _helperBll.UploadFile(tbl.ID, productDto.images, ImagesFoldeName);
                    }
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoProduct.GetAllAsNoTracking().Where(p => !p.IsDeleted).Where(p => p.Name.Trim().ToLower() == productDto.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;
                }

                var tbl = _mapper.Map<Product>(productDto);
                if (!string.IsNullOrEmpty(productDto.BarCodeText))
                {
                    tbl.BarCodePath = _helperBll.GenerateBarcode(productDto.BarCodeText, BarCodeFoldeName);
                    tbl.BarCodeText = productDto.BarCodeText;
                }
                if (_repoProduct.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoProduct.UserId;
                }
                if (_repoProduct.Insert(tbl))
                {
                    if (productDto.images != null && productDto.images.Length > 0)
                    {
                        _helperBll.UploadFile(tbl.ID, productDto.images, ImagesFoldeName);
                    }
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            return resultViewModel;
        }
        #endregion


        #region Delete
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoProduct.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoProduct.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoProduct.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoProduct.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }

        public ResultViewModel DeleteImage(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoAttatchment.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoProduct.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoProduct.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoAttatchment.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion


    }
}
