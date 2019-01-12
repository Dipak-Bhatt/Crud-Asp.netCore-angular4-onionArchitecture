using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CG.Services;
using DB.Entity;
using DB.Entity.ServiceResp;
using DB.Services;
using DBCrud.Dto;
using DBCrud.Ext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DBCrud.Controllers
{
    [Produces("application/json")]
    [Route("v1/testimonial/")]
    public class TestimonialController : BaseController
    {
        [Route("getall")]
        public IActionResult Index(FilterReq pModel)
        {

            _logger.LogInformation("Index Executing..");
            var dtoList = new List<TestimonialDto>();
            var serviceResult = _service.GetAll(pModel);
            if (!serviceResult.Status)
            {
                return Okay(serviceResult);
            }

            foreach (var testimonial in serviceResult.Data)
            {
                var dto = _mapper.Map<Testimonial, TestimonialDto>(testimonial);
                dtoList.Add(dto);
            }
            return Okay(new ServiceResponse<List<TestimonialDto>>(true)
            {
                Data = dtoList
            });
        }
     
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Create([FromBody]TestimonialDto dto)
        {
            _logger.LogInformation("Create Executing..");
            if (!ModelState.IsValid)
            {
                var message = ModelState.GetModelErrors().Select(x => new Messages
                {
                    Code = "XX",
                    Description = x
                }).ToList();
                return Okay(new ServiceResponse(false, message));
            }
            var entity = _mapper.Map<TestimonialDto, Testimonial>(dto);
           
            var serviceResult = await _service.CreateAsync(entity);
           
            return Okay(serviceResult);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Okay(new ServiceResponse(false, new List<Messages> { AppMessages.DataNotFound }));
            }
            _logger.LogInformation("getTestimonial Executing..");
            var serviceResult = _service.Detail(id.Value);
            if (serviceResult.Status)
            {
                var entity = _mapper.Map<Testimonial, TestimonialDto>(serviceResult.Data);
                return Okay(new ServiceResponse<TestimonialDto>(serviceResult.Status)
                {
                    Data = entity,
                    Messages = serviceResult.Messages
                });
            }

            return Okay(serviceResult);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Edit([FromBody]TestimonialDto dto)
        {
            _logger.LogInformation("Edit post Executing..");

            if (!ModelState.IsValid)
            {
                 var message = ModelState.GetModelErrors().Select(x => new Messages
                {
                    Code = "XX",
                    Description = x
                }).ToList();
                return Okay(new ServiceResponse(false, message));
            }
          
            var detailResp= _service.Detail(dto.Id);
            if (!detailResp.Status)
            {
                return Okay(new ServiceResponse<TestimonialDto>(detailResp.Status)
                {
                    Data = dto,
                    Messages = detailResp.Messages
                });
            }
            var entity = detailResp.Data;
            entity.Address = dto.Address;
            entity.Descriptions = dto.Descriptions;
            entity.Title = dto.Title;
            entity.Email = dto.Email;
            entity.IsActive = dto.IsActive;

           
            var serviceResult = await _service.EditAsync(entity);
            if (serviceResult.Status)
            {
                return Okay(serviceResult);
            }
           
            return Okay(serviceResult);

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return Okay(new ServiceResponse(false, new List<Messages> { AppMessages.DataNotFound }));
            }

            _logger.LogInformation("Delete Executing..");
            var serviceResult = await _service.DeleteAsync(id.Value);
            return Okay(serviceResult);
        }
        //[HttpGet]
        //public async Task<IActionResult> Download(int id)
        //{
        //    var adDisplayPage = string.Empty;
        //    try
        //    {
        //        var data = _service.Detail(id);

        //        var webRoot = _env.WebRootPath;
        //        var pathWithFolderName = Path.Combine(webRoot, FilePathProvider.TestimonialPath);
        //        if (!string.IsNullOrEmpty(data.Data.ImageName))
        //        {

        //            pathWithFolderName = pathWithFolderName + @"\" + data.Data.ImageName;
        //            var memory = new MemoryStream();
        //            using (var stream = new FileStream(pathWithFolderName, FileMode.Open))
        //            {
        //                await stream.CopyToAsync(memory);
        //            }
        //            memory.Position = 0;
        //            return File(memory, GetContentType(pathWithFolderName), Path.GetFileName(pathWithFolderName));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var message = ModelState.GetModelErrors().Select(x => new Message
        //        {
        //            Code = SystemMessage.ValidationFailed.Code,
        //            Description = ex.Message
        //        }).ToList();
        //        SetServiceResult(new ServiceResult(false, message));
        //        return RedirectToAction("Index", new { SortExpression = adDisplayPage });
        //    }
        //    return RedirectToAction("Index", new { SortExpression = adDisplayPage });
        //}
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},

                    {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        public TestimonialController(ITestimonialService service, ILogger<TestimonialController> logger,
            IHostingEnvironment env, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _env = env;
            _mapper = mapper;
        }
        private readonly IMapper _mapper;
        private readonly string FilePathProvider = "Testimonial";
        private readonly IHostingEnvironment _env;
        private readonly ILogger<TestimonialController> _logger;
        private readonly ITestimonialService _service;

    }
}