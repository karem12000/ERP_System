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
using ERP_System.Common.General;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.BLL.Guide
{
    public class ClientBll
    {
        private const string _spClient = "[People].[spClients]";
        private readonly IRepository<Client> _repoClient;
        private readonly IMapper _mapper;

        public ClientBll(IRepository<Client> repoClient,  IMapper mapper)
        {
            _repoClient = repoClient;
            _mapper = mapper;
        }

        #region Get
        public ClientDTO GetById(Guid id)
        {
            return _repoClient.GetAllAsNoTracking().Where(p => p.ID == id).Select(p=>new ClientDTO
            {
                ID = id,
                Address = p.Address,
                IsActive= p.IsActive,
                companyName = p.companyName,
                Name = p.Name,
                Phone= p.Phone,
                ProcessAmount= p.ProcessAmount,
                ProcessTypeInt = p.ProcessType==null? 0 : (int)p.ProcessType
            }).FirstOrDefault();
        }
       
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoClient.ExecuteStoredProcedure<ClientTableDTO>
                (_spClient, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Save 
        public ResultViewModel Save(ClientDTO clientDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };


            var data = _repoClient.GetAllAsNoTracking().Where(p => p.ID == clientDTO.ID).FirstOrDefault();
            if (data != null)
            {
                var tbl = _mapper.Map<Client>(clientDTO);
                if (clientDTO.ProcessType == null)
                {
                    tbl.ProcessAmount = 0;
                }
                tbl.AddedBy = data.AddedBy;
                tbl.CreatedDate = data.CreatedDate;
                tbl.ModifiedDate = AppDateTime.Now;
                if (_repoClient.UserId != Guid.Empty)
                {
                    tbl.ModifiedBy = _repoClient.UserId;
                }
                if (_repoClient.Update(tbl))
                {
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                var tbl = _mapper.Map<Client>(clientDTO);
                if (clientDTO.ProcessType == null)
                {
                    tbl.ProcessAmount = 0;
                }
                if (_repoClient.UserId != Guid.Empty)
                {
                    tbl.AddedBy = _repoClient.UserId;
                }
                if (_repoClient.Insert(tbl))
                {
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
            var tbl = _repoClient.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();

            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }

            tbl.IsDeleted = true;
            if (_repoClient.UserId != Guid.Empty)
            {
                tbl.DeletedBy = _repoClient.UserId;
            }
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoClient.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        #endregion
    }
}
