using MAUIStatsApi.ViewModel;

namespace MAUIStatsApi.View;

public partial class PlayersPage : ContentPage
{
	public PlayersPage(PlayersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}