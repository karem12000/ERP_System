using ERP_System.DAL;
using ERP_System.DTO;
using ERP_System.Tables;
using IronBarCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ERP_System.BLL
{
    public class HelperBll
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRepository<Attachment> _repoAttatchment;

        public HelperBll(IWebHostEnvironment webHostEnvironment, IRepository<Attachment> repoAttatchment)
        {
            _webHostEnvironment = webHostEnvironment;
            _repoAttatchment = repoAttatchment;
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
        }
        public GeneratedBarcode GenerateBarcode(string generateBarcode)
        {
            if (!string.IsNullOrEmpty(generateBarcode))
            {

                GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generateBarcode, BarcodeWriterEncoding.Code128);
                barcode.ResizeTo(400, 120);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Styling a Barcode and adding annotation text
                barcode.ChangeBarCodeColor(Color.Black);
                barcode.SetMargins(10);
                
                return barcode;

            }
            return null;
        }
        public string GenerateBarcode(string generateBarcode, string FolderName)
        {
            if (!string.IsNullOrEmpty(generateBarcode))
            {

                GeneratedBarcode barcode = IronBarCode.BarcodeWriter.CreateBarcode(generateBarcode, BarcodeWriterEncoding.Code128);
                barcode.ResizeTo(400, 120);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Styling a Barcode and adding annotation text
                barcode.ChangeBarCodeColor(Color.Black);
                barcode.SetMargins(10);
                string path = _webHostEnvironment.WebRootPath + FolderName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = _webHostEnvironment.WebRootPath + FolderName + generateBarcode + ".png";
                barcode.SaveAsPng(filePath);
                string fileName = Path.GetFileName(filePath);
                return fileName;

            }
            return "";
        }

        public void UploadFiles(Guid ProductId, IFormFile[] files, string FolderName)
        {
            string basePath = _webHostEnvironment.WebRootPath;

            if (files != null && files.Count() > 0)
            {

                if (!Directory.Exists(basePath + FolderName))
                {
                    Directory.CreateDirectory(basePath + FolderName);
                }

                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = Path.GetRandomFileName() + Path.GetExtension(files[i].FileName);


                    var pathh = FolderName + fileName;
                    var filePath = basePath + FolderName + fileName;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {


                        var attatch = new Attachment
                        {
                            ProductId = ProductId,
                            Path = pathh,
                            Type = Common.General.AttachmentType.image,
                            Title = fileName
                        };
                        // newClinic.Paths.Add(ImgPaths);

                        if (_repoAttatchment.Insert(attatch))
                        {
                            files[i].CopyTo(fileStream);
                        }

                        fileStream.Dispose();
                    }

                }
            }
        }


        public string UploadFile(IFormFile file, string FolderName)
        {
            string basePath = _webHostEnvironment.WebRootPath;

            if (!Directory.Exists(basePath + FolderName))
            {
                Directory.CreateDirectory(basePath + FolderName);
            }


            var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);

            var pathh = FolderName + fileName;
            var filePath = basePath + FolderName + fileName;
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {

                file.CopyTo(fileStream);
            }

            return pathh;

        }


    }
}
