using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Room
    {
        private int roomNumber;

        public int Number { get; set; }

        public Room(int rnr)
        {
            this.roomNumber = rnr;
        }
    }

}
