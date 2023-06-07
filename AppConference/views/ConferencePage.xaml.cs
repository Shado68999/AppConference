using System.Windows.Input;

namespace AppConference.views
{
    public partial class ConferencePage : ContentPage
    {
        public ICommand AddCommand { get; private set; }

        public ConferencePage()
        {
            InitializeComponent();
            //AddCommand = new Command(ExecuteAddCommand);
        }

        private void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            // Code de gestion du défilement de la ScrollView
        }

        private async void DelaitedClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailedPage());
        }

        private async void ExecuteAddConference(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddConference());
        }
    }
}
