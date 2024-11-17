using Amazon.Runtime;
using Amazon.S3.Transfer;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using GestionGym.Servicios.Interfaces;

namespace GestionGym.Servicios.Implementaciones
{
    public class AwsService : IAwsService
    {

        private readonly IAmazonS3 _s3Client;

        public AwsService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task S3_UploadFile(string base64Image, string bucketName, string objectKey)
        {
            var imageBytes = Convert.FromBase64String(base64Image);
            using var memoryStream = new MemoryStream(imageBytes);

            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                InputStream = memoryStream,
                ContentType = "image/jpeg"
            };

            await _s3Client.PutObjectAsync(putRequest);
        }

    }
}
