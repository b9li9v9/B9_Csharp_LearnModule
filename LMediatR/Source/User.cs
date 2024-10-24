using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMediatR.Source
{
    public class User
    {
        public string _name { get; set; }

        public User(string name)
        {
            _name = name;
        }
    }
}
