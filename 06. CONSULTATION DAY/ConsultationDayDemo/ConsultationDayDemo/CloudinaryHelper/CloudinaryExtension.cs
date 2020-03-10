using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConsultationDayDemo.CloudinaryHelper
{
    public static class CloudinaryExtension
    {
        public static async Task<List<string>> UploadAsync(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(@"D:\OneDrive\Projects\08.SoftUni-ASP.NETCore\06. CONSULTATION DAY\samurai-silhouette-.jpg")
            //};
            //var uploadResult = await cloudinary.UploadAsync(uploadParams);

            var list = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();

                using var destinationStream = new MemoryStream(destinationImage);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream)
                };

                var result = await cloudinary.UploadAsync(uploadParams);

                list.Add(result.Uri.AbsoluteUri);

                //cloudinary.DestroyAsync(new DeletionParams { PublicId = "" });
            }
            return list;
        }
    }
}
