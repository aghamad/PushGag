using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace PushGag.Util
{
    public interface ImageUploader {
        string UploadImage(string ImagePath);
        Cloudinary GetCloudinaryAccount();
    }
}