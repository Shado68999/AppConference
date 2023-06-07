using AppConference.models;
using AppConference.Services;
using System.Diagnostics;

namespace AppConference.views;

public partial class AddArticle : ContentPage
{
	public AddArticle()
	{
		InitializeComponent();
	}

    private async void OnFilePickerButtonClicked(object sender, EventArgs e)
    {
        FileResult fileResult = await FilePicker.PickAsync();

        if (fileResult != null)
        {
            string filePath = fileResult.FullPath;
        }
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            // R�cup�rer les valeurs des Entry
            string titre = TitleEntry.Text;
            string description = DescriptionEntry.Text;
            string fichier = FileEntry.Text;

            // Cr�er un nouvel objet Article avec les valeurs r�cup�r�es
            var nouvelArticle = new Article(titre, description, fichier);

            // Appeler la m�thode de cr�ation d'article de votre ApiService
            var articleCree = await ApiService.CreateArticle(nouvelArticle);

            if (articleCree != null)
            {
                // Article cr�� avec succ�s, effectuez les actions n�cessaires (par exemple, afficher un message de r�ussite)
                await DisplayAlert("Succ�s", "L'article a �t� cr�� avec succ�s.", "OK");
                await Navigation.PushAsync(new ArticlePage());
            }
            else
            {
                // Une erreur s'est produite lors de la cr�ation de l'article, effectuez les actions n�cessaires (par exemple, afficher un message d'erreur)
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de la cr�ation de l'article.", "OK");
            }
        }
        catch (Exception ex)
        {
            // G�rer l'exception ici (par exemple, afficher un message d'erreur g�n�rique ou enregistrer l'exception dans les journaux)
            await DisplayAlert("Erreur", "Une erreur s'est produite lors de la cr�ation de l'article." + ex.Message, "OK");
            Debug.WriteLine("Erreur lors de la cr�ation de l'article : " + ex.Message);
        }
    }
}