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
    public class EClassCateController : MIBaseController<EClassCate, IEClassCateDAL>
    {
        private readonly ILogger<EClassCateController> _logger;
        public EClassCateController(ILogger<EClassCateController> logger, IEClassCateDAL dal) : base(dal)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Search(int offset, int limit, string keyword = "")
        {
            var data = await _dal.Search(offset, limit, keyword);
            var response = new ApiResponse()
            {
                MetaData = new ApiResponseMetaData { TotalRecord = data.TotalRows },
                Data = data.ListData
            };
            return Ok(response);
        }
        

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] EClassCate model)
        {
            var response = new ApiResponse() { Status = false };
            try
            {
                var obj = new EClassCate();
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
                    obj.LastUpdatedUserId = UserId;
                    obj.LastUpdatedDate = DateTime.UtcNow;
                }
                #region
                obj.Code = model.Code;
                obj.Name = model.Name;
                obj.CateType = model.CateType;
                obj.ParentId = model.ParentId;
                obj.OrderNum = model.OrderNum;
                #endregion
                //
                if (await _dal.SaveChangesAsync() > 0)
                    response = new ApiResponse() { Data = obj };

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new ApiResponse() { Status = false, Exception = ex };
                return Ok(response);
            }

        }
        [HttpGet("SearchByParentId")]
        public async Task<IActionResult> SearchByParentId(Guid parentId)
        {
            var data = await _dal.SearchByParentId(parentId);
            var response = new ApiResponse()
            {
                MetaData = new ApiResponseMetaData { TotalRecord = data.TotalRows },
                Data = data.ListData
            };
            return Ok(response);
        }
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail([FromRoute] Guid id)
        {
            var response = new ApiResponse() { Status = false };
            try
            {
                var obj = await _dal.Get(id);
                if (obj != null)
                    response = new ApiResponse() { Data = obj };

                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new ApiResponse() { Status = false, Exception = ex };
                return Ok(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = new ApiResponse() { Status = false };
            try
            {
                var obj = await _dal.Get(id);
                if (obj != null)
                {
                    _dal.Delete(obj);
                    if (await _dal.SaveChangesAsync() > 0)
                        response = new ApiResponse() { Data = obj };
                }    
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new ApiResponse() { Status = false, Exception = ex };
                return Ok(response);
            }
        }
    }
}
