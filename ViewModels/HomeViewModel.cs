using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using parcial2.Models;
using parcial2.Pages;
using parcial2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial2.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;
        public HomeViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetPopularPizzas());

        }

        public ObservableCollection<Pizza> Pizzas { get; set; }

        [RelayCommand]
        public async Task GoToDetailsPage(Pizza pizza)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Pizza)] = pizza
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }

}
