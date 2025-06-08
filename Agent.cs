using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0806
{
    internal class Agent
    {
        private int Id;
        internal string CodeName;
        internal string RealName;
        internal string Location;
        internal string Status;
        internal int MissionsCompleted;

        public Agent(int id, string cn, string rn, string loc, string sta, int mc)
        {
            Id = id;
            CodeName = cn;
            RealName = rn;
            Location = loc;
            Status = sta;
            MissionsCompleted = mc;

        }

    }
}
