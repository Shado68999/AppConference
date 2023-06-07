namespace AppConference.views;

public partial class ArticlePage : ContentPage
{
	public ArticlePage()
	{
		InitializeComponent();
	}

    private async void ExecuteAddArticle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddArticle());
    }
}