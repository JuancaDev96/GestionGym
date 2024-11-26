using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Interfaces
{
    public interface IAwsService
    {
        Task<PutObjectResponse> S3_UploadFile(string base64Image, string bucketName, string objectKey);
    }
}
