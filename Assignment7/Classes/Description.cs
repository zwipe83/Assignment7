using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Classes
{
    public class Description
    {
        private string _description;

        public string Desc
        {
            get => _description; 
            set => _description = value;
        }

        public override string ToString() => Desc;
    }
}
