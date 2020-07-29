using System.Collections.Generic;

namespace PopularPizza.Helpers
{
    /// <summary>
    /// !Important: Normally I would make 1x, 2x, 3x etc sizes of an images but I doubt this is going to production :)
    /// </summary>
    public class ToppingImage
    {
        /// <summary>
        /// Retrieves image by topping name
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static string GetToppingIcon(string topping)
        {
            if (string.IsNullOrWhiteSpace(topping))
                topping = "unknown";

            return _images[topping];
        }

        /// <summary>
        /// Associates a topping with its image
        /// </summary>
        private static readonly Dictionary<string, string> _images = new Dictionary<string, string>
        {
            { "ham", "meat" },
            { "beef", "meat" },
            { "bacon", "meat" },
            { "salami", "meat" },
            { "chicken", "meat" },
            { "sausage", "meat" },
            { "unknown", "pizza" },
            { "pepperoni", "meat" },
            { "pineapple", "fruit" },
            { "onions", "vegitable" },
            { "lettuce", "vegitable" },
            { "four cheese", "cheese" },
            { "feta cheese", "cheese" },
            { "canadian bacon", "meat" },
            { "mushrooms", "vegitable" },
            { "jalapenos", "vegitable" },
            { "alredo sauce", "cheese" },
            { "anchovies", "vegitable" },
            { "giant pepperoni", "meat" },
            { "italian sausage", "meat" },
            { "artichokes", "vegitable" },
            { "fresh basil", "vegitable" },
            { "hot peppers", "vegitable" },
            { "cheddar cheese", "cheese" },
            { "black olives", "vegitable" },
            { "green peppers", "vegitable" },
            { "refried beans", "vegitable" },
            { "mozzarella cheese", "cheese" },
            { "diced tomatoes", "vegitable" },
            { "garlic basil oil", "vegitable" },
            { "parmesan parsley", "vegitable" },
            { "rosa grande pepperoni", "meat" },
            { "diced white onions", "vegitable" },
            { "roasted red pepper", "vegitable" },
            { "sliced roma tomatoes", "vegitable" },
            { "carmelized red onion", "vegitable" },
            { "sliced breaded chicken breast", "meat" },
        };
    }
}