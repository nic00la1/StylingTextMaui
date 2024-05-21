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

            // Shadow options
            radiusEntry.TextChanged += RadiusEntry_TextChanged;
            colorEntry.TextChanged += ColorEntry_TextChanged;

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

            RadiusEntry_TextChanged(null, new TextChangedEventArgs(quoteLabel.Text, radiusEntry.Text));
            ColorEntry_TextChanged(null, new TextChangedEventArgs(quoteLabel.Text, colorEntry.Text));
        }

        private void RadiusEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Jeśli wprowadzona wartość jest liczbą, to ustawiamy cień
            if (double.TryParse(e.NewTextValue, out double radius))
            {
                quoteLabel.Shadow = new Shadow() 
                {
                    Radius = (float)radius, Brush = new SolidColorBrush(Color.FromHex("#558B2F")) 
                };
            }
            else
            {
                Console.WriteLine("Nie ma takiej wartosci cienia!");
            }
        }
        private void ColorEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Color.TryParse(e.NewTextValue, out Color color))
            {
                quoteLabel.Shadow = new Shadow()
                {
                    Radius = 10, Brush = new SolidColorBrush(color) 
                };
            }
            else
            {
                Console.WriteLine("Nie ma takiego koloru!");
            }
        }
    }

}
