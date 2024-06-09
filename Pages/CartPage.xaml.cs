using parcial2.ViewModels;

namespace parcial2.Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel _cartViewModel;
	public CartPage(CartViewModel cartViewModel)
	{
        _cartViewModel = cartViewModel;
		InitializeComponent();
		BindingContext = cartViewModel;
	}
}