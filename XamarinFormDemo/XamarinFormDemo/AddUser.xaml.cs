using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormDemo.DLL;

namespace XamarinFormDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddUser : ContentPage
	{
        private DatabaseConnection databaseConnection = new DatabaseConnection();

        private int[] ages = new int[100];

		public AddUser ()
		{
			InitializeComponent ();

            for (int i = 0; i < 100; i++)
            {
                ages[i] = i + 1;
            }

            agePicker.ItemsSource = ages;
        }

        private void AddUserButton_Clicked(object sender, EventArgs e)
        {
            if (databaseConnection.InsertUser(
                new Model.User()
                {
                    Name = nameEntry.Text,
                    Email = emailEntry.Text,
                    Age = (int)agePicker.SelectedItem
                })) GetAgeCategory();
            else GetWarningPop();
        }

        private async void GetAgeCategory()
        {
            int selectedValue = (int)agePicker.SelectedItem;

            await DisplayAlert("Age category", (selectedValue > 0 &&
                selectedValue < 17) ? "I'm kid." : "I'm adult.", "OK");
        }

        private async void GetWarningPop()
        {
            await DisplayAlert("Warning", 
                "Something went wrong, please check back later.", "OK");
        }
    }
}