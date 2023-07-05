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
        private readonly IRepository<PurchaseInvoice> _repoPurchaseInvoices;
        private readonly IRepository<PurchaseThrowback> _repoPurchaseThrowback;
        private readonly IRepository<SaleInvoice> _repoSaleInvoices;
        private readonly IRepository<SaleThrowback> _repoSaleThrowback;

        public UserBll(IRepository<User> repoUser, IRepository<UserStock> repoUserStock,
            IRepository<UserPermission> repoUserPermission, IRepository<Page> repoPage,
            IRepository<ActionsPage> repoActionsPage, IRepository<PurchaseInvoice> repoPurchaseInvoices , IRepository<PurchaseThrowback> repoPurchaseThrowback
            , IRepository<SaleInvoice> repoSaleInvoices , IRepository<SaleThrowback> repoSaleThrowback)
        {
            _repoUser = repoUser;
            _repoUserPermission = repoUserPermission;
            _repoPage = repoPage;
            _repoActionsPage = repoActionsPage;
            _repoUserStock = repoUserStock;
            _repoPurchaseInvoices = repoPurchaseInvoices;
            _repoPurchaseThrowback = repoPurchaseThrowback;
            _repoSaleInvoices = repoSaleInvoices;
            _repoSaleThrowback = repoSaleThrowback;
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

        public UserDTO GetById(Guid id)
        {

            return _repoUser.GetAllAsNoTracking().Where(p => p.ID == id).Select(x=> new UserDTO
            {
                AddedDate = x.CreatedDate.ToString(),
                Address= x.Address,
                Email= x.Email,
                ID= id,
                IsActive= x.IsActive,
                IsAdmin= x.IsAdmin,
                Name= x.Name,
                PasswordHash= x.PasswordHash,
                Phone= x.Phone,
                StockIds = x.UserStocks.Select(c=>c.StockId).ToArray(),
                UserClassification= x.UserClassification,
                UserName= x.UserName,
                UserTypeId= x.UserTypeId,
                StockIdsStr = string.Join(',',x.UserStocks.Select(c=>c.StockId).ToArray()),
                ScreenId = x.ScreenId,
                DiscountPermission = x.DiscountPermission
            }).FirstOrDefault();
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
        public ResultDTO OldSendCode(UserSendCodeParameters para)
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

        public ResultViewModel SendCode(UserSendCodeParameters para)
        {
            ResultViewModel result = new ResultViewModel();
            result.Status = false;
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
                        result.Status = true;
                        result.Message = AppConstants.Messages.SendCodeSuccessfully;
                    }
                    else
                    {
                        result.Message = AppConstants.Messages.SendCodeFailed;
                    }
                }
                else
                {
                    result.Message = AppConstants.Messages.UserNotFound;
                }
            }
            else
            {
                result.Message = AppConstants.Messages.UserNotFound;
            }
            return result;

        }
        public ResultDTO OldForgetPassword(UserForgetPasswordParameters para)
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

        public ResultViewModel ForgetPassword(UserForgetPasswordParameters para)
        {
            ResultViewModel result = new ResultViewModel();
            result.Status = false;
            var data = _repoUser.GetAll().Where(p => (p.UserName.ToLower() == para.Username.ToLower() || p.Email.ToLower() == para.Username.ToLower())).FirstOrDefault();
            if (data != null)
            {
                if (data.CodeOfReset != para.Code)
                {
                    result.Message =AppConstants.Messages.CCodeNotMatched;

                }
                else
                {
                    data.PasswordHash = para.NewPassword.EncryptString();
                    data.CodeOfReset = null;
                    data.ResetPasswordDate = null;
                    if (_repoUser.Update(data))
                    {

                        result.Status = true;
                        result.Message = AppConstants.Messages.PasswordSavedSuccess;
                    }
                    else
                    {
                        result.Message = AppConstants.Messages.PasswordSavedFailed;
                    }
                }
            }
            else
            {

                result.Message = AppConstants.Messages.UserNotFound;

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
                tbl = user;
                if (_repoUser.GetAll().Where(p => p.UserName.Trim().ToLower() == userDTO.UserName.Trim().ToLower() && !p.IsDeleted ).FirstOrDefault() != null)
                {
                    resultViewModel.Message = AppConstants.UserMessages.UsernameAlreadyExists;
                    return resultViewModel;

                }

                if (_repoUser.GetAll().Where(p => p.Email.Trim().ToLower() == userDTO.Email.Trim().ToLower() && !p.IsDeleted ).FirstOrDefault() != null)
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
                
                if (userDTO.UserTypeId.ToString() == AppConstants.SubAdminTypeId.ToLower())
                    user.UserClassification = UserClassification.Admin;
                else if (userDTO.UserTypeId.ToString() == AppConstants.CashierTypeId.ToLower())
                    user.UserClassification = UserClassification.Cashier;
                else if (userDTO.UserTypeId.ToString() == AppConstants.UserTypeId.ToLower())
                    user.UserClassification = UserClassification.User;
                else { }

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
                tbl.Name = user.Name.Trim();
                tbl.UserName = user.UserName.Trim();
                tbl.Email = user.Email.Trim();
                tbl.UserTypeId = user.UserTypeId;
                tbl.ScreenId = user.ScreenId;
                tbl.Phone = user.Phone;
                tbl.Address = user.Address;
                tbl.CreatedDate = tbl.CreatedDate;
                tbl.AddedBy = tbl.AddedBy;
                tbl.ModifiedDate = AppDateTime.Now;
                tbl.ModifiedBy = _repoUser.UserId;
                tbl.DiscountPermission = user.DiscountPermission;

                if (userDTO.UserTypeId.ToString() == AppConstants.SubAdminTypeId.ToLower())
                    tbl.UserClassification = UserClassification.Admin;
                else if (userDTO.UserTypeId.ToString() == AppConstants.CashierTypeId.ToLower())
                    tbl.UserClassification = UserClassification.Cashier;
                else if (userDTO.UserTypeId.ToString() == AppConstants.UserTypeId.ToLower())
                    tbl.UserClassification = UserClassification.User;
                else { }


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

                    _repoUserStock.ExecuteSQLQuery<int>("DELETE FROM [People].[UserStocks] WHERE UserId='"+tbl.ID+"'",CommandType.Text);
                    _repoUserStock.InsertRange(AllStock);
                    

                    resultViewModel.Status = true;
                    resultViewModel.Message = AppConstants.Messages.SavedSuccess;

                }
            }





            return resultViewModel;
        }
        public ResultViewModel Delete(Guid id)
        {
            ResultViewModel resultViewModel = new ResultViewModel();
            var tbl = _repoUser.GetAllAsNoTracking().Where(p=>p.ID==id&&!p.IsDeleted).FirstOrDefault();
            if (tbl == null)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = AppConstants.Messages.DeletedFailed;
                return resultViewModel;
            }
            var havePurchaseInvoices = _repoPurchaseInvoices.GetAllAsNoTracking().Any(p => p.SupplierId == id);
            var haveThrowbackPurchaseInvoices = _repoPurchaseThrowback.GetAllAsNoTracking().Any(p => p.SupplierId == id);
            if (havePurchaseInvoices || haveThrowbackPurchaseInvoices)
            {
                resultViewModel.Status = false;
                resultViewModel.Message = "لايمكن حذف المورد لوجود معاملات خاصه به";
                return resultViewModel;
            }
            //tbl.IsDeleted = true;
            //tbl.DeletedBy = null;
            //tbl.DeletedDate = AppDateTime.Now;
            var IsSuceess = _repoUser.Delete(tbl);

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
        public DataTableResponse LoadData(DataTableRequest mdl)
        {
            var data = _repoUser.ExecuteStoredProcedure<UserTableDTO>
                (_spUsers, mdl?.ToSqlParameter(), CommandType.StoredProcedure);

            return new DataTableResponse() { aaData = data, iTotalRecords = data?.FirstOrDefault()?.TotalCount ?? 0 };
        }
        #endregion
        #region Login For Web
        #region  تسجيل الدخول
        public User LogInWeb2(LogInDTO mdl)
        {
            if (mdl != null && !mdl.UserName.IsEmpty() && !mdl.Password.IsEmpty())
            {
                var pass = mdl.Password.EncryptString();
                var user = _repoUser.GetAll().Where(c => c.IsActive == true && !c.IsDeleted && (c.UserName == mdl.UserName || c.Email == mdl.UserName) && c.PasswordHash == pass).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
            }

            return null;
        }
        public UserDTO LogInWeb(LogInDTO mdl)
        {
            if (mdl != null && !mdl.UserName.IsEmpty() && !mdl.Password.IsEmpty())
            {
                var pass = mdl.Password.EncryptString();
                var user = _repoUser.GetAll().Where(c => c.IsActive == true && !c.IsDeleted && (c.UserName == mdl.UserName || c.Email == mdl.UserName) && c.PasswordHash == pass)
                    .Select(x=> new UserDTO
                    {
                        UserName = x.UserName,
                        ID = x.ID,
                        Email = x.Email,
                        ScreenId = x.ScreenId,
                    }).FirstOrDefault();
                if (user != null)
                {
                    if(user.ScreenId != null && user.ScreenId != Guid.Empty)
                    {
                        var page = _repoPage.GetById(user.ScreenId);
                        user.AreaName = page.AreaName;
                        user.ControllerName = page.ControllerName;
                    }
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
                //PurchaseThrowbackPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.PurchaseThrowback && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),
                //SaleThrowbackPermission = _repoUserPermission.GetAll().Include(p => p.ActionsPage).Where(u => u.ActionsPage.ActionName == ActionEnum.SaleThrowback && u.UserTypeId == id && u.ActionsPage.PageId == p.ID).Any(),

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
