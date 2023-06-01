using ERP_System.Common;
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
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ERP_System.BLL.Guide
{
    public class SettingBll
    {
        private readonly IRepository<Setting> _repoSetting;
        private readonly IMapper _mapper;
        private readonly HelperBll _helperBll;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public SettingBll(IRepository<Setting> repoSetting, IWebHostEnvironment webHostEnvironment, HelperBll helperBll, IMapper mapper)
        {
            _repoSetting = repoSetting;
            _mapper = mapper;
            _helperBll = helperBll;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Get
        public Setting GetSetting()
        {
            return _repoSetting.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive).FirstOrDefault();
        }
       
        #endregion

        #region Save 
        public ResultViewModel Save(SettingDTO settingDto)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoSetting.GetAll().FirstOrDefault();
            if (data != null)
            {
                var tbl = data;
                var oldLogo = _webHostEnvironment.WebRootPath +data.Logo;
                tbl.AddedBy = data.AddedBy;
                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoSetting.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoSetting.UserId;
                }

                if (settingDto.Logo !=null && settingDto.Logo.Length > 0)
                {
                   tbl.Logo = _helperBll.UploadFile(settingDto.Logo ,"/SiteImages/");
                }

                if (_repoSetting.Update(tbl))
                {
                    if (oldLogo != null)
                    {
                        File.Delete(oldLogo);
                    }
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
               
                var tbl = _mapper.Map<Setting>(settingDto);
                tbl.IsActive = true;
                tbl.IsDeleted = false;
                if (_repoSetting.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoSetting.UserId;
                }
                if (settingDto.Logo != null && settingDto.Logo.Length>0)
                {
                    tbl.Logo = _helperBll.UploadFile(settingDto.Logo, "/SiteImages/");
                }

                if (_repoSetting.Insert(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            return resultViewModel;
        }
        #endregion

    }
}
