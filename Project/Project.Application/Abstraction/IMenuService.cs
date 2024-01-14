using Microsoft.AspNetCore.Http;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Abstraction
{
    public interface IMenuService
    {
        IList<Menu> GetMenus();
        Menu GetMenuById(int id);
        int Create(Menu menu);
        void EditMenu(Menu menu);
        bool DeleteMenu(int id);
        public IList<Menu> Select();
        string GetCurrentUserName(HttpContext context);

        IList<Menu> GetMenusByAuthor(string author);
    }
}