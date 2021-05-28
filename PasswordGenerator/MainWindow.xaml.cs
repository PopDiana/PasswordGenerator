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

namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            password.Text = "Your password will be shown here...";          
        }

        private string GetPossibleCharacters()
        {
            string possibleCharacters = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string digits = "0123456789";
            string symbols = "@#$%";
            string ambiguous = "{}[]()\\/'\"`~,;:.<>";
            if (includeSymbols.IsChecked.Value == true)
                possibleCharacters = possibleCharacters + symbols;
            if(excludeSimilar.IsChecked.Value == true)
            {
                alphabet = "abcdefghjkmnpqrstuvwxyz";
                digits = "23456789";
            }
            if (includeDigits.IsChecked.Value == true)
                possibleCharacters = possibleCharacters + digits;
            if (includeLowercase.IsChecked.Value == true)
                possibleCharacters = possibleCharacters + alphabet;
            if (includeUppercase.IsChecked.Value == true)
                possibleCharacters = possibleCharacters + alphabet.ToUpper();
            if (excludeAmbiguous.IsChecked.Value == false)
                possibleCharacters = possibleCharacters + ambiguous;
            return possibleCharacters;
        }

        private void GeneratePassword(object sender, RoutedEventArgs e)
        {
            string possibleCharacters = this.GetPossibleCharacters();
            string generatedPassword = "";
            var iterator = 0;
            Random random = new Random();
            while(iterator < Convert.ToInt32(length.Text))
            {
                generatedPassword = generatedPassword + possibleCharacters[random.Next(0, possibleCharacters.Length - 1)];
                iterator++;
            }       
            password.Text = generatedPassword;

        }
    }
}
