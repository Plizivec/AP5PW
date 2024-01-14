using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Project.Domain.Entities;
using Project.Infrastructure.Identity;

namespace Project.Application.Abstraction
{
    public interface ITipService
    {
        IList<Tip> Select();
        int Create(Tip tip);
        bool Delete(int id);
        Tip GetTipById(int id);
        void Edit(Tip updatedTip);
        string GetCurrentUserName(HttpContext context);

        IList<Tip> GetTipsByAuthor(string author);
        IList<Tip> SearchTips(string searchTerm);

    }
}