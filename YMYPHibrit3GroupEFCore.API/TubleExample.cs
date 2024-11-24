using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API
{
    public class TubleExample
    {

        public int Calculate()
        {

            return 10;
        }

        public Tuple<int, string> Calculate2()
        {


            return new Tuple<int, string>(10, "test");
        }

        public Tuple<int, string, Product> Calculate3()
        {


            return new Tuple<int, string, Product>(10, "test", new Product());
        }

        public (int, string, Product) Calculate4()
        {


            return (4, "asp.net core", new Product());

        }
    }
}
