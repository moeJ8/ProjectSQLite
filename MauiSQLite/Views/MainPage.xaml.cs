﻿using System.Reflection;

namespace MauiSQLite
{
    public partial class MainPage : ContentPage
    {
        string gender;
        string age;

        public MainPage()
        {
            InitializeComponent();
            Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
        }

        private void Button_Add_Clicked(object sender, EventArgs e)
        {
            App.DBTrans.Add(new Models.StudentClass
            {
                Name = Stu_Name.Text,
                LastName = Stu_LastName.Text,
                Department = Stu_Dept.Text,
                Gender = gender,
                Age = age,
                Email = Stu_Email.Text,
                PhoneNumber = Stu_Phone.Text
            });

            if (male.IsChecked)
                gender = "male";
            else if (female.IsChecked)
                gender = "female";
            else if (other.IsChecked)
                gender = "other";

            age = AgePicker.SelectedItem as string;
            Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
        }

        private void Del_Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            App.DBTrans.DeleteStudent((int)button.BindingContext);
            Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
        }

        private async void GoToUniversityPage_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//University");
        }


    }

}
