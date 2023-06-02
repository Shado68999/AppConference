using AppConference.views;

namespace AppConference;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCommencerClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(page: new LoginPage());
    }
}

