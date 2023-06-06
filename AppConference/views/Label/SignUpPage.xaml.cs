using AppConference.models;
using AppConference.Services;

namespace AppConference.views.Label;

public partial class SignUpPage : ContentPage
{

    public SignUpPage()
	{
        InitializeComponent();
    }

    private async void OnLogInClicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new LoginPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        
        string name = fullNameEntry.Text;
        string email = emailEntry.Text;
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;
        string role = roleEntry.Text;
        string origin = originEntry.Text;

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
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Erreur", "La cr�ation du compte a �chou�. Veuillez r�essayer plus tard.", "OK");
            }
        }
        catch (Exception ex)
        {
            
            await DisplayAlert("Erreur", "Une erreur est survenue lors de l'inscription : " + ex.Message, "OK");
        }

        
    }
}