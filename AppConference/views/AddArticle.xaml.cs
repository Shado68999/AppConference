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
            // Récupérer les valeurs des Entry
            string titre = TitleEntry.Text;
            string description = DescriptionEntry.Text;
            string fichier = FileEntry.Text;

            // Créer un nouvel objet Article avec les valeurs récupérées
            var nouvelArticle = new Article(titre, description, fichier);

            // Appeler la méthode de création d'article de votre ApiService
            var articleCree = await ApiService.CreateArticle(nouvelArticle);

            if (articleCree != null)
            {
                // Article créé avec succès, effectuez les actions nécessaires (par exemple, afficher un message de réussite)
                await DisplayAlert("Succès", "L'article a été créé avec succès.", "OK");
                await Navigation.PushAsync(new ArticlePage());
            }
            else
            {
                // Une erreur s'est produite lors de la création de l'article, effectuez les actions nécessaires (par exemple, afficher un message d'erreur)
                await DisplayAlert("Erreur", "Une erreur s'est produite lors de la création de l'article.", "OK");
            }
        }
        catch (Exception ex)
        {
            // Gérer l'exception ici (par exemple, afficher un message d'erreur générique ou enregistrer l'exception dans les journaux)
            await DisplayAlert("Erreur", "Une erreur s'est produite lors de la création de l'article." + ex.Message, "OK");
            Debug.WriteLine("Erreur lors de la création de l'article : " + ex.Message);
        }
    }
}