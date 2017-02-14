using System;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Demo.Core.Database.Model;
using Demo.Core.Models;
using Demo.Core.Validators;
using Demo.Framework.Extensions;
using Demo.Framework.Mediators;
using MongoDB.Driver;

namespace Demo.Core.MediatorHandlers
{
    public class CompressFileHandler : IAsyncRequestHandler<CompressFileModel, FileResultModel>
    {
        public async Task<FileResultModel> Handle(CompressFileModel message)
        {
            var oriLength = message.File.ContentLength;
            var img = Image.FromStream(message.File.InputStream);
            var oriHeight = img.Height;
            var oriWidth = img.Width;

            var resizeBm = new Bitmap(img, 285, 190);
            var dGraphics = Graphics.FromImage(resizeBm);
            dGraphics.CompositingQuality = CompositingQuality.HighQuality;
            dGraphics.SmoothingMode = SmoothingMode.HighQuality;
            dGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, 285, 190);
            dGraphics.DrawImage(img, imageRectangle);
            var base64String = "";
            var resizeLength = 0;
            using (var stream = new MemoryStream())
            {
                resizeBm.Save(stream, img.RawFormat);
                var imgBytes = stream.ToArray();
                resizeLength = imgBytes.Length;
                base64String = Convert.ToBase64String(imgBytes);
            }

            return new FileResultModel
            {
                Base64String = "data:image/jpeg;base64," + base64String,
                OriHeight = oriHeight,
                OriWidth = oriWidth,
                NewHeight = resizeBm.Height,
                NewWidth = resizeBm.Width,
                OriSize = oriLength,
                NewSize = resizeLength

            };
        }
    }
}
