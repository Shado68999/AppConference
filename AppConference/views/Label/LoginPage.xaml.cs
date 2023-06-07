using AppConference.models;
using AppConference.Services;
using System.Diagnostics;
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
        try
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            User loginUser = new User(email, password);

            User authenticatedUser = await ApiService.Login(loginUser);

            if (authenticatedUser != null)
            {
                await DisplayAlert("Succès", "Connexion réussie", "OK");

                await Navigation.PushAsync(new UserPage());
            }
            else
            {
                await DisplayAlert("Erreur", "E-mail ou Mot de Passe Invalide", "OK");
            }
        }
        catch (Exception ex)
        {
            // Gérer l'exception ici (par exemple, afficher un message d'erreur générique ou enregistrer l'exception dans les journaux)
            await DisplayAlert("Erreur", "Une erreur s'est produite lors de la connexion.", "OK");
            Debug.WriteLine("Erreur lors de la connexion : " + ex.Message);
        }
    }

}