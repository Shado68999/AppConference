namespace AppConference.views;

public partial class ConferencePage : ContentPage
{
	public ConferencePage()
	{
		InitializeComponent();
	}

    private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
    {

    }

    private async void DelaitedClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetailedPage());
    }

}