using EduHome.Buisness.DTIOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHome.Buisness.Services.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDTO registerDTO);

    Task<TokenResponseDTO> Login(LoginDTO loginDTO);
}
