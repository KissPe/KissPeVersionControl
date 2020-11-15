using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstraction;

namespace week08.Entities
{
    public class Carfactory
    {
        public class CarFactory : IToyFactory

        {
            public Toy CreateNew()
            {
                return new Ball();
            }

            Toy IToyFactory.CreateNew()
            {
                throw new NotImplementedException();
            }
        }
    }
}
