using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormDemo.DLL;
using XamarinFormDemo.Model;

namespace XamarinFormDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListUsers : ContentPage
	{
        private List<User> users = new List<User>();

        private DatabaseConnection databaseConnection = new DatabaseConnection();

		public ListUsers ()
		{
			InitializeComponent ();

            users = databaseConnection.GetUsers();

            usersListView.ItemsSource = users;
        }

        private void refreshUserListButton_Clicked(object sender, System.EventArgs e)
        {
            users = databaseConnection.GetUsers();

            usersListView.ItemsSource = null;
            usersListView.ItemsSource = users;
        }
    }
}