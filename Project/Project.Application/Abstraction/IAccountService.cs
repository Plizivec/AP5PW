using System;
using System.Data;
using Project.Application.ViewModels;
using Project.Infrastructure.Identity.Enums;

namespace Project.Application.Abstraction
{
    public interface IAccountService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
    }
}
