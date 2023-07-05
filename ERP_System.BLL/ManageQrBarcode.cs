using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static IronSoftware.Drawing.AnyBitmap;
using ZXing.Common;
using ZXing.Rendering;
using ZXing;
using System.Drawing.Imaging;
using System.Drawing;

namespace ERP_System.BLL
{
    public class ManageQrBarcode
    {
        #region Props

        /// <summary>
        /// Content To Convert It To a barcode image, qrcode image  etc... 
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Width Of The Barcode , QrCode , etc ....  Image
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Height Of The Barcode , QrCode , etc ....  Image
        /// </summary>
        public int Height { get; private set; }

        #endregion

        #region Ctors

        public ManageQrBarcode(string Content, int Width, int Height)
        {
            this.Content = Content;
            this.Width = Width;
            this.Height = Height;
        }

        #endregion

        #region Methods

        /// <summary>
        /// It Converts a string to barcode image , qrcode image ,etc...
        /// </summary>
        /// <param name="barcodeFormat">Format is a barcode(Code_128) or qrcode or whatever you want</param>
        /// <returns></returns>
        public byte[] Stream(BarcodeFormat barcodeFormat)
        {
            //
            BarcodeWriterPixelData CodeWriter = new BarcodeWriterPixelData()
            {
                // Format is barcode or qrcode
                Format = barcodeFormat,
                Options = new EncodingOptions() { Width = Width, Height = Height, Margin = 0 }
            };

            PixelData Pixel_Data = CodeWriter.Write(Content);

            using Bitmap Bit = new Bitmap(Pixel_Data.Width, Pixel_Data.Height, PixelFormat.Format32bppArgb);
            using MemoryStream Memory = new MemoryStream();
            BitmapData bitMapData = Bit.LockBits(new Rectangle(0, 0, Pixel_Data.Width, Pixel_Data.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            try { Marshal.Copy(Pixel_Data.Pixels, 0, bitMapData.Scan0, Pixel_Data.Pixels.Length); }
            finally { Bit.UnlockBits(bitMapData); }

            Bit.Save(Memory, System.Drawing.Imaging.ImageFormat.Png);

            return Memory.ToArray();
        }

        /// <summary>
        /// Get a base64 image src from qrcode , barcode , etc
        /// </summary>
        /// <param name="barcodeFormat">Format is a barcode(Code_128) or qrcode or whatever you want</param>
        /// <returns></returns>
        public string Base64ImageSrc(BarcodeFormat barcodeFormat) => ImageFromBase64(Convert.ToBase64String(Stream(barcodeFormat)));

        #endregion

        #region Helper 
        static string ImageFromBase64(string base64) => string.Format("data:image/png;base64,{0}", base64);

        #endregion
    }
}
