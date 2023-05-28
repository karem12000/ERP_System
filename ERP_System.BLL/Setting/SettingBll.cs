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

namespace ERP_System.BLL.Guide
{
    public class SettingBll
    {
        private readonly IRepository<Setting> _repoSetting;
        private readonly IMapper _mapper;

        public SettingBll(IRepository<Setting> repoSetting, IMapper mapper)
        {
            _repoSetting = repoSetting;
            _mapper = mapper;
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
                var tbl = _mapper.Map<Setting>(settingDto);
                tbl.AddedBy = data.AddedBy;

                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoSetting.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoSetting.UserId;
                }
                if (_repoSetting.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
               
                var tbl = _mapper.Map<Setting>(settingDto);
                if (_repoSetting.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoSetting.UserId;
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
