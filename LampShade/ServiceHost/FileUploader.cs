﻿using System;
using System.IO;
using _0_Framework.Application;
using _0_FrameWork.Application;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public  string Upload(IFormFile file , string path)
        {
            if(file==null) return "";
            
             var directoryPath =$"{_webHostEnvironment.WebRootPath}//ProductPictures//{path}";
            if (Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

                var fileName=$"{DateTime.Now.ToFileName()}-{file.fileName}";

            var filePath=$"{directoryPath}//{fileName}";

            using (var output=System.IO.File.Create(filePath))
            {
                 file.CopyTo(output);
            }
                    return $"{path}/{fileName}";

        }
    }

}