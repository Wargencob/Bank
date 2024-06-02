using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;


namespace Банкомат
{
    
public partial class MainWindow : Window
    {
        Person? person;
        private readonly MyDbContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new MyDbContext();
            person = new Person();
        }
        
        private void PinBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            Balance.IsEnabled = true;
            Summ.IsEnabled = true;
            Insert.IsEnabled = true;
            Take_off.IsEnabled = true;

            string enteredCardNumber = CardNumber.Text;
            string enteredPinCode = PinCode.Text;

            person = _context.Persons.FirstOrDefault(c => c.CardNumber == enteredCardNumber);
            if(enteredCardNumber == "")
            {
                MessageBox.Show("Введите номер карты!");
            }
            else if (person == null)
            {
                MessageBox.Show("Такого счёта не существует!");
            }
            else if (enteredPinCode == "")
            {
                MessageBox.Show("Введите пин код!");
            }
            else if (person != null && person.PinCode != enteredPinCode)
            {
                MessageBox.Show("Неверный пин код!");
            }
            else if (person != null && person.PinCode == enteredPinCode) 
            {
                Balance.Text = $"{person.Money}";
            }
        }

        private void insert_click(object sender, RoutedEventArgs e)
        {
            person.Money += Convert.ToInt32(Summ.Text);
            _context.SaveChangesAsync();
        }

        private void take_off_click(object sender, RoutedEventArgs e)
        {
            person.Money -= Convert.ToInt32(Summ.Text);
            _context.SaveChangesAsync();
        }
    }

}