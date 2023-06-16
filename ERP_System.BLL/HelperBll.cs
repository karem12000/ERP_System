using ERP_System.DAL;
using ERP_System.DTO;
using ERP_System.Tables;
using IronBarCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
