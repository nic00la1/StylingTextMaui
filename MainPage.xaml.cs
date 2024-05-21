namespace StylingTextMaui
{
    public partial class MainPage : ContentPage
    {
        string[] quotes = new string[5] { "Dzień Dobry!", "Buenos días!", "Bonjour!", "Good morning!", "Guten Tag!" };
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            slider.ValueChanged += Slider_ValueChanged;
            button.Clicked += button_Clicked;
        }

        void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            double roundedValue = Math.Round(e.NewValue);
            sizeLabel.Text = "Rozmiar: " + roundedValue;
        }

        void button_Clicked(object? sender, EventArgs e)
        {
            int index = random.Next(quotes.Length);
            quoteLabel.Text = quotes[index];
            quoteLabel.FontSize = Math.Round(slider.Value);
            if (picker.SelectedItem != null)
            {
                string selectedItem = picker.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "End":
                        quoteLabel.HorizontalOptions = LayoutOptions.End;
                        break;
                    case "Center":
                        quoteLabel.HorizontalOptions = LayoutOptions.Center;
                        break;
                    case "Start":
                        quoteLabel.HorizontalOptions = LayoutOptions.Start;
                        break;
                    default:
                        throw new ArgumentException($"Nieznana opcja: {selectedItem}");
                }
            }
            quoteLabel.FontAttributes = 
                  (boldSwitch.IsToggled ? FontAttributes.Bold : FontAttributes.None)
                | (italicSwitch.IsToggled ? FontAttributes.Italic : FontAttributes.None);

            quoteLabel.TextDecorations = 
                (underlineSwitch.IsToggled ? TextDecorations.Underline : TextDecorations.None);
        }
    }

}
