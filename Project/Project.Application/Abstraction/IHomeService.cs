using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Application.ViewModels;

namespace Project.Application.Abstraction
{
    public interface IHomeService
    {
        RecipeViewModel GetHomeIndexViewModel();
    }
}
