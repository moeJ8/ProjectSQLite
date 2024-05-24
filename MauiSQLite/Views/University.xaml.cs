using MauiSQLite.Models;
using MauiSQLite.DataTransactions;

namespace MauiSQLite;

public partial class University : ContentPage
{
    private List<UniversityClass> selectedUniversities = new List<UniversityClass>();
    string major;
    public University()
	{
		InitializeComponent();
	}

    private void Button_AddUni_Clicked(object sender, EventArgs e)
    {
        App.DBTrans.AddUniversity(new UniversityClass
        {
            Name = Uni_Name.Text,
            Location = Uni_Location.Text,
            Major = major
        });
        /*Uni_Name.Text = string.Empty;
        Uni_Location.Text = string.Empty;
        MajorPicker.Title = string.Empty;*/
        major = MajorPicker.SelectedItem as string;
        Uni_List_View.ItemsSource = App.DBTrans.GetAllUniversities();
    }
    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.DBTrans.DeleteUniversity((int)button.BindingContext);
        Uni_List_View.ItemsSource = App.DBTrans.GetAllUniversities();
    }
    private async void GoToUniversityPage_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//Informations");
    }
    private async void Previous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
   
}