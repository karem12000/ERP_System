using AutoMapper;
using ERP_System.Common;
using ERP_System.Common.General;
using ERP_System.DAL;
using ERP_System.DTO;
using ERP_System.DTO.Guide;
using ERP_System.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ERP_System.BLL
{
    public class UserBll
    {
        #region Fields
        private const string _spUsers = "[people].[spUsers]";

        private readonly IRepository<User> _repoUser;
        private readonly IRepository<UserStock> _repoUserStock;
        private readonly IRepository<UserPermission> _repoUserPermission;
        private readonly IRepository<Page> _repoPage;
        private readonly IRepository<ActionsPage> _repoActionsPage;

        public UserBll(IRepository<User> repoUser, IRepository<UserStock> repoUserStock,
            IRepository<UserPermission> repoUserPermission, IRepository<Page> repoPage,
            IRepository<ActionsPage> repoActionsPage)
        {
            _repoUser = repoUser;
            _repoUserPermission = repoUserPermission;
            _repoPage = repoPage;
            _repoActionsPage = repoActionsPage;
            _repoUserStock = repoUserStock;
        }

        #endregion
        #region Get
        public ResultDTO Get()
        {
            ResultDTO result = new ResultDTO();
            result.data = new
            {
                Users = _repoUser.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted && p.ID != _repoUser.UserId).Select(p => new
                {
                    Id = p.ID,
                    Name = p.UserName
                })
            };
            return result;
        }
        public IQueryable<SelectListDTO> GetSelect()
        {
            return _repoUser.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive).Select(p => new SelectListDTO()
            {
                Value = p.ID,
                Text = p.UserName,

            });
        }
        public IQueryable<UserSelectDTO> GetSelect(Guid? userId)
        {
            return _repoUser.GetAllAsNoTracking().Where(p => !p.IsDeleted && p.IsActive).Select(p => new UserSelectDTO()
            {
                Id = p.ID,
                Username = p.UserName,
                Selected = p.ID == userId

            });
        }

        public User GetById(Guid id)
        {

            return _repoUser.GetAllAsNoTracking().Where(p => p.ID == id).FirstOrDefault();
        }
        #endregion

        #region Login
        public ResultDTO Login(UserParameters para)
        {
            ResultDTO result = new ResultDTO();
            var data = _repoUser.GetAll().Where(p => (p.UserName.ToLower() == para.Username.ToLower() || p.Email.ToLower() == para.Username.ToLower()) && p.PasswordHash == para.Password.EncryptString()).FirstOrDefault();
            if (data != null)
            {

                result.data = new { User = new UserResultDTO { Id = data.ID, Username = data.UserName, UseDefaultPassword = data.UseDefaultPassword } };
            }
            else
            {
                result.Message = "خطأ في اسم المستخدم أو كلمة المرور";
            }
            return result;

        }
        #endregion
        #region Change Password
        public ResultDTO ChangePassword(UserChangePasswordParameters para)
        {
            ResultDTO result = new ResultDTO();
            var data = _repoUser.GetAllAsNoTracking().Where(p => p.ID == _repoUser.UserId).FirstOrDefault();
            if (data != null)
            {
                data.PasswordHash = para.NewPassword.EncryptString();
                data.UseDefaultPassword = false;
                if (_repoUser.Update(data))
                {
                    result.data = new { Successed = true };

                    result.Message = AppConstants.Messages.SavedSuccess;
                }
                else
                {
                    result.Message = AppConstants.Messages.SavedFailed;
                }
            }
            else
            {
                result.Message = "لايوجد مستخدم بهذا الاسم";
            }
            return result;

        }
        #endregion
        #region Forget Password
        public ResultDTO SendCode(UserSendCodeParameters para)
        {
            ResultDTO result = new ResultDTO();
            var data = _repoUser.GetAll().Where(p => (p.UserName.ToLower() == para.Username.ToLower() || p.Email.ToLower() == para.Username.ToLower())).FirstOrDefault();
            if (data != null)
            {
                var _SendBll = _repoUser.HttpContextAccessor.HttpContext.RequestServices.GetService(typeof(SendBll)) as SendBll;
                string Code = new Random((int)DateTime.Now.Ticks).Next(11111, 99999) + "";
                if (_SendBll.SendMail("كود تعيين كلمة المرور", data.UserName, $"كود التحقق  {Code}", data.Email))
                {
                    data.ResetPasswordDate = AppDateTime.Now;
                    data.CodeOfReset = Code;
                    if (_repoUser.Update(data))
                    {
                        result.data = new { Successed = true };

                        result.Message = AppConstants.Messages.SavedSuccess;
                    }
                    else
                    {
                        result.Message = AppConstants.Messages.SavedFailed;
                    }
                }
                else
                {
                    result.Message = "لايوجد مستخدم بهذا الاسم";
                }
            }
            else
            {
                result.Message = "لايوجد مستخدم بهذا الاسم";
            }
            return result;

        }
        public ResultDTO ForgetPassword(UserForgetPasswordParameters para)
        {
            ResultDTO result = new ResultDTO();
            var data = _repoUser.GetAll().Where(p => (p.UserName.ToLower() == para.Username.ToLower() || p.Email.ToLower() == para.Username.ToLower())).FirstOrDefault();
            if (data != null)
            {
                if (data.CodeOfReset != para.Code)
                {
                    result.Message = "الكود غير مطابق ";

                }
                else
                {
                    data.PasswordHash = para.NewPassword.EncryptString();
                    data.CodeOfReset = null;
                    data.ResetPasswordDate = null;
                    if (_repoUser.Update(data))
                    {
                        result.data = new { Successed = true };

                        result.Message = AppConstants.Messages.SavedSuccess;
                    }
                    else
                    {
                        result.Message = AppConstants.Messages.SavedFailed;
                    }
                }
            }
            else
            {
                result.Message = "لايوجد مستخدم بهذا الاسم";

            }
            return result;

        }

        #endregion

        #region Save
        public ResultViewModel Save(UserDTO userDTO)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };
            var config = new MapperConfiguration(p => p.CreateMap<UserDTO, User>());
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(userDTO);
            var tbl = _repoUser.GetAllAsNoTracking().Where(p => p.ID == userDTO.ID).FirstOrDefault();
            if (tbl == null)
            {
                if (_repoUser.GetAll().Where(p => p.UserName.Trim().ToLower() == userDTO.UserName.Trim().ToLower() && !p.IsDeleted).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.UserMessages.UsernameAlreadyExists;
                    return resultViewModel;

                }

                if (_repoUser.GetAll().Where(p => p.Email.Trim().ToLower() == userDTO.Email.Trim().ToLower() && !p.IsDeleted).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.UserMessages.EmailAlreadyExists;
                    return resultViewModel;
                }

                if (string.IsNullOrEmpty(userDTO.Password))
                {
                    user.PasswordHash = AppConstants.DefaultPassword.EncryptString();
                }
                else
                {
                    user.PasswordHash = userDTO.Password.EncryptString();
                }

                
                user.Salt = AppConstants.EncryptKey;

                var AllStock = new List<UserStock>();
                if (userDTO.StockIds != null && userDTO.StockIds.Count() > 0)
                {
                    foreach (var item in userDTO.StockIds)
                    {
                        var oneStock = new UserStock
                        {
                            UserId = user.ID,
                            StockId = item
                        };
                        AllStock.Add(oneStock);
                    };

                }

                if (_repoUser.Insert(user))
                {
                    _repoUserStock.InsertRange(AllStock);
                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }
            else
            {
                if (_repoUser.GetAll().Where(p => p.ID != tbl.ID && p.UserName.Trim().ToLower() == userDTO.UserName.Trim().ToLower() && !p.IsDeleted).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.UserMessages.UsernameAlreadyExists;
                    return resultViewModel;

                }

                if (_repoUser.GetAll().Where(p => p.ID != tbl.ID && p.Email.Trim().ToLower() == userDTO.Email.Trim().ToLower() && !p.IsDeleted).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.UserMessages.EmailAlreadyExists;
                    return resultViewModel;
                }

                tbl.UserName = user.UserName;
                tbl.Name = user.Name;
                tbl.Email = user.Email;
                tbl.IsActive = user.IsActive;
                tbl.UserTypeId = user.UserTypeId;
                tbl.AddedBy = tbl.AddedBy;

                
                var AllStock = new List<UserStock>();

                if (userDTO.StockIds != null && userDTO.StockIds.Count() > 0)
                {
                    foreach (var item in userDTO.StockIds)
                    {
                        var oneStock = new UserStock
                        {
                            UserId = tbl.ID,
                            StockId = item,
                            AddedBy = _repoUser.UserId
                        };
                        AllStock.Add(oneStock);
                    };

                }

                if (_repoUser.Update(tbl))
                {
                    if (user.UserClassification != UserClassification.Suppliers  && user.UserClassification != UserClassification.Client)
                    {
                        _repoUserStock.ExecuteStoredProcedure<int>($"DELETE FROM [People].[UserStocks] us WHERE us.UserId='${tbl.ID}'", null, CommandType.StoredProcedure);
                        _repoUserStock.InsertRange(AllStock);
                    }

                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }





            return resultViewModel;
        }
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoUser.GetById(id);
            tbl.IsDeleted = true;
            tbl.DeletedBy = null;
            tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoUser.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.DeletedSuccess : AppConstants.Messages.DeletedFailed;


            return resultViewModel;
        }
        public ResultViewModel ChangeStatus(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoUser.GetById(id);
            tbl.IsActive = !tbl.IsActive;
            var IsSuceess = _repoUser.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? AppConstants.Messages.ChangedStatusSuccess : AppConstants.Messages.ChangedStatusFailed;


            return resultViewModel;
        }
        public ResultViewModel ResetPassword(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoUser.GetById(id);
            tbl.PasswordHash = "hRbpM+HWb0R3yEmWMCATPw==";
            var IsSuceess = _repoUser.Update(tbl);

            resultViewModel.Status = IsSuceess;
            resultViewModel.Message = IsSuceess ? "تم استعادة كلمة المرور الافتراضية" : "حدث خطا اثناء اجراء العملية";


            return resultViewModel;
        }

        #region LoadData
        public DataTableResponse LoadData(DataTableRequest mdl, UserClassification? classification )
        {
            mdl.UserClassification = classification;
            var data = _repoUser.ExecuteStoredProcedure<UserTableDTO>
                (_spUsers, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Login For Web
        #region  تسجيل الدخول
        public User LogInWeb(LogInDTO mdl)
        {
            if (mdl != null && !mdl.UserCode.IsEmpty() && !mdl.Password.IsEmpty())
            {
                var pass = mdl.Password.EncryptString();
                var user = _repoUser.GetAll().Where(c => c.IsActive == true && !c.IsDeleted && (c.UserName == mdl.UserCode || c.Email == mdl.UserCode) && c.PasswordHash == pass).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }

            return null;
        }
        #endregion
        #region تغيير كلمة المرور
        public ResultViewModel ChangeOldPasswordWeb(ChangePasswordDTO mdl)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Status = false, Message = AppConstants.Messages.SavedFailed };
            if (mdl != null)
            {
                var currentUser = _repoUser.GetById(_repoUser.UserId);
                if (currentUser != null)
                {
                    var hashPass = mdl.OldPassword.EncryptString();
                    if (hashPass == currentUser.PasswordHash)
                    {
                        var hashNewPass = (mdl.NewPassword).EncryptString();
                        if (hashNewPass != null)
                        {
                            currentUser.PasswordHash = hashNewPass;
                            if (_repoUser.Update(currentUser))
                            {
                                resultViewModel.Status = true;
                                resultViewModel.Message = AppConstants.Messages.SavedSuccess;
                            }
                        }
                    }
                }
            }
            return resultViewModel;
        }

        #endregion

        #endregion
        #endregion
        #region GetUsers
        public IEnumerable<User> GetUsers(Guid[] branchIds) => _repoUser.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);


        public IEnumerable<User> GetUsers(Guid? branchId)
        {
            if (branchId.HasValue)
            {
                return _repoUser.GetAllAsNoTracking().Where(p => p.IsActive && !p.IsDeleted);

            }
            return Enumerable.Empty<User>();
        }

        #endregion

        #region UserPermissions
        public IEnumerable<UserPermissionsDTO> GetUserPermissions(Guid id)
        {
            IEnumerable<UserPermissionsDTO> data = _repoPage.GetAll().Include(p => p.ActionsPages).Where(p => p.IsActive && !p.IsDeleted).OrderBy(p => p.OrderNo).Select(p => new UserPermissionsDTO()
            {
                PageId = p.ID,
                PageName = p.Text,
                AddPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Add && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
                ShowPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Show && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
                DeletePermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Delete && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
                EditPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Edit && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),

            });


            return data;
        }
        //public IEnumerable<UserPermissionsDTO> GetUserPermissions(Guid id)
        //{
        //    IEnumerable<UserPermissionsDTO> data = _repoPage.GetAll().Include(p => p.Area).Include(p => p.ActionsPages).Where(p => p.IsActive && !p.IsDeleted).OrderBy(p=>p.Area.OrderNo).OrderBy(p=>p.OrderNo).Select(p => new UserPermissionsDTO()
        //    {
        //        PageId = p.ID,
        //        PageName = p.Text,
        //        AddPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Add && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
        //        ShowPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Show && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
        //        DeletePermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Delete && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
        //        EditPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.Edit && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),

        //    });


        //    return data;
        //}
        public ResultViewModel SaveUserPermission(Guid userTypeId, IEnumerable<UserPermissionsSaveDTO> userPermissionsDTOs)
        {
            ResultViewModel resultViewModel = new ResultViewModel() { Message = AppConstants.Messages.SavedFailed };
            foreach (var item in userPermissionsDTOs)
            {
                if (item.PageId == Guid.Parse("16ead915-1e11-4b9a-ac79-e23625440bd2"))
                {

                }
                var ActionData = _repoActionsPage.GetAll().Where(p => p.PageId == item.PageId && p.ActionName == Enum.Parse<ActionEnum>(item.ActionName)).FirstOrDefault();
                if (ActionData == null)
                {
                    continue;
                }
                var ActionId = ActionData.ID;
                var data = _repoUserPermission.GetAll().Where(p => p.PageActionId == ActionId && p.UserTypeId == userTypeId).FirstOrDefault();
                if (data == null)
                {
                    if (item.HasPermission)
                    {
                        var tbl = new UserPermission();
                        tbl.PageActionId = ActionId;
                        tbl.UserTypeId = userTypeId;
                        _repoUserPermission.InsertWithoutSaveChange(tbl);
                    }
                }
                else
                {
                    if (item.HasPermission)
                    {

                        _repoUserPermission.UpdateWithoutSaveChange(data);
                    }
                    else
                    {
                        _repoUserPermission.DeleteWithoutSaveChange(data);
                    }
                }
            }
            if (_repoUserPermission.SaveChange())
            {
                resultViewModel.Status = true;
                resultViewModel.Message = AppConstants.Messages.SavedSuccess;
            }
            return resultViewModel;
        }

        #endregion
    }
}
