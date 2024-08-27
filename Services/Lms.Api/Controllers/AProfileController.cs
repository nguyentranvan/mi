using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MI.Controller.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Lms.API.DAL;
using MI.HttpResponses.Lib;
namespace Lms.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AProfileController : MIBaseController<AProfile, IAProfileDAL>
    {
        private readonly ILogger<AProfileController> _logger;
        public AProfileController(ILogger<AProfileController> logger, IAProfileDAL dal) : base(dal)
        {
            _logger = logger;
        }

        [HttpGet]
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
        public async Task<IActionResult> Update([FromBody] AProfile model)
        {
            var obj = new AProfile();

            if (model.UserId == Guid.Empty)
            {
                obj.UserId = Guid.NewGuid();
                obj.CreatedUserId = obj.LastUpdatedUserId = UserId;
                obj.CreatedDate = obj.LastUpdatedDate = DateTime.UtcNow;
                _dal.Add(obj);
            }
            else
            {
                obj = await _dal.Get(model.UserId);
                obj.CreatedDate = obj.LastUpdatedDate = DateTime.UtcNow;
            }
            #region set
            obj.EmployeeCode = model.EmployeeCode;
            obj.FullName = model.FullName;
            obj.DepartmentId = model.DepartmentId;
            obj.OrganizeId = model.OrganizeId;
            #endregion

            await _dal.SaveChangesAsync();
            var response = new ApiResponse()
            {
                Data = obj
            };
            return Ok(response);
        }
    }
}
