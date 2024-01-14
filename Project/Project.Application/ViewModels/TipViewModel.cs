using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public class TipViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }

        public string ImageSrc { get; set; }
        // Add other properties as needed for creating a tip
    }
}