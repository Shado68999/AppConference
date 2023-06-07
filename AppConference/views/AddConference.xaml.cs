using AppConference.models;
using AppConference.Services;
using System.Diagnostics;

namespace AppConference.views;

public partial class AddConference : ContentPage
{
	public AddConference()
	{
		InitializeComponent();
	}

    private async void SaveConferenceClicked(object sender, EventArgs e)
    {
        try
        {
            // Récupérer les valeurs des Entry
            string name = nomEntry.Text;
            string sigle = sigleEntry.Text;
            string theme = themeEntry.Text;
            DateTime dateDeroulement = DateTime.Now;
            DateTime dateInscription = DateTime.Now;
            DateTime dateResultat = DateTime.Now;
            DateTime dateSoumission = DateTime.Now;

            // Créer un nouvel objet conférence avec les valeurs récupérées
            var newConference = new Conference(name, sigle, theme, dateSoumission, dateResultat, dateInscription, dateDeroulement);

            // Appeler la méthode de création de la conférence de votre ApiService
            var conference = await ApiService.CreateConference(newConference);

            if (conference != null)
            {
                // Article créé avec succès, effectuez les actions nécessaires (par exemple, afficher un message de réussite)
                await DisplayAlert("Succès", "La conférence a été créé avec succès.", "OK");
                await Navigation.PushAsync(new ConferencePage());
            }
            else
            {
                // Une erreur s'est produite lors de la création de la conférence, effectuez les actions nécessaires (par exemple, afficher un message d'erreur)
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de la création de la conférence.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Gérer l'exception ici (par exemple, afficher un message d'erreur générique ou enregistrer l'exception dans les journaux)
            await DisplayAlert("Erreur", "Une erreur s'est produite lors de la création de la conférence.", "OK");
            Debug.WriteLine("Erreur lors de la création de la conférence : " + ex.Message);
        }
    }
}