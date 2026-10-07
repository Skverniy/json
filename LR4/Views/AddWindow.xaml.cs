using System;
using System.Windows;
using LR4.Classes;

namespace LR4.Views
{
    public partial class AddWindow : Window
    {
        FileService fileService = new FileService();
        string resultRecord = "";
        User? newUser;

        public AddWindow()
        {
            InitializeComponent();
            newUser = new User();
            picture.DataContext = newUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = dpBirthday.SelectedDate;
            if (selectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения!");
                return;
            }

            newUser.FirstName = tbFirstName.Text;
            newUser.LastName = tblastName.Text;
            newUser.Birthday = selectedDate.Value.Date;
            newUser.Gender = cmbGender.Text;

            resultRecord = fileService.FileUserWriter(newUser);
            MessageBox.Show(resultRecord);
        }

        private void btnPicImage_Click(object sender, RoutedEventArgs e)
        {
            newUser.ImageWithPath = fileService.getNewImage();
        }
    }
}