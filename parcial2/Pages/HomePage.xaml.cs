using parcial2.Models;
using parcial2.ViewModels;

namespace parcial2.Pages;

public partial class HomePage : ContentPage
{	
	private readonly HomeViewModel _homeViewModel;
	public HomePage(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		_homeViewModel = homeViewModel;
		BindingContext = _homeViewModel;
	}


}