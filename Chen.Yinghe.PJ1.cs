using System;

using Xamarin.Forms;

/* Yinghe Chen
 * COEN 268 44034 
 * First Assignment: Simple Palette
 * Due: OCT 6TH 2016
 * Contact@yinghechen1993@gmail.com
 */



using System;
using Xamarin.Forms;

namespace Chen.Yinghe.PJ1
{
	public class App : Application
	{
		//ORENTIATION
		//Declare private global integer R, G, B to track current R, G, B value
		private int R, G, B;
		//Declare private global buttons and labels
		private Button buttonPlus1, buttonPlus2, buttonPlus3,
		buttonMinus1, buttonMinus2, buttonMinus3;
		private Label label1, label2, label3, label4, label5, label6;
		//Declara current color as a object of color
		Color currentColor;


		public App()
		{
			//Assign R, G, B to 125 in first time.
			R = 125;
			G = 125;
			B = 125;

			if (Properties.ContainsKey("R") &&
				Properties.ContainsKey("G") &&
				Properties.ContainsKey("B"))

			{
				R = (int)Properties["R"];
				G = (int)Properties["G"];
				B = (int)Properties["B"];
			}
			currentColor = Color.FromRgb(R, G, B);
			label1 = new Label
			{
				Text = "R: " + R,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			label2 = new Label
			{
				Text = "G: " + G,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			label3 = new Label
			{
				Text = "B: " + B,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			label4 = new Label
			{
				//changeable in stacklayout?
				//Button button = new Button{Text = "+"},
				Text = "Current Color",
				TextColor = Color.FromRgb(R, G, B)
			};
			label5 = new Label { };
			label6 = new Label { };
			changeLabel5();
			changeLabel6();
			buttonPlus1 = new Button()
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonPlus2 = new Button()
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonPlus3 = new Button()
			{
				Text = "+",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonMinus1 = new Button()
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonMinus2 = new Button()
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonMinus3 = new Button()
			{
				Text = "-",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button))
			};
			buttonPlus1.Clicked += OnButtonClicked;
			buttonPlus2.Clicked += OnButtonClicked;
			buttonPlus3.Clicked += OnButtonClicked;
			buttonMinus1.Clicked += OnButtonClicked;
			buttonMinus2.Clicked += OnButtonClicked;
			buttonMinus3.Clicked += OnButtonClicked;

			StackLayout buttonLine1 = new StackLayout
			{
				Children = {
					buttonMinus1,
					buttonPlus1
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			StackLayout buttonline2 = new StackLayout
			{
				Children = {
					buttonMinus2,
					buttonPlus2
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			StackLayout buttonline3 = new StackLayout
			{
				Children = {
					buttonMinus3,
					buttonPlus3
				},
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			StackLayout resultTable = new StackLayout
			{
				Children = {
					label4,
					label5,
					label6
				},
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			StackLayout stackLayout = new StackLayout
			{
#if __IOS__
				Padding = new Thickness(0, 20, 0, 0);
#endif
				Children = {

						label1,
						buttonLine1,
						label2,
						buttonline2,
						label3,
						buttonline3,
						resultTable
					}
			};

			var content = new ContentPage
			{
				Content = new ScrollView
				{
					Content = stackLayout
				},
				Title = "Homework #1"
			};

			MainPage = new NavigationPage(content);
		}

		//Change the label5(R, G, B composition) based on current color
		void changeLabel5()
		{
			label5.Text = Environment.NewLine + "R = " + currentColor.R.ToString() +
				Environment.NewLine + "G = " + currentColor.G.ToString() +
				Environment.NewLine + "B = " + currentColor.B.ToString();
		}

		//Change the label6(HSL) based on current color
		void changeLabel6()
		{
			label6.Text = Environment.NewLine + "H = " + currentColor.Hue.ToString() +
				Environment.NewLine + "S = " + currentColor.Saturation.ToString() +
				Environment.NewLine + "L = " + currentColor.Luminosity.ToString();
		}

		//The only event handler takes sender and args as input to change the
		//according value of R, G, B based on specific button.
		void OnButtonClicked(object sender, EventArgs args)
		{
			Button button = (Button)sender;
			if (button == buttonPlus1 && R < 256) { R++; label1.Text = "R: " + R; }
			if (button == buttonPlus2 && G < 256) { G++; label2.Text = "G: " + G; }
			if (button == buttonPlus3 && B < 256) { B++; label3.Text = "B: " + B; }
			if (button == buttonMinus1 && R > 0) { R--; label1.Text = "R: " + R; }
			if (button == buttonMinus2 && G > 0) { G--; label2.Text = "G: " + G; }
			if (button == buttonMinus3 && B > 0) { B--; label3.Text = "B: " + B; }
			if (R == 255) { buttonPlus1.IsEnabled = false; }
			if (R == 0) { buttonMinus1.IsEnabled = false; }
			if (G == 255) { buttonPlus2.IsEnabled = false; }
			if (G == 0) { buttonMinus2.IsEnabled = false; }
			if (B == 255) { buttonPlus3.IsEnabled = false; }
			if (B == 0) { buttonMinus3.IsEnabled = false; }
			currentColor = Color.FromRgb(R, G, B);
			label4.TextColor = currentColor;
			changeLabel5();
			changeLabel6();
			//Store R, G, B
			//App app = Application.Current as App;
			if (!Properties.ContainsKey("R") &&
			   	!Properties.ContainsKey("G") &&
				!Properties.ContainsKey("B"))
			{
				Properties.Add("R", R);
				Properties.Add("G", G);
				Properties.Add("B", B);
			}
			else
			{
				Properties["R"] = R;
				Properties["G"] = G;
				Properties["B"] = B;
			}

			//app.R = R;
			//app.G = G;
			//app.B = B;
			//label5.
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
