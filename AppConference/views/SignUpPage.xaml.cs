using AppConference.models;
using AppConference.Services;

namespace AppConference.views;

public partial class SignUpPage : ContentPage
{
    private ApiService apiService;

    public SignUpPage()
	{
        InitializeComponent();
        apiService = new ApiService();
    }

    private async void OnLogInClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnHomeClicked(object sender, EventArgs e)
    {
        
        string fullName = fullNameEntry.Text;
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


            var users = new User(fullName, email, password, confirmPassword, role, origin);


            var response = await apiService.Post("/User/create", users);


            if (response != null)
            {
                await DisplayAlert("Succès", "Votre compte a été créé avec succès.", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Erreur", "La création du compte a échoué. Veuillez réessayer plus tard.", "OK");
            }
        }
        catch (Exception ex)
        {
            
            await DisplayAlert("Erreur", "Une erreur est survenue lors de l'inscription : " + ex.Message, "OK");
        }

        
    }
}