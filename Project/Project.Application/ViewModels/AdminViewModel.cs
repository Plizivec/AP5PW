using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public class AdminViewModel
    {
        public IList<Recipe> Recipes { get; set; }
        public IList<Tip> Tips { get; set; }
    }
}
