using System;
using System.Linq;
using Xamarin.Forms;
using PropertyChanged;
using System.Net.Http;
using Newtonsoft.Json;
using PopularPizza.Models;
using System.Windows.Input;
using PopularPizza.Helpers;
using System.Threading.Tasks;
using PopularPizza.WebServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PopularPizza.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PizzaParserViewModel
    {
        private List<Pizza> _pizzas;
        private const string _url = "https://www.olo.com/pizzas.json";

        public bool IsLoaderVisibile { get; set; }
        public ObservableCollection<ToppingItem> Toppings { get; set; }

        public PizzaParserViewModel()
        {
            InitPizzaCommand.Execute(null);
        }

        /// <summary>
        /// Performs ViewModel initialization work
        /// </summary>
        public ICommand InitPizzaCommand => new Command(async () =>
        {
            IsLoaderVisibile = true;

            //I would've set this in the constructor but there is curreent an issue with Xamarin HotReload and this seems to be a work around.
            //https://github.com/xamarin/Xamarin.Forms/issues/10953

            Toppings = new ObservableCollection<ToppingItem>();
            await FetchPizzas();
            ParsePizza();
            IsLoaderVisibile = false;
        });

        /// <summary>
        /// Fetches a list of pizzas
        /// </summary>
        /// <returns></returns>
        public async Task FetchPizzas()
        {
            using (var client = new HttpClient(new RetryHandler(new HttpClientHandler())))
            {
                try
                {
                    var json = await client.GetStringAsync(_url);
                    _pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }
        }

        /// <summary>
        /// Filters out 20 most popular pizza toppings
        /// </summary>
        void ParsePizza()
        {
            var toppingsByCount = new Dictionary<string, int>();
            var toppings = _pizzas.SelectMany(x => x.Toppings).ToList();

            foreach (var topping in toppings)
            {
                if (toppingsByCount.TryGetValue(topping, out int count))
                    toppingsByCount[topping] = count + 1;
                else
                    toppingsByCount.Add(topping, 1);
            }

            var top20Toppings = (from pair in toppingsByCount
                                 orderby pair.Value descending
                                 select pair.Key)
                                .Take(20);

            foreach (var topping in top20Toppings)
            {
                Toppings.Add(new ToppingItem()
                {
                    ToppingName = topping,
                    ToppingImage = ToppingImage.GetToppingIcon(topping)
                });
            }
        }
    }
}