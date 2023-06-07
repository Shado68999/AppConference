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
            // R�cup�rer les valeurs des Entry
            string name = nomEntry.Text;
            string sigle = sigleEntry.Text;
            string theme = themeEntry.Text;
            DateTime dateDeroulement = DateTime.Now;
            DateTime dateInscription = DateTime.Now;
            DateTime dateResultat = DateTime.Now;
            DateTime dateSoumission = DateTime.Now;

            // Cr�er un nouvel objet conf�rence avec les valeurs r�cup�r�es
            var newConference = new Conference(name, sigle, theme, dateSoumission, dateResultat, dateInscription, dateDeroulement);

            // Appeler la m�thode de cr�ation de la conf�rence de votre ApiService
            var conference = await ApiService.CreateConference(newConference);

            if (conference != null)
            {
                // Article cr�� avec succ�s, effectuez les actions n�cessaires (par exemple, afficher un message de r�ussite)
                await DisplayAlert("Succ�s", "La conf�rence a �t� cr�� avec succ�s.", "OK");
                await Navigation.PushAsync(new ConferencePage());
            }
            else
            {
                // Une erreur s'est produite lors de la cr�ation de la conf�rence, effectuez les actions n�cessaires (par exemple, afficher un message d'erreur)
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de la cr�ation de la conf�rence.", "OK");
            }
        }
        catch (Exception ex)
        {
            // G�rer l'exception ici (par exemple, afficher un message d'erreur g�n�rique ou enregistrer l'exception dans les journaux)
            await DisplayAlert("Erreur", "Une erreur s'est produite lors de la cr�ation de la conf�rence.", "OK");
            Debug.WriteLine("Erreur lors de la cr�ation de la conf�rence : " + ex.Message);
        }
    }
}