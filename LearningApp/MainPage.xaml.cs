
namespace LearningApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	string translatedNumber;

	public MainPage()
	{
		InitializeComponent();
	}


    void TranslateButton_Clicked(System.Object sender, System.EventArgs e)
    {
		var enteredNum = PhoneNumberText.Text;
		translatedNumber = PhonewordTranslator.ToNumber(enteredNum);

		if(!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Call " + translatedNumber;
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";
		}
    }

    async void CallButton_Clicked(System.Object sender, System.EventArgs e)
    {
		if(await DisplayAlert("Dial a Number", "Would you like to call " + translatedNumber + "?",
			"Yes",
			"No"))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported)
					PhoneDialer.Default.Open(translatedNumber);
			}
			catch(ArgumentNullException)
			{
				await DisplayAlert("Unable to dial", "Phone number was not valid", "Ok");
			}
			catch(Exception ex)
			{
				await DisplayAlert("Unable to dial", "Phone Dialing failed", "Ok");
			}
		}
    }
}


