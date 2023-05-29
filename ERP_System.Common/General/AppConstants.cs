using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_System.Common
{
    public static class AppConstants
    {


        public struct StatusCodes
        {
            public const int Success = 200;
            public const int Error = 422;

        }
        public static readonly object[] EmptyValues = { Guid.Empty, string.Empty, null };

        public const string _SuperUserIdCookie = "App.Super.ERP_System.UserId";
        public const string _UserIdCookie = "App.ERP_System.UserId";
        public const string LanguageCodeCookie = "App.ERP_System.LanguageCode";
        public const string LanguageIdCookie = "App.ERP_System.LanguageId";
        public const string LanguageRtlCookie = "App.ERP_System.Language.IsRtl";
        public const string DefaultPassword = "admin@123";
        public static readonly string EncryptKey = "n1xdl54xsefeghk9z3xodibpmctoneyj";
        public const string SuccessUrl = "~/Setting/Xero/Success";
        public const string TrackingBranches = "Branches";
        public const string XeroWarehouse = "INVENTORY";
        public static Guid InvoicePageId = Guid.Parse("c43e42f4-b60e-422a-b25f-e2c66ff5d0f8");
        public const string TempProductsExcelName = "TempProducts.xlsx";
        public static string UploadsPath = "Uploads";

        public static string VisitNotesImagesPath = $"{UploadsPath}/VisitNotesImages/";
        public static string VisitQuestionsPath = $"{UploadsPath}/VisitQuestions/";
        public static string VisitSignturesPath = $"{UploadsPath}/VisitSigntures/";

        public struct Areas
        {
            public const string api = nameof(api);
            public const string Guide = nameof(Guide);
            public const string Setting = nameof(Setting);
            public const string People = nameof(People);
            public const string Page = nameof(Page);
        


        }
       
        public struct Messages
        {
           
            public const string SavedSuccess = "تمت عملية الحفظ بنجاح";
            public const string SavedFailed = "حدث خطا";
            public const string RequiredMessage = "هذا الحقل مطلوب";
            public const string EnterRequiredFields = "من فضلك أدخل الحقول المطلوبة";
            public const string UserTypeRequiredMessage = "نوع المستخدم مطلوب";
            public const string StopTitle = "توقف";
            public const string ProductByBarCodeNotFound = "لايوجد منتج بهذا الباركود";
            public const string ProductByNameNotFound = "لايوجد منتج بهذا الاسم";




            public const string DeletedSuccess = "تم الحذف بنجاح";
            public const string DeletedFailed = "حدث خطا اثناء الحذف";
            public const string ChangedStatusSuccess = "تم تغيير الحالة بنجاح";
            public const string ChangedStatusFailed = "حدث خطا اثناء تغيير الحالة";
            public const string NameAlreadyExists = "الاسم موجود من قبل";
            
            public const string NameRequired = "الاسم مطلوب";
            public const string PreparationSuccess = "تمت عملية تجهيز النظام بنجاح";
            public const string InvoiceCodeAlreadyExists = "كود الفاتورة موجود من قبل";
            public const string ConfigXero = "من فضلك قم بالدخول على صفحة تجهيز النظام لتحديث كود الصلاحية";
            public const string ErrorInXeroWhenAddInvoice = "حدث خطا اثناء اضافة الفاتورة في نظام Xero";
            public const string DataRequired = "من فضلك قم بادخال البيانات الناقصة";
            public const string ProductNotScheduledOnToday = "اليوم غير مجدول لهذا المنتج";

            
        }
        public struct UserMessages
        {

            public const string UsernameAlreadyExists = "اسم المستخدم موجود من قبل";
            public const string EmailAlreadyExists = "البريد الالكتروني موجود من قبل";


        }

        public struct ClientMessages
        {

            public const string ClientUniqueNameAlreadyExists = "اسم المستخدم موجود من قبل";
            public const string FullNameAlreadyExists = "الاسم موجود من قبل";


        }


    }
}
