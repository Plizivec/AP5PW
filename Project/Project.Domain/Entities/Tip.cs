using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Domain.Entities
{
    public class Tip : Entity<int>
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public string AutorId { get; set; }
        public double Hodnoceni { get; set; }
        public string ImageSrc { get; set; }

        //public virtual User Author { get; set; }

    }
}
