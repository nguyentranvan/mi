using MI.Controller.Lib;
using MI.Helpers.Lib;
using MI.HttpResponses.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml;

namespace Lms.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FileController : MIBaseController
    {
        [HttpPost("Upload")]
        [DisableRequestSizeLimit]
        public async Task<object> Post([FromQuery] string contentType, [FromQuery] string objectName)
        {
            var files = Request.Form.Files;
            contentType = string.IsNullOrEmpty(contentType) ? "" : contentType.Trim().ToLower();

            if (files == null)
                return Ok(false);

            if (files.Count == 0)
                return Ok(false);
            // Tạo folder uploads nếu chưa có
            var rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(rootFolder)) Directory.CreateDirectory(rootFolder);
            var folderByType = InitFolderForContentType(objectName, contentType);
            rootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folderByType);
            if (!Directory.Exists(rootFolder)) Directory.CreateDirectory(rootFolder);

            try
            {
                List<FileResponse> listFiles = new List<FileResponse>();
                foreach (IFormFile file in files)
                {
                    var ext = Path.GetExtension(file.FileName).ToLower();
                    if (!".rar,.txt,.jpg,.jpeg,.png,.gif,.doc,.docx,.xls,.xlsx,.ppt,.pptx,.pdf,.mp4,.mp3,.wav,.flv,.zip,.epub,.tiff".Contains(ext))
                    {
                        return Ok(false);
                    }

                    if (file.Length == 0)
                    {
                        listFiles.Add(new FileResponse
                        {
                            Status = false,
                            Message = "Vui lòng tải lên tệp tin có nội dung."
                        });
                    }


                    if (file.Length > 0)
                    {
                        var fileName = $"{Path.GetFileNameWithoutExtension(Path.GetTempFileName())}_{file.FileName}";
                        fileName = StringHelper.ConvertStringToVNDash(fileName);
                        //
                        //Fixed API cho tài liệu
                        //
                        var others = new List<string>();
                        var bfileOk = true;
                        string filePath = Path.Combine(rootFolder, fileName);
                        using (var stream = new FileStream(Path.Combine(rootFolder, fileName), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            switch (contentType)
                            {
                                case "scorm":
                                    if (ext.Equals(".zip"))
                                    {
                                        others.Add(fileName);
                                        using (var archive = new ZipArchive(stream, ZipArchiveMode.Read))
                                        {
                                            var randomFolder = Guid.NewGuid().ToString();
                                            var extractPath = Path.Combine(rootFolder, randomFolder);
                                            archive.ExtractToDirectory(extractPath);
                                            var result = string.Empty;
                                            var type = string.Empty;
                                            var scormReader = ReadScormPackage(extractPath, out result, out type);

                                            if (scormReader) fileName = string.Format("{0}/{1}", randomFolder, result);
                                            else
                                            {
                                                bfileOk = false;
                                                listFiles.Add(new FileResponse  {  Status = false, Message = result});
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        fileName = folderByType + "/" + fileName;
                        // Xóa file

                        if (contentType.Equals("scorm") || (objectName == "question" && ext.Equals(".zip")))
                        {
                            try
                            {
                                if (System.IO.File.Exists(filePath))
                                {
                                    Console.WriteLine("Delete file SCORM: " + filePath);
                                    System.IO.File.Delete(filePath);
                                }
                            }
                            catch (Exception exDeleteFile)
                            {
                                Console.WriteLine("Delete file SCORM lỗi : " + exDeleteFile.Message);
                            }
                        }

                        if (bfileOk)
                        {
                            listFiles.Add(new FileResponse
                            {
                                Status = true,
                                FileName = fileName,
                                Size = file.Length,
                                Others = others
                            });
                        }
                    }
                }
                return new DefaultHttpResponseWithStatus<List<FileResponse>>
                {
                    Data = listFiles,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse()
                {
                    Message = ex.ToString(),
                    Status = false
                };
            }
        }
        private string StringHelperConvert(string userName)
        {
            var response = Regex.Replace(userName, @"[`!&\/\\#+()$~%@.:*?<=>{ }|,']", "-");
            return response;
        }
        private string InitFolderForContentType(string objectName, string contentType)
        {

            string folder = "";
            if (string.IsNullOrEmpty(objectName))
            {
                folder = "others";
            }
            else
            {
                folder = objectName;
            }
            string fullPathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
            if (!Directory.Exists(fullPathFolder)) Directory.CreateDirectory(fullPathFolder);
            if (!string.IsNullOrEmpty(contentType))
            {
                folder += "/" + contentType;
                fullPathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
                if (!Directory.Exists(fullPathFolder)) Directory.CreateDirectory(fullPathFolder);
            }
            if (UserName.Length > 0)
            {
                //Tạo folder theo username
                var folderUserName = StringHelperConvert(UserName);
                folder += "/" + folderUserName;
                fullPathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
                if (!Directory.Exists(fullPathFolder)) Directory.CreateDirectory(fullPathFolder);

                //Tạo folder theo ngày tháng
                DateTime date = DateTime.Now;
                var folderDate = date.ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                folder += "/" + folderDate;
                fullPathFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", folder);
                if (!Directory.Exists(fullPathFolder)) Directory.CreateDirectory(fullPathFolder);
            }
            return folder;
        }

        private bool ReadScormPackage(string packagePath, out string result, out string packageType)
        {
            var xmlDoc = default(XmlDocument);
            var ns = new XmlNamespaceManager(new NameTable());

            if (System.IO.File.Exists(Path.Combine(packagePath, "imsmanifest.xml")))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(packagePath, "imsmanifest.xml"));
                ns.AddNamespace("s", xmlDoc.DocumentElement.NamespaceURI);
                packageType = "scorm";

                var node = xmlDoc.DocumentElement.SelectSingleNode("/s:manifest", ns);
                if (node == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                var version = node.SelectSingleNode("s:metadata/s:schemaversion", ns);
                if (version == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                var resource = node.SelectSingleNode("s:resources/s:resource", ns);
                if (resource == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                var name = node.SelectSingleNode("s:organizations/s:organization/s:title", ns);
                if (name == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                var item = node.SelectSingleNode("s:organizations/s:organization/s:item", ns);
                string paramater = "";
                if (item != null)
                {
                    if (item.Attributes["parameters"] != null)
                    {
                        paramater = item.Attributes["parameters"].Value;
                    }
                }

                result = resource.Attributes["href"].Value + paramater;
                return true;
            }
            else if (System.IO.File.Exists(Path.Combine(packagePath, "tincan.xml")))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(packagePath, "tincan.xml"));
                ns.AddNamespace("t", xmlDoc.DocumentElement.NamespaceURI);
                packageType = "tincan";

                var node = xmlDoc.DocumentElement.SelectSingleNode("/t:tincan/t:activities/t:activity", ns);
                if (node == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                result = node.SelectSingleNode("t:launch", ns).InnerText;
                return true;
            }
            else if (System.IO.File.Exists(Path.Combine(packagePath, "meta.xml")))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(packagePath, "meta.xml"));
                ns.AddNamespace("t", xmlDoc.DocumentElement.NamespaceURI);
                packageType = "aicc";

                var node = xmlDoc.DocumentElement.SelectSingleNode("/m:meta/m:project", ns);
                if (node == null)
                {
                    result = "File scorm không đúng định dạng !";
                    return false;
                }

                result = "index_lms.html";
                return true;
            }

            result = "File scorm không đúng định dạng !";
            packageType = "";
            return false;
        }
    }
}
