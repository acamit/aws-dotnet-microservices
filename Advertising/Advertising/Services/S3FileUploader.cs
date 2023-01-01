using Amazon.S3;

namespace Advertising.Services
{
    public class S3FileUploader : IFileUploader
    {
        private readonly IConfiguration _configuration;

        public S3FileUploader(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public Task<bool> UploadFileAsync(string fileName, Stream storage)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(fileName, "File name must be specified");

            var bucketName = _configuration.GetValue<string>("ImageBucket");

            using (var client = new AmazonS3Client())
            {

            }
            return Task.FromResult(true);
        }
    }
}
