using parcial2.ViewModels;

namespace parcial2.Pages;

public partial class DetailPage : ContentPage
{
	private readonly DetailsViewModel _detailsViewModel;
	public DetailPage(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();
        _detailsViewModel = detailsViewModel;
        BindingContext = _detailsViewModel;	
	}
}