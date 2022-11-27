using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using System.IO;
using System.Net;
using Spire.Pdf;
using Spire.Pdf.Exporting.XPS.Schema;
using Azure.Storage.Blobs.Models;
using static System.Reflection.Metadata.BlobBuilder;
using EducareBE.Models.Entities;
using AutoMapper;
using EducareBE.Data;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PdfTextExtractor = iTextSharp.text.pdf.parser.PdfTextExtractor;
using System.Text;

namespace EducareBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        public string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=educareblobstorage;AccountKey=Klgbskx26jhEn1aENaQ70czqX0a0iPKWN16PTKquk5oRA0To/2zugkpQVNy8zrAQGNHm3zLx3MzT+AStpasO7g==;EndpointSuffix=core.windows.net";
        public string blobStorageContainerName = "fileupload";

        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FileUploadController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("upload-pdf-file/{path}/for/{subjectAddedById}")]
        public async Task<IActionResult> UploadPdfForUser(string path, int subjectAddedById)
        {
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var blob = container.GetBlobClient(path);
            var pdfContent = new MemoryStream(System.IO.File.ReadAllBytes(path));
            pdfContent.Position = 0;
            await blob.UploadAsync(pdfContent);
            var file = new BlobContent
            {
                SubjectAddedById = subjectAddedById,
                Content = path
            };

            await _dbContext.BlobContents.AddAsync(file);
            await _dbContext.SaveChangesAsync();
            return Ok(file);
        }

        [HttpGet("get-pdf-file-by-subject-id/{subjectAddedById}")]
        public async Task<IActionResult> GetAllPdfOfSubjectAddedBy(int subjectAddedById)
        {
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var pdf = await _dbContext.BlobContents.Where(x => x.SubjectAddedById == subjectAddedById).FirstOrDefaultAsync();
            var blobClient = container.GetBlobClient(pdf.Content);
            return Ok(await blobClient.OpenReadAsync());
        }

        [HttpGet("get-pdf-text-content/{subjectAddedById}")]
        public async Task<IActionResult> GetAllTextContentFromPdf(int subjectAddedById)
        {
            var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            var pdf = await _dbContext.BlobContents.Where(x => x.SubjectAddedById == subjectAddedById).FirstOrDefaultAsync();
            var blobClient = container.GetBlobClient(pdf.Content);
            var url = @"AzureImages\" + subjectAddedById.ToString() + ".pdf";
            await blobClient.DownloadToAsync(url);

            StringBuilder sb = new StringBuilder();

            using (PdfReader reader = new PdfReader(url))
            {
                for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, strategy);
                    text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                    sb.Append(text);
                }
            }

            return Ok(sb.ToString());
        }

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
