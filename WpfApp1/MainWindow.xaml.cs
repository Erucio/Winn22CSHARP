using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using Win22_CSharp.Models;
using Win22_CSharp.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        private readonly FileService file = new();
        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            ContactJsonGet();
            
        }
        private void ContactJsonGet()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());
                if (items != null)
                {
                    contacts = items;
                }
            }
            catch { }
            lv_Contacts.ItemsSource = contacts;
        }
       

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Address = tb_Address.Text
            });
            file.Save(JsonConvert.SerializeObject(contacts));
            ClearForm();
        }
        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Address.Text = "";
        }
    }
}
