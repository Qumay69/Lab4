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

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private List<Note<string>> notes = new List<Note<string>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (notes.Count >= 8)
            {
                MessageBox.Show("Можно добавить только 8 записей.");
                return;
            }

            string lastName = LastNameTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            if (!int.TryParse(DayTextBox.Text, out int day) || !int.TryParse(MonthTextBox.Text, out int month) || !int.TryParse(YearTextBox.Text, out int year))
            {
                MessageBox.Show("Некорректная дата рождения.");
                return;
            }

            var note = new Note<string>(lastName, firstName, phoneNumber, new[] { day, month, year });
            notes.Add(note);

            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            PhoneNumberTextBox.Clear();
            DayTextBox.Clear();
            MonthTextBox.Clear();
            YearTextBox.Clear();

            UpdateNotesListBox();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = SearchLastNameTextBox.Text;
            var result = notes.FirstOrDefault(n => n.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (result != null)
            {
                MessageBox.Show(result.ToString());
            }
            else
            {
                MessageBox.Show("Абонент не найден.");
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            notes.Sort();
            UpdateNotesListBox();
        }

        private void UpdateNotesListBox()
        {
            NotesListBox.Items.Clear();
            foreach (var note in notes)
            {
                NotesListBox.Items.Add(note.ToString());
            }
        }
    }
}
