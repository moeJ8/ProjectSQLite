using MauiSQLite.Models;
using System.Collections.ObjectModel;
namespace MauiSQLite;

public partial class Informations : ContentPage
{
    int stuID;
    int uniID;
    string stuName, uniName, major, stuLastName;
    public double totalPrice = 0.0;

    public Informations()
	{
		InitializeComponent();

        setUp();
    }
    public void setUp()
    {
        Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
        Uni_List_View.ItemsSource = App.DBTrans.GetAllUniversities();
        info_List_View.ItemsSource = App.DBTrans.GetAllApplications();
    }
   
   

  

    private void show_Clicked(object sender, EventArgs e)
    {
        var uni = App.DBTrans.GetUniversityById(uniID);
        totalPrice += (double)uni.Price;
        App.DBTrans.AddApplication(new Models.Applications
        {

            StudentID = stuID,
            UniversityID = uniID,
            StudentName = stuName,
            StudentLastName = stuLastName,
            UniversityName = uniName,
            Major = major

        });
        info_List_View.ItemsSource = App.DBTrans.GetAllApplications();
    }
    private void Uni_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var uni = e.Item as UniversityClass;
        uniID = uni.ID;
        uniName = uni.Name;
        major = uni.Major;
    }
    private void Stu_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var student = e.Item as StudentClass;
        stuID = student.ID;
        stuName = student.Name;
        stuLastName = student.LastName;
    }

    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.DBTrans.DeleteApplication((int)button.BindingContext);
        info_List_View.ItemsSource = App.DBTrans.GetAllApplications();
    }
   private double CalculateTotalPrice()
    {
        double total = 0.0;

        // Iterate through the items in info_List_View to calculate the total price
        foreach (var item in info_List_View.ItemsSource)
        {
            if (item is Models.Applications application)
            {
                var uni = App.DBTrans.GetUniversityById(application.UniversityID);
                total += (double)uni.Price;
            }
        }

        return total;
    }


    private async void continue_Clicked(object sender, EventArgs e)
    {

        totalPrice = CalculateTotalPrice();
        await Shell.Current.GoToAsync($"//Payment?totalPrice={totalPrice}");
    }
    private async void Previous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//University");
    }
}