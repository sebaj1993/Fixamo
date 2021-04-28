using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixamoEntityFrame.Clases
{
    class Session
    {
        public Session() { }
        public int userId { get; set; }
        public string user { get; set; }
        public static Session instance;
        public static Session getInstance()
        {
            if (instance == null)
                instance = new Session();
            return instance;
        }
    }
}
