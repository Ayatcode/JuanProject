using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Core.Entities;

public class FileUploadAPI
{
    public int ImgID { get; set; }
    public string? Customers { get; set; }
    public IFormFile? files { get; set; }
    public string ImgName { get; set; }
}
