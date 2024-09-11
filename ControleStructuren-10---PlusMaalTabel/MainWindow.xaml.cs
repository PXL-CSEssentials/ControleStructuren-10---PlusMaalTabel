using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ControleStructuren_10___PlusMaalTabel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _clock = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            errorMessageLabel.Visibility = Visibility.Hidden;

            // Timer laten aflopen om de 1 seconde.     
            _clock.Interval = new TimeSpan(0, 0, 1); // hoe snel tikt de klok
            _clock.Tick += new EventHandler(Clock_Tick); // wat doen na tik van de klok
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            // Als foutmelding zichtbaar is: maak hidden en anders zichtbaar maken
            errorMessageLabel.Visibility = errorMessageLabel.IsVisible ? Visibility.Hidden : Visibility.Visible;

            /*
            if (errorMessageLabel.IsVisible)
            {
                errorMessageLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                errorMessageLabel.Visibility = Visibility.Visible;
            }
            */
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int maxValue;
            bool isGeldigGetal = int.TryParse(maxValueTextBox.Text, out maxValue);
            if (!isGeldigGetal || maxValue > 20 || maxValue < 1)
            {
                // Foute invoer: 
                // Alles leegmaken
                resultTextBox.Clear();
                maxValueTextBox.Clear();
                maxValueTextBox.Focus();

                // Foute invoer: 
                // Timer inschakelen (om label te kunnen laten flikkeren)
                _clock.IsEnabled = true;

                return;
            }

            // Goede invoer: Timer uitschakelen en label verbergen.
            _clock.IsEnabled = false;
            errorMessageLabel.Visibility = Visibility.Hidden;

            StringBuilder result = new StringBuilder();
            // Rijhoofding
            result.Append("\t");
            for (int i = 1; i <= maxValue; i++)
            {
                result.Append($"{i}\t");
            }
            result.AppendLine().AppendLine(); // 2 regels open laten

            // Loop over de rijen
            for (int i = 1; i <= maxValue; i++)
            {
                result.Append($"{i}\t");
                // Loop over de kolommen
                for (int j = 1; j <= maxValue; j++)
                {
                    result.Append($"{i + j}\t");
                }
                result.AppendLine(); // nieuwe rij starten
            }

            resultTextBox.Text = result.ToString();
        }

        private void multiplyButton_Click(object sender, RoutedEventArgs e)
        {
            // Exact hetzelfde als Optellen, alleen * gebruiken:
            //resultaat.Append($"{i * j}\t");

            // Hierin zit dus heel veel gecopy-paste code...
            // We zouden een manier willen vinden om dit te vermijden
            // Zie syllabus hoofdstuk 7 in een latere les
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
            maxValueTextBox.Text = "10";
            maxValueTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
