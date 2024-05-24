using MauiSQLite.Models;
using MauiSQLite.DataTransactions;

namespace MauiSQLite;

public partial class University : ContentPage
{
    private List<UniversityClass> selectedUniversities = new List<UniversityClass>();
    string major;
    private Dictionary<string, decimal> universityPrices = new Dictionary<string, decimal>
    {
        { "Birzeit University", 300m },
        { "Istanbul University", 400m },
        { "Istanbul TECHNICAL University", 450m },
        { "Ankara University", 350m },
        { "Boazici University", 1500m },
        { "Antalya BILIM University", 500m },
        { "Uskudar University", 500m },
        { "Koç University", 2000m },
        { "Bahçesehir University", 1200m },
        { "Harvard University", 3000m },
        { "Stanford University", 1900m },
        { "Johns Hopkins University", 1200m },
        { "Florida International University", 900m },
        { "Massachusetts Institute of Technology (MIT)", 900m },
        { "Freie Universität Berlin", 2000m },
        { "University of Bonn", 2000m },
        { "University of Göttingen", 1600m },
        { "Humboldt University of Berlin", 1800m },
        { "Technical University of Munich", 1500m },
        { "Universidad Complutense de Madrid", 2400m },
        { "University De Mahajanga", 55m }
    };
    public University()
	{
		InitializeComponent();
	}

    private void Button_AddUni_Clicked(object sender, EventArgs e)
    {
        var selectedUniversity = UniPicker.SelectedItem as string;
        if (selectedUniversity == null)
        {
            
            DisplayAlert("Error", "Please select a university", "OK");
            return;
        }

        
        decimal price = 0;
        if (universityPrices.TryGetValue(selectedUniversity, out price))
        {
            App.DBTrans.AddUniversity(new UniversityClass
            {
                Name = UniPicker.SelectedItem as string,
                Location = Uni_Location.Text,
                Major = MajorPicker.SelectedItem as string,
                Price = price
            });

            
            Uni_List_View.ItemsSource = App.DBTrans.GetAllUniversities();
        }
        else
        {
            DisplayAlert("Error", "University not found", "OK");
        }

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

    private void UniPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}