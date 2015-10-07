using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStepsWebAPIMVC6.Models
{
    public class Hotel
    {
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int Sterne
        {
            get; set;
        }
    }
}
