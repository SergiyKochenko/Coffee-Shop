namespace Coffee_Shop.Services
{
    public class ProductService
    {
        // Private field holding a collection of Product objects
        private readonly IEnumerable<Product> _products = new List<Product>
        {
            // Initialization of Product objects with their properties
            new Product
            {
                Name = "Hot Chocolate",
                Category = "Hot Drink",
                Description = "Hot chocolate can be made with dark, semisweet, " +
                "or bittersweet chocolate grated or chopped into small pieces and" +
                " stirred into milk with the addition of sugar. Cocoa usually refers " +
                "to a drink made with cocoa powder, hot milk or water, and sweetened" +
                " to taste with sugar (or not sweetened at all)",
                Image = "coffee_cup1.png",
                Price = 1.9
            },
            new Product
            {
                Name = "Latte",
                Category = "Hot Drink",
                Description = "A latte or caffè latte is a milk coffee that boasts a" +
                " silky layer of foam as a real highlight to the drink. A true latte" +
                " will be made up of one or two shots of espresso, steamed milk and a final," +
                " thin layer of frothed milk on top.",
                Image = "coffee_cup2.png",
                Price = 1.5
            },
            new Product
            {
                Name = "Black Coffee",
                Category = "Hot Drink",
                Description = "Black coffee is simply coffeewith nothing added – no cream," +
                " no milk, no sweetener. When you leave out those extra ingredients, " +
                "you leave out the calories, fat, and sugar that come with them. " +
                "That allows you to enjoy the health benefits of coffee without " +
                "additives that aren't as good for you.",
                Image = "coffee_cup3.png",
                Price = 2.5
            },
            new Product
            {
                Name = "Cheese Burger",
                Category = "Food",
                Description = "A cheeseburger is a hamburger with a slice of melted cheese on top of the meat patty," +
                " added near the end of the cooking time. Cheeseburgers can include variations in structure," +
                " ingredients and composition.",
                Image = "burger1.png",
                Price = 3.0
            },
             new Product
            {
                Name = "Double Cheese Burger",
                Category = "Food",
                Description = "Love our Cheeseburger? Double it! Think two 100% beef patties with cheese," +
                 " onions, pickles, mustard and a dollop of tomato ketchup, all in a perfectly soft bun.",
                Image = "burger2.png",
                Price = 3.5
            },
              new Product
            {
                Name = "Iced Tea",
                Category = "Cold Drink",
                Description = "Iced tea (or ice tea) is a form of cold tea. Though it is usually served in a glass with ice," +
                  " it can refer to any tea that has been chilled or cooled. It may be sweetened with sugar or syrup.",
                Image = "iced_coffee.png",
                Price = 1.8
            },
               new Product
            {
                Name = "Cold Lemonade",
                Category = "Cold Drink",
                Description = "Lemonade. noun. lem·​on·​ade ˌlem-ə-ˈnād. : a drink made of lemon juice, sugar, and water",
                Image = "lemonade.png",
                Price = 2.2
            },
               new Product
            {
                Name = "Bottle soft drink",
                Category = "Cold Drink",
                Description = "Bottled soft drinks are a class of nonalcoholic beverage that contain water," +
                   " nutritive or nonnutritive sweeteners, acids, flavors, colors, emulsifiers, preservatives, " +
                   "and various other compounds that are added for their functional properties.",
                Image = "soft_drink3.png",
                Price = 2.5
            },
                  new Product
            {
                Name = "Glass soft drink",
                Category = "Cold Drink",
                Description = "A soft drink is any water-based flavored drink, usually but not necessarily carbonated," +
                      " and typically including added sweetener. Flavors used can be natural ...",
                Image = "soft_drinks5.png",
                Price = 2.0
            },


        };

        // Method to retrieve all products
        public IEnumerable<Product> GetAllProducts() => _products;

        // Method to retrieve products belonging to the "Food" category
        public IEnumerable<Product> GetFoodCategory()
        {
            var products = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Category == "Food")
                {
                    products.Add(product);
                }
            }
            return products;
        }

        // Method to retrieve products belonging to the "Hot Drink" category
        public IEnumerable<Product> GetHotDrinkCategory()
        {
            var products = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Category == "Hot Drink")
                {
                    products.Add(product);
                }
            }
            return products;
        }

        // Method to retrieve products belonging to the "Cold Drink" category
        public IEnumerable<Product> GetColdDrinkCategory()
        {
            var products = new List<Product>();
            foreach (var product in _products)
            {
                if (product.Category == "Cold Drink")
                {
                    products.Add(product);
                }
            }
            return products;
        }


        // Method to retrieve a specified number of random popular products
        public IEnumerable<Product> GetPopularProducts(int count = 6) => _products.OrderBy(p => Guid.NewGuid()).Take(count);

        // Method to retrieve products based on a search term
        public IEnumerable<Product> GetProducts(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _products
            : _products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
