using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppReadCsv
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LINQtoCSV;

    class Program
    {
        static void Main()
        {
            //new LinqToCsv().ExecuteByLinqToCsv();

            MyEntity entity1 = new MyEntity() { Id=1 , Age=20, BirthDay=DateTime.Parse("1981/11/28") , Name="Igarashi" };
            MyContext myContext = new MyContext();
            myContext.MyEntities.Add(entity1);
            myContext.SaveChanges();


        }

    }
    
}