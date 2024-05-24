using MauiSQLite.Models;
using MauiSQLite.DataTransactions;

namespace MauiSQLite;

public partial class Payment : ContentPage
{
    public double TotalPrice
    {
        set
        {
            TotalAmountLabel.Text = $"Total amount to be paid is {value:C}";
        }
    }
    public Payment()
    {
        InitializeComponent();

    }
    private async void Button_AddPay_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(cardName.Text) ||
        string.IsNullOrWhiteSpace(cardNumber.Text) ||
        string.IsNullOrWhiteSpace(expMonth.Text) ||
        string.IsNullOrWhiteSpace(expYear.Text) ||
        string.IsNullOrWhiteSpace(cvv.Text))
        {

            await DisplayAlert("Error", "Please fill in all fields", "OK");
            return;
        }
        App.DBTrans.AddPayment(new PaymentInfo
        {
            CardHolderName = cardName.Text,
            CardNumber = cardNumber.Text,
            ExpiryMonth = expMonth.Text,
            ExpiryYear = expYear.Text,
            CVV = cvv.Text
        });
        //Pay_List_View.ItemsSource = App.DBTrans.GetAllPayments();

        cardName.Text = string.Empty;
        cardNumber.Text = string.Empty;
        expMonth.Text = string.Empty;
        expYear.Text = string.Empty;
        cvv.Text = string.Empty;


        await DisplayAlert("Payment Successful", "The payment was completed successfully", "OK");

    }


    private void Del_Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        App.DBTrans.DeletePayment((int)button.BindingContext);
        //Pay_List_View.ItemsSource = App.DBTrans.GetAllPayments();
    }
    private async void Previous_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Informations");
    }
}