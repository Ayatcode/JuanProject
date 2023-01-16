using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.DTIOs.Auth;

public class RegisterDTO
{
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }

    public string? Password { get; set; }
}
