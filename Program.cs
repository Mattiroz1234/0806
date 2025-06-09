using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0806
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Agent agent = new Agent( 8, "jhgy", "tmhmnv", "gcews", "hrbed", 8);
            //DAL.AddAgent(agent);
            List<Agent> a = DAL.GetAgents();
            Console.WriteLine(a[0].RealName);

        }
    }
}
