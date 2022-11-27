using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using System.IO;
using System.Net;
using Spire.Pdf;
using Spire.Pdf.Exporting.XPS.Schema;
using Azure.Storage.Blobs.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        public string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=educareblobstorage;AccountKey=Klgbskx26jhEn1aENaQ70czqX0a0iPKWN16PTKquk5oRA0To/2zugkpQVNy8zrAQGNHm3zLx3MzT+AStpasO7g==;EndpointSuffix=core.windows.net";
        public string blobStorageContainerName = "fileupload";

        [HttpPost("upload-pdf-file/{path}")]
        public async Task<IActionResult> UploadFile(string path)
        {
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var blob = container.GetBlobClient(path);
            var pdfContent = new MemoryStream(System.IO.File.ReadAllBytes(path));
            pdfContent.Position = 0;
            var response = await blob.UploadAsync(pdfContent);
            return Ok(response.Value);
        }

        [HttpGet("get-pdf-file/{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            var list = new List<BlobItem>();
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var blobClient = container.GetBlobClient(fileName);
            return Ok(await blobClient.OpenReadAsync());
        }
    }
}
