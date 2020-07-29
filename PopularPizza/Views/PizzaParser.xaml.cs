using Xamarin.Forms;
using PopularPizza.ViewModels;

namespace PopularPizza.Views
{
    public partial class PizzaParser : ContentPage
    {
        public PizzaParser()
        {
            InitializeComponent();
            BindingContext = new PizzaParserViewModel();
        }
    }
}