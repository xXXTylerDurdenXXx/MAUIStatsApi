using MAUIStatsApi.ViewModel;

namespace MAUIStatsApi.View;

public partial class PlayerDetailsPage : ContentPage
{
	public PlayerDetailsPage(PlayerDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}