using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLibrary;

namespace MazeLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            BFSAlgorithm BFS = new BFSAlgorithm(
                new bool?[,]
                {
                    {false, null, true, null },
                    {null, null, false, false },
                    {null, false, null, true },
                    {null, false, null, null }
                },
                0, 0);


            Stack<Directions> Dirs = BFS.getSolution();

            if (Dirs != null)
            {
                foreach (Directions D in Dirs)
                    Console.WriteLine(D.ToString());
            }
            else
                Console.WriteLine("No Solution");

            Console.ReadKey();
        }
    }
}
