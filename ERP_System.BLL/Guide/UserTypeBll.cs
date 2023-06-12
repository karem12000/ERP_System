
using AutoMapper;
using ERP_System;
using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.DAL;
using ERP_System.DTO;
using ERP_System.DTO.Guide;
using ERP_System.Tables;

using System;
using System.Data;
using System.Linq;

namespace ERP_System.BLL
{
    public class UserTypeBll
    {
        #region Fields
        private const string _spUserTypes = "Guide.[spUserTypes]";

        private readonly IRepository<UserType> _repoUserType;
        private readonly IMapper _mapper;
        public UserTypeBll(IRepository<UserType> repoUserType, IMapper mapper)
        {
            _repoUserType = repoUserType;
            _mapper = mapper;
        }

        #endregion
        #region Get


        public UserType GetById(Guid id)
        {

            return _repoUserType.GetAllAsNoTracking().Where(p => p.ID == id).Select(p=>new UserType() { ID=p.ID, Name=p.Name } ).FirstOrDefault();
        }
        public IQueryable<SelectListDTO> GetSelect()
        {
            return _repoUserType.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive)
                //.Where(p=>p.Type != UserClassification.SuperAdmin)
                .Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.Name
            });
        }
      

        public IQueryable<UserType> GetAll()
        {

            return _repoUserType.GetAllAsNoTracking().Where(x => !x.IsDeleted && x.IsActive && x.Type != UserClassification.SuperAdmin);
        }
        #endregion
        public ResultViewModel Save(UserTypeDTO UserTypeDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoUserType.GetAllAsNoTracking().Where(p => p.ID == UserTypeDTO.ID).FirstOrDefault();
            if (data != null)
            {

                if (_repoUserType.GetAllAsNoTracking().Where(p => p.ID != data.ID && p.Name.Trim().ToLower() == UserTypeDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }

                var tbl = _mapper.Map<UserType>(UserTypeDTO);
                tbl.AddedBy = data.AddedBy;

                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoUserType.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoUserType.GetAllAsNoTracking().Where(p => p.Name.Trim().ToLower() == UserTypeDTO.Name.Trim().ToLower()).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.Messages.NameAlreadyExists;
                    return resultViewModel;

                }
                var tbl = _mapper.Map<UserType>(UserTypeDTO);

                if (_repoUserType.Insert(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }





            return resultViewModel;
        }

        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoUserType.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }
            tbl.IsDeleted = true;
            tbl.DeletedBy = null;
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoUserType.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }

    }
}
