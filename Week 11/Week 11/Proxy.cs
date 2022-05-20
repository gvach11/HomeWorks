using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_11
{
    public abstract class Actor
    {
        abstract public void act();
    }

    public class RealActor : Actor
    {
        public override void act()
        {
            Console.WriteLine("I can act in simple scenes");
        }
    }

    public class StuntDouble : RealActor
    {
        RealActor realActor;
        public override void act()
        {
            if (realActor is null)
            {
                realActor = new RealActor();
                realActor.act();
                Console.WriteLine("I can also do dangerous stunts");
            }
        }
    }
}
