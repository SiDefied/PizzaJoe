using PizzaJoe.Entities;



namespace PizzaJoe.DataModel
{
    public class PizzaModel
    {
        private List<PizzaProduct> Products;

        public PizzaModel()
        {
            Products = new List<PizzaProduct>()
            {
                new PizzaProduct
                {
                    Id = "01",
                    Name = "Veggie Pizza",
                    Price =510,
                    Photo = "veggie.jpg"
                },

                new PizzaProduct
                {
                    Id = "02",
                    Name = "Pepperoni Pizza",
                    Price =520,
                    Photo = "pepe.jpg"
                },
                new PizzaProduct
                {
                    Id = "03",
                    Name = "Margherita Pizza",
                    Price =530,
                    Photo = "marge.jpg"
                },
                new PizzaProduct
                {
                    Id = "04",
                    Name = "Chicken Pizza",
                    Price =540,
                    Photo = "chicken.jpg"
                },
                new PizzaProduct
                {
                    Id = "05",
                    Name = "Cheesy Pizza",
                    Price =550,
                    Photo = "cheesy.jpg"
                },
                new PizzaProduct
                {
                    Id = "06",
                    Name = "Peri Peri Chicken Pizza",
                    Price =560,
                    Photo = "peri.jpg"
                }
            };
        }
        public List<PizzaProduct> findAll()
        {
            return Products;
        }

        public PizzaProduct find(string id)
        {
            //return Products.Where(p => p.Id == id).FirstOrDefault();
            return Products.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
