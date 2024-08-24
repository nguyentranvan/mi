using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MI.Controller.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Lms.API.DAL;
using MI.HttpResponses.Lib;
namespace Lms.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ACertificateController : MIBaseController<ACertificate, IACertificateDAL>
    {
        private readonly ILogger<ACertificateController> _logger;
        public ACertificateController(ILogger<ACertificateController> logger, IACertificateDAL dal) : base(dal)
        {
            _logger = logger;
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search()
        {
            var data = await _dal.GetAll();
            var response = new ApiResponse()
            {
                MetaData = new ApiResponseMetaData { TotalRecord = data.TotalRows },
                Data = data
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ACertificate model)
        {
            var obj = new ACertificate();
            //
            if (model.Id == Guid.Empty)
            {
                obj.Id = Guid.NewGuid();
                obj.CreatedUserId = obj.LastUpdatedUserId = UserId;
                obj.CreatedDate = obj.LastUpdatedDate = DateTime.UtcNow;
                _dal.Add(obj);
            }
            else
            {
                obj = await _dal.Get(model.Id);
                obj.CreatedDate = obj.LastUpdatedDate = DateTime.UtcNow;
            }
            #region set
            obj.Code = model.Code;
            obj.Name = model.Name;
            obj.FileId = model.FileId;
            obj.Description = model.Description;
            #endregion
            //
            await _dal.SaveChangesAsync();
            var response = new ApiResponse()
            {
                Data = obj
            };
            return Ok(response);
        }
    }
}
