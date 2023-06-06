using AppConference.models;
using AppConference.Services;
using System.Windows.Input;

namespace AppConference.views.Label;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
       
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

  
        User loginUser = new(email, password);

        User authenticatedUser = await ApiService.Login(loginUser);

        if (authenticatedUser != null)
        {
            await DisplayAlert("Succès", "Connexion reussie", "OK");

            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            await DisplayAlert("Erreur", "E-mail ou Mot de Passe Invalide", "OK");
        }
    }
}