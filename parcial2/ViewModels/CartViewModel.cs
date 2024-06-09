using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using parcial2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//incompleto

namespace parcial2.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public ObservableCollection<Pizza> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(x => x.Amount);

        [RelayCommand]
        private void UpdateCartItem(Pizza pizza) 
        {
            var Item = Items.FirstOrDefault(i => i.Name == pizza.Name);
            if (Item is not null)
            {
                Item.CartQuantity = pizza.CartQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async void RemoveCartItem(string name)
        {             
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                //Si aparece error aqui, entonces quita los codigos de aca hasta...
                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.Goldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}' removed from cart",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                    }, "Undo", TimeSpan.FromSeconds(5), snackbarOptions);
                await snackbar.Show();
                //...aqui
            };
        }
        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Quitar cartelera", "Confirmar", "Si", "No"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                await Toast.Make("Carrito limpiado", ToastDuration.Short).Show();
            }

        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            RecalculateTotalAmount();
            await Shell.Current.DisplayAlert("Orden realizada", "Gracias por su compra", "Ok");
        }
    }
}
