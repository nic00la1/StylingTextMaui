namespace StylingTextMaui
{
    public partial class MainPage : ContentPage
    {
        string[] quotes = new string[5] { "Cytat 1", "Cytat 2", "Cytat 3", "Cytat 4", "Cytat 5" };
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            slider.ValueChanged += Slider_ValueChanged;
            button.Clicked += button_Clicked;
        }

        void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            sizeLabel.Text = "Rozmiar: " + e.NewValue;
        }

        void button_Clicked(object? sender, EventArgs e)
        {
            int index = random.Next(quotes.Length);
            quoteLabel.Text = quotes[index];
            quoteLabel.FontSize = slider.Value;
            if (picker.SelectedItem != null)
            {
                quoteLabel.HorizontalOptions = (LayoutOptions)Enum.Parse(typeof(LayoutOptions), picker.SelectedItem.ToString());
            }
            quoteLabel.FontAttributes = (boldSwitch.IsToggled ? FontAttributes.Bold : FontAttributes.None) | (italicSwitch.IsToggled ? FontAttributes.Italic : FontAttributes.None);
        }
    }

}
