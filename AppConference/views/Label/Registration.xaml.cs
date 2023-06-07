using AppConference.models;
using AppConference.Services;
using System.Diagnostics;

namespace AppConference.views.Label;

public partial class Registration : ContentPage
{
    public Command Register { get; private set; }
    public Registration()
	{
		InitializeComponent();
        //Register = new Command(async () => await RegisterUser());
    }

    private async void OnLogInClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
        string name = NameFullEntry.Text;
        string email = mailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPassEntry.Text;
        string role = RoleEntry.Text;
        string origin = OriginEntry.Text;

        try
        {

            if (password != confirmPassword)
            {
                await DisplayAlert("Erreur", "Les mots de passe ne correspondent pas.", "OK");
                return;
            }


            var user = new User(name, email, password, confirmPassword, role, origin);


            User response = await ApiService.CreateUser(user);


            if (response != null)
            {
                await DisplayAlert("Succ�s", "Votre compte a �t� cr�� avec succ�s.", "OK");
                await Navigation.PushAsync(new ArticlePage());
            }
            else
            {
                await DisplayAlert("Erreur", "La cr�ation du compte a �chou�. Veuillez r�essayer plus tard.", "OK");
            }
        }
        catch (Exception ex)
        {

            await DisplayAlert("Erreur", "Une erreur est survenue lors de l'inscription : " + ex.Message, "OK");
            Debug.WriteLine("Erreur lors de la cr�ation de l'utilisateur : " + ex.Message);
        }
    }
}