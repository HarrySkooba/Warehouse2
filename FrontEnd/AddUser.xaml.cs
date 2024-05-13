using Backend.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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
using System.ComponentModel;
using System.Xml.Linq;

namespace FrontEnd
{
    public partial class AddUser : Page, INotifyPropertyChanged
    {
        public AddUser()
        {
            InitializeComponent();
        }
        void Signal(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public event PropertyChangedEventHandler PropertyChanged;

        public class RoleModel
        {
            public int Idrole { get; set; }
            public string RoleName { get; set; }
        }
   

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadRolesAsync();
        }

        private async Task AddUserFromInputAsync()
        {
     
        }

        private async Task AddUserAsync(UserModel newUser)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7107/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string newUserJson = JsonConvert.SerializeObject(newUser);
                HttpContent content = new StringContent(newUserJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/User/adduser", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Новый пользователь успешно добавлен.");
                }
                else
                {
                    MessageBox.Show("Не удалось добавить нового пользователя.");
                }
            }
        }

        private async Task LoadRolesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7107/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Role/roles");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    List<RoleModel> roles = JsonConvert.DeserializeObject<List<RoleModel>>(responseContent);

                    cbUserRole.DisplayMemberPath = "RoleName";
                    cbUserRole.ItemsSource = null;
                    cbUserRole.Items.Clear();
                    cbUserRole.ItemsSource = roles;
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить список пользователей.");
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.GoBack();
        }
    }
}
