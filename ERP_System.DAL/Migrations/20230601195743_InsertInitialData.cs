using ERP_System.Tables;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace ERP_System.DAL.Migrations
{
    public partial class InsertInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.Sql("INSERT [Guide].[UserTypes]([ID], [Name], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', N'مدير النظام', CAST(N'2023-05-29T13:32:04.3970000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT [Guide].[UserTypes]([ID], [Name], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'8484e624-c5a0-463e-986a-66a118d1f2eb', N'العملاء', CAST(N'2023-05-29T13:33:05.2100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT [Guide].[UserTypes]([ID], [Name], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'df5d2d3c-655a-431e-93a3-ac4af07c8805', N'الموردين', CAST(N'2023-05-29T13:33:26.6000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");

            migrationBuilder.Sql("INSERT [People].[Users]([ID], [UserName], [Email], [Phone], [Address], [PasswordHash], [UserImage], [IsAdmin], [UseDefaultPassword], [ResetPasswordDate], [CodeOfReset], [UserClassification], [Salt], [UserTypeId], [Name], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'80968c16-15d8-4533-b771-5285299edcb6', N'admin', N'admin@admin.com', NULL, NULL, N'BEdsAtAvCWXvEwBKx1Pdng==', NULL, 1, 0, NULL, N'', NULL, N'n1xdl54xsefeghk9z3xodibpmctoneyj', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', NULL, CAST(N'2023-05-29T13:33:41.3770000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");

            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', N'المخازن', N'Guide', 1, N'fas fa-store', N'Stock', CAST(N'2023-05-31T01:30:53.5800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'75cd0ab2-7004-4dea-842b-15228d704f68', N'الأصناف', N'Guide', 2, NULL, N'Product', CAST(N'2023-05-29T13:36:50.7930000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'680e0745-ba76-4180-bc58-21247c7d10b5', N'المشتريات', N'Guide', 4, NULL, N'ReceiptInvpice', CAST(N'2023-05-29T13:37:37.3600000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd0bdef6a-d651-48f3-83d1-6c3305402ef0', N'التقارير', N'Guide', 8, NULL, N'Report', CAST(N'2023-05-29T13:38:15.2570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', N'الموردين', N'People', 3, N'fas fa-sitemap', N'Supplier', CAST(N'2023-05-29T13:39:10.6500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', N'العملاء', N'People', 5, N'fas fa-id-card-alt', N'Client', CAST(N'2023-05-29T14:20:29.2900000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'54eb4de9-3354-4ab1-ab1a-84b093d30214', N'الوحدات', N'Guide', 6, N'fas fa-balance-scale', N'Unit', CAST(N'2023-05-31T12:18:47.8430000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', N'الإعدادات', N'Setting', 8, N'fas fa-cogs', N'SiteSetting', CAST(N'2023-05-29T14:22:28.1000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'428474bc-78dd-4d51-b514-ac33b3bd4119', N'المبيعات', N'Guide', 6, NULL, N'SaleInvoice', CAST(N'2023-05-29T14:23:02.9000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'2d7535b1-9e0a-4f8c-892b-d028ed989613', N'المجموعات', N'Guide', 1, N'fas fa-layer-group', N'ItemGrpoup', CAST(N'2023-05-29T14:21:10.9100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', N'المستخدمين', N'People', 7, N'fas fa-sharp fa-solid fa-users', N'User', CAST(N'2023-05-29T14:21:53.6100000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[Pages]([ID], [Text], [AreaName], [OrderNo], [IconName], [ControllerName], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'b1ae3420-c251-4768-8d67-3c7b080826d8', N'صلاحيات المستخدمين', N'People', 15, N'fas fa-user-shield', N'Permissions', CAST(N'2023-06-02T13:38:37.7766667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");

            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12', N'اضافة', 1, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:25:35.4500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'e5525d49-0ffc-430a-a384-10f69dff488c', N'العرض', 4, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9030000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'54ee0ca0-90b1-4fc8-9b96-1250bf732248', N'حذف', 3, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'تعديل', 2, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'377674bd-a7fe-4fa4-b6fe-301fd199115a', N'تعديل', 2, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9170000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'552fd52b-f1b1-47b7-847a-37e57a86bd58', N'العرض', 4, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1530000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'ab5a5c01-426e-4a80-87a8-43274db628d2', N'اضافة', 1, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1630000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'43ae699a-55f6-43ca-aaa1-53c3e4956792', N'اضافة', 1, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0800000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0038da23-2868-46f8-928b-644af455dd1c', N'تعديل', 2, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7530000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'اضافة', 1, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'496a3e67-9a96-4e8b-9965-76ed20b62968', N'تعديل', 2, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'feec286c-0026-4cf1-911f-7e86eb0b4384', N'حذف', 3, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'b541519d-5391-4ece-bc2a-80320424ec0e', N'العرض', 4, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9300000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'8a6861e7-52a3-4473-be9d-80831f456db0', N'حذف', 3, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6330000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'182e5b2e-773e-41e8-b8fe-88fcffaadcff', N'العرض', 4, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:26:19.7930000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a', N'اضافة', 1, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9170000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'081c16ba-c791-4152-b688-9c5f4a08864f', N'تعديل', 2, N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a', CAST(N'2023-06-01T13:12:40.1670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'fa6e9967-cb80-4239-acd5-9d2d47a26b97', N'اضافة', 1, N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5', CAST(N'2023-05-31T23:58:11.9500000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'54120a72-aa08-4860-b385-9edb22911825', N'اضافة', 1, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'1a665a41-ed24-407c-99db-a1ee56333115', N'حذف', 3, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:26:54.6370000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'f635961a-1a75-4878-a1dd-a4c1130845cf', N'تعديل', 2, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0970000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd8689322-b954-4522-a49c-a6593b15494e', N'تعديل', 2, N'2d7535b1-9e0a-4f8c-892b-d028ed989613', CAST(N'2023-05-29T14:27:38.5400000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0a4d6779-fb6d-4221-b20c-db7425390b78', N'حذف', 3, N'54eb4de9-3354-4ab1-ab1a-84b093d30214', CAST(N'2023-05-31T12:19:37.9200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'5bd9a512-2c0c-43a2-83d0-df627f797c7d', N'العرض', 4, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.0770000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'1be47aca-5471-4af9-aa4d-e8202375af43', N'العرض', 4, N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e', CAST(N'2023-06-01T16:23:48.6200000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'حذف', 3, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:04.7570000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd2011900-b929-4243-b4ca-f36575c54d8f', N'حذف', 3, N'2a38ccb7-3d8d-42b1-b405-82b95529cf92', CAST(N'2023-06-01T14:19:37.1000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'العرض', 4, N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b', CAST(N'2023-05-31T01:32:14.8670000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'العرض', 4, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6833333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'اضافة', 1, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6933333' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages] ([ID],[Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'تعديل', 2, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.6966667' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [Page].[ActionsPages]([ID], [Text], [ActionName], [PageId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'f25bc116-cf01-41e7-879f-8a775abd2888', N'حذف', 3, N'b1ae3420-c251-4768-8d67-3c7b080826d8', CAST(N'2023-06-02T13:39:23.7000000' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");



            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'4466d663-11b7-46e8-8086-026fb58cc379', N'f635961a-1a75-4878-a1dd-a4c1130845cf', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2920199' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'08f7c882-4995-413c-90e1-084898f38119', N'43ae699a-55f6-43ca-aaa1-53c3e4956792', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2673710' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'c9ada347-0bfa-4390-8237-0b04c980aeb3', N'1be47aca-5471-4af9-aa4d-e8202375af43', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9218796' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'3f16bc35-0f96-4a26-b911-1750b85ca770', N'377674bd-a7fe-4fa4-b6fe-301fd199115a', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8181875' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0e587fcf-63c4-4418-b2db-1e8022df8b77', N'f3c9605c-ffa1-4017-8814-2274d056a98c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9242647' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'd59d8491-3738-4661-b4d2-26106eb9bdbe', N'081c16ba-c791-4152-b688-9c5f4a08864f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7456700' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'ac3ced8a-73a2-4d4c-a01f-2b1a2e7802c6', N'1a665a41-ed24-407c-99db-a1ee56333115', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5894483' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'3fa969dd-2bed-47bc-959c-2b8a6c87de34', N'fa6e9967-cb80-4239-acd5-9d2d47a26b97', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2502363' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'1b4fb8c9-e8ef-47c1-b198-2fa5779519e3', N'0038da23-2868-46f8-928b-644af455dd1c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2751996' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'77f16bf3-ef76-4763-94c8-3206c70d35d3', N'd2011900-b929-4243-b4ca-f36575c54d8f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2934465' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'3c0a1232-dc22-4313-ba66-46dcda38b09e', N'496a3e67-9a96-4e8b-9965-76ed20b62968', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2685248' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'8fadcaee-eb43-4018-9059-541c32212474', N'0a4d6779-fb6d-4221-b20c-db7425390b78', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8197430' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'e7253ce1-4a99-48ea-bdeb-5bab555fb1bd', N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5848196' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'a7664c61-1304-476c-887b-652022b08ec1', N'd8689322-b954-4522-a49c-a6593b15494e', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:43.5880417' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'9a06851a-c36b-4aef-80f5-6a00755b2f3b', N'54ee0ca0-90b1-4fc8-9b96-1250bf732248', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7473353' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'10ef91ff-ed51-440a-9a7d-6b4e513c49a0', N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.7983742' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'f708b410-9cab-42e6-9e8d-9c115b18a29a', N'182e5b2e-773e-41e8-b8fe-88fcffaadcff', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-30T15:47:09.9339934' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'41e8f390-26ee-4daa-acf1-9dc9c4b376bb', N'8a6861e7-52a3-4473-be9d-80831f456db0', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.9260858' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'67103d09-0717-4848-9ed1-9feb6e341d42', N'552fd52b-f1b1-47b7-847a-37e57a86bd58', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7437437' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'2242e0af-a0d6-404c-b2a1-a4508c96bbf8', N'b541519d-5391-4ece-bc2a-80320424ec0e', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2667159' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'9cc02c3b-db73-422d-a80d-a7b64dba9ff9', N'54120a72-aa08-4860-b385-9edb22911825', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T16:24:32.8992901' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'0aaa7619-49f4-49c0-9a8f-c84f9369b060', N'5bd9a512-2c0c-43a2-83d0-df627f797c7d', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T14:19:59.2900401' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'a2453ce5-9ee8-44c9-aa34-d2c959abcba2', N'feec286c-0026-4cf1-911f-7e86eb0b4384', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T23:58:30.2701019' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'846b3903-4ed7-4ac4-a04e-d3763b76aa7e', N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2774056' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'16791475-5ab4-40f5-8451-de0343ce9aa1', N'e5525d49-0ffc-430a-a384-10f69dff488c', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T12:19:59.8164479' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'c9ec9dda-7e0c-417d-a2b3-e36151203c14', N'9ce6bdca-17c6-43e8-9072-670e269ce5b8', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2048315' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'04df5afb-df5a-470d-8ca4-e4acfcc8a8ec', N'4a8d7a3c-5f82-4103-8539-fc634ee226ec', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-05-31T01:32:50.2725935' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'2112699b-2983-42a2-91a2-ff35ab920888', N'ab5a5c01-426e-4a80-87a8-43274db628d2', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-01T13:13:47.7237282' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'c50a6b28-21fd-4e6c-9ed8-5081b475fa6f', N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1714565' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'cf8ebed4-657c-4c18-af89-78698ca88bbd', N'6f892b48-0beb-42f4-b352-bd420c7b8d72', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1530205' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'5fa48470-0d4b-4e90-859a-0d7eaccf56a0', N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1731741' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");
            migrationBuilder.Sql("INSERT into [People].[UserPermissions]([ID], [PageActionId], [UserTypeId], [CreatedDate], [AddedBy], [ModifiedDate], [ModifiedBy], [IsDeleted], [IsActive], [DeletedDate], [DeletedBy]) VALUES(N'25cf7ae7-0149-4a42-8125-405a896ce2d1', N'f25bc116-cf01-41e7-879f-8a775abd2888', N'd3c1e01c-becc-4002-8d0b-2e3266bb2d71', CAST(N'2023-06-02T13:41:20.1748929' AS DateTime2), NULL, NULL, NULL, 0, 1, NULL, NULL)");

            migrationBuilder.Sql(@"CREATE proc[Guide].[spItemGroups]
            @DisplayLength int,
            @DisplayStart int,
            @SortCol int,
            @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL

            as
            begin
            Declare @FirstRec int, @LastRec int
            Set @FirstRec = @DisplayStart;
                Set @LastRec = @DisplayStart + @DisplayLength;

                With TBL as
                (
                     Select ROW_NUMBER() over(order by
            
             case when(@SortCol = 0 and @SortDir = 'asc')
            
                         then ID
            
                     end asc,
                     case when(@SortCol = 0 and @SortDir = 'desc')
            
                         then ID
            
                     end desc,
            		   case when(@SortCol = 1 and @SortDir = 'asc')
            
                         then Name
            
                     end asc,
                     case when(@SortCol = 1 and @SortDir = 'desc')
            
                         then Name
            
                     end desc,
            		   
		    
		       case when(@SortCol = 4 and @SortDir = 'asc')
            
                         then[CreatedDate]
            
                     end asc,
                     case when(@SortCol = 4 and @SortDir = 'desc')
            
                         then[CreatedDate]
            
                     end desc

                  )

                     as RowNum,
             COUNT(*) over() as TotalCount
                ,format( [CreatedDate],'yyyy/MM/dd')AddedDate,
                [ID]
                ,[Name]
                ,[AddedBy]
                ,[ModifiedDate]
                ,[ModifiedBy]
                ,[IsDeleted]
                ,[IsActive]
                ,[DeletedDate]
                ,[DeletedBy]
                FROM[Guide].[ItemGrpoups]



             where(@Search IS NULL
                     Or[Name] like '%' + @Search + '%'
                     ) and IsDeleted = 0
		    		 
		    		 
		    		 
		    		   )
		    		 					

    
            Select*
            from TBL
            where RowNum > @FirstRec and RowNum <= @LastRec

            end
            GO");

            migrationBuilder.Sql(@"CREATE proc[Guide].[spStocks]
                        @DisplayLength int,
                        @DisplayStart int,
                        @SortCol int,
                        @SortDir nvarchar(10),
            @Search nvarchar(255) = NULL,
            @UserId uniqueidentifier

            as
            begin
                Declare @FirstRec int, @LastRec int
                Set @FirstRec = @DisplayStart;
                        Set @LastRec = @DisplayStart + @DisplayLength;

                        With TBL as
                        (
                             Select ROW_NUMBER() over(order by
        
                     case when(@SortCol = 0 and @SortDir = 'asc')
        
                                 then s.ID
        
                             end asc,
                             case when(@SortCol = 0 and @SortDir = 'desc')
        
                                 then s.ID
        
                             end desc,
        		               case when(@SortCol = 1 and @SortDir = 'asc')
        
                                 then s.[Name]
        
                             end asc,
                             case when(@SortCol = 1 and @SortDir = 'desc')
        
                                 then s.[Name]
        
                             end desc,
        		   
		
		               case when(@SortCol = 4 and @SortDir = 'asc')
        
                                 then s.[CreatedDate]
        
                             end asc,
                             case when(@SortCol = 4 and @SortDir = 'desc')
        
                                 then s.[CreatedDate]
        
                             end desc

                          )

                             as RowNum,
                     COUNT(*) over() as TotalCount
                  ,format(s.[CreatedDate], 'yyyy/MM/dd')AddedDate,
                  s.[ID]
                  ,s.[Name]
                  ,s.[AddedBy]
                  ,s.[IsActive]
	              ,s.[Address]
                  ,s.[Phone]
                   ,s.[ManagerName]
              FROM[Guide].Stocks s
              inner join[People].[UserStocks] us on us.[StockId] = s.ID


                     where(@Search IS NULL
                             Or s.[Name] like '%' + @Search + '%'
                             ) and s.IsDeleted = 0


                             AND us.UserId = @UserId
				 
				               )
				 					

    
                Select*
                from TBL
                where RowNum > @FirstRec and RowNum <= @LastRec

                end

                GO");

            migrationBuilder.Sql(@"
                CREATE proc [Guide].[spUnits]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
    Set @LastRec = @DisplayStart + @DisplayLength;
  
    With TBL as
    (
         Select ROW_NUMBER() over (order by
        
         case when (@SortCol = 0 and @SortDir='asc')
             then ID
         end asc,
         case when (@SortCol = 0 and @SortDir='desc')
             then ID
         end desc,
		   case when (@SortCol = 1 and @SortDir='asc')
             then Name
         end asc,
         case when (@SortCol = 1 and @SortDir='desc')
             then Name
         end desc,
		   
		
		   case when (@SortCol = 4 and @SortDir='asc')
             then [CreatedDate]
         end asc,
         case when (@SortCol = 4 and @SortDir='desc')
             then [CreatedDate]
         end desc

      )
		
         as RowNum,
         COUNT(*) over() as TotalCount
      ,format( [CreatedDate],'yyyy/MM/dd')AddedDate,
      [ID]
      ,[Name]
	  ,[ParentId]
	  ,(select top 1 uu.Name from [Guide].[Units] uu where uu.ID= u.ParentId) ParentName
	  ,[UnitType]
	  ,[Rate]
      ,[AddedBy]
      ,[ModifiedDate]
      ,[ModifiedBy]
      ,[IsDeleted]
      ,[IsActive]
      ,[DeletedDate]
      ,[DeletedBy]
  FROM [Guide].[Units] u

    
         where (@Search IS NULL
                 Or [Name] like '%' + @Search + '%'
                 ) and IsDeleted=0
				 
				 
				 
				   )
				 					

    
    Select *
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec
	end
GO
");
            migrationBuilder.Sql(@"create proc [People].[spUsers]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@Search nvarchar(255) = NULL,
@UserClassification int = Null

as
begin
    Declare @FirstRec int, @LastRec int
    Set @FirstRec = @DisplayStart;
    Set @LastRec = @DisplayStart + @DisplayLength;
  
    With TBL as
    (
         Select ROW_NUMBER() over (order by
        
         case when (@SortCol = 0 and @SortDir='asc')
             then s.ID
         end asc,
         case when (@SortCol = 0 and @SortDir='desc')
             then s.ID
         end desc,
		   case when (@SortCol = 1 and @SortDir='asc')
             then s.[Name]
         end asc,
         case when (@SortCol = 1 and @SortDir='desc')
             then s.[Name]
         end desc,
		   
		
		   case when (@SortCol = 4 and @SortDir='asc')
             then s.[CreatedDate]
         end asc,
         case when (@SortCol = 4 and @SortDir='desc')
             then s.[CreatedDate]
         end desc

      )
		
         as RowNum,
         COUNT(*) over() as TotalCount
      ,format(s.[CreatedDate],'yyyy/MM/dd')AddedDate
	  ,s.ID
      ,s.[UserName]
      ,s.[Email]
      ,s.[Phone]
      ,s.[Address]
      ,s.[UserImage]
      ,s.[UserClassification]
      ,s.[UserTypeId]
	  ,(select top 1 ut.Name from [Guide].[UserTypes] ut where ut.ID = s.UserTypeId) UserTypeName
	  ,	(select STRING_AGG(CONVERT(NVARCHAR(max),gs.Name),'/') from [Guide].[Stocks] gs 
		inner join [People].[UserStocks] us on us.StockId=gs.ID
		where gs.IsActive = 1 and gs.IsDeleted = 0 and us.UserId = s.ID) StockNames
      ,s.[Name]
      ,s.[IsActive]
  FROM [People].[Users] s
  
  

  where (@Search IS NULL
                 Or s.[Name] like '%' + @Search + '%'
                 ) and s.IsDeleted=0
				 and (@UserClassification is null or s.UserClassification = @UserClassification)
				   )
        
    Select *
    from TBL
    where RowNum > @FirstRec and RowNum <= @LastRec
	end");

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'4466d663-11b7-46e8-8086-026fb58cc379'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'08f7c882-4995-413c-90e1-084898f38119'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'c9ada347-0bfa-4390-8237-0b04c980aeb3'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'3f16bc35-0f96-4a26-b911-1750b85ca770'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'0e587fcf-63c4-4418-b2db-1e8022df8b77'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'd59d8491-3738-4661-b4d2-26106eb9bdbe'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'ac3ced8a-73a2-4d4c-a01f-2b1a2e7802c6'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'3fa969dd-2bed-47bc-959c-2b8a6c87de34'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'1b4fb8c9-e8ef-47c1-b198-2fa5779519e3'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'77f16bf3-ef76-4763-94c8-3206c70d35d3'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'3c0a1232-dc22-4313-ba66-46dcda38b09e'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'8fadcaee-eb43-4018-9059-541c32212474'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'e7253ce1-4a99-48ea-bdeb-5bab555fb1bd'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'a7664c61-1304-476c-887b-652022b08ec1'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'9a06851a-c36b-4aef-80f5-6a00755b2f3b'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'10ef91ff-ed51-440a-9a7d-6b4e513c49a0'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'f708b410-9cab-42e6-9e8d-9c115b18a29a'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'41e8f390-26ee-4daa-acf1-9dc9c4b376bb'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'67103d09-0717-4848-9ed1-9feb6e341d42'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'2242e0af-a0d6-404c-b2a1-a4508c96bbf8'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'9cc02c3b-db73-422d-a80d-a7b64dba9ff9'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'0aaa7619-49f4-49c0-9a8f-c84f9369b060'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'a2453ce5-9ee8-44c9-aa34-d2c959abcba2'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'846b3903-4ed7-4ac4-a04e-d3763b76aa7e'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'16791475-5ab4-40f5-8451-de0343ce9aa1'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'c9ec9dda-7e0c-417d-a2b3-e36151203c14'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'04df5afb-df5a-470d-8ca4-e4acfcc8a8ec'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'2112699b-2983-42a2-91a2-ff35ab920888'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'c50a6b28-21fd-4e6c-9ed8-5081b475fa6f'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'cf8ebed4-657c-4c18-af89-78698ca88bbd'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'5fa48470-0d4b-4e90-859a-0d7eaccf56a0'");
            migrationBuilder.Sql("Delete from [People].[UserPermissions] where ID=N'25cf7ae7-0149-4a42-8125-405a896ce2d1'");


            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'f3d46c1d-8b40-426b-8f16-0ed9ca488b12'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'e5525d49-0ffc-430a-a384-10f69dff488c'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'54ee0ca0-90b1-4fc8-9b96-1250bf732248'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'f3c9605c-ffa1-4017-8814-2274d056a98c'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'377674bd-a7fe-4fa4-b6fe-301fd199115a'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'552fd52b-f1b1-47b7-847a-37e57a86bd58'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'ab5a5c01-426e-4a80-87a8-43274db628d2'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'43ae699a-55f6-43ca-aaa1-53c3e4956792'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'0038da23-2868-46f8-928b-644af455dd1c'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'9ce6bdca-17c6-43e8-9072-670e269ce5b8'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'496a3e67-9a96-4e8b-9965-76ed20b62968'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'feec286c-0026-4cf1-911f-7e86eb0b4384'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'b541519d-5391-4ece-bc2a-80320424ec0e'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'8a6861e7-52a3-4473-be9d-80831f456db0'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'182e5b2e-773e-41e8-b8fe-88fcffaadcff'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'0bbd2cc1-6a9d-4cb9-9d3f-91a1d420970a'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'081c16ba-c791-4152-b688-9c5f4a08864f'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'fa6e9967-cb80-4239-acd5-9d2d47a26b97'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'54120a72-aa08-4860-b385-9edb22911825'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'1a665a41-ed24-407c-99db-a1ee56333115'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'f635961a-1a75-4878-a1dd-a4c1130845cf'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'd8689322-b954-4522-a49c-a6593b15494e'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'0a4d6779-fb6d-4221-b20c-db7425390b78'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'5bd9a512-2c0c-43a2-83d0-df627f797c7d'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'1be47aca-5471-4af9-aa4d-e8202375af43'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'4f6bb85a-43f2-4ed7-87e4-ef264170efdb'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'd2011900-b929-4243-b4ca-f36575c54d8f'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'4a8d7a3c-5f82-4103-8539-fc634ee226ec'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'8d52ebc0-0019-44f8-a0a1-dd7b600ebece'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'6f892b48-0beb-42f4-b352-bd420c7b8d72'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'd2c96142-29d9-46e5-aaa8-d6d47ae8fa1f'");
            migrationBuilder.Sql("Delete from [Page].[ActionsPages] where ID=N'f25bc116-cf01-41e7-879f-8a775abd2888'");


            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'0d0c7a10-2d04-4f62-b0cf-0bf96b6b176b'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'75cd0ab2-7004-4dea-842b-15228d704f68'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'680e0745-ba76-4180-bc58-21247c7d10b5'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'd0bdef6a-d651-48f3-83d1-6c3305402ef0'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'fa13eb55-9920-4d95-b13c-70d9a5c0cb1a'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'2a38ccb7-3d8d-42b1-b405-82b95529cf92'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'54eb4de9-3354-4ab1-ab1a-84b093d30214'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'aeb2b7fe-b407-4024-b8b4-9938d854ab8e'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'428474bc-78dd-4d51-b514-ac33b3bd4119'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'2d7535b1-9e0a-4f8c-892b-d028ed989613'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'a7a259be-2b00-4f91-8ba9-e2ae4e6e10b5'");
            migrationBuilder.Sql("Delete from [Page].[Pages] where ID=N'b1ae3420-c251-4768-8d67-3c7b080826d8'");


            migrationBuilder.Sql("Delete from [People].[Users]    where ID='80968c16-15d8-4533-b771-5285299edcb6'");

            migrationBuilder.Sql("Delete from [Guide].[UserTypes] where ID='d3c1e01c-becc-4002-8d0b-2e3266bb2d71'");
            migrationBuilder.Sql("Delete from [Guide].[UserTypes] where ID='8484e624-c5a0-463e-986a-66a118d1f2eb'");
            migrationBuilder.Sql("Delete from [Guide].[UserTypes] where ID='df5d2d3c-655a-431e-93a3-ac4af07c8805'");

            migrationBuilder.Sql("Delete PROCEDURE []");
        }
    }
}
