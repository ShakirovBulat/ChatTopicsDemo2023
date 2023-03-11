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
using System.Windows.Shapes;
using ChatTopicsDemo2023.db;

namespace ChatTopicsDemo2023.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChitChatTopicsWindow.xaml
    /// </summary>
    public partial class ChitChatTopicsWindow : Window
    {
        public ChatDBEntities dbEntities = new ChatDBEntities();
        Chatroom chatroom;
        public ChitChatTopicsWindow()
        {
            InitializeComponent();
            NameTB.Text = LoginWindow.employee.Name;
            var chatRoom = ((Employee)LoginWindow.employee).Id;
            TopicLV.ItemsSource = dbEntities.ChatMessage.Where(x => x.Id == chatRoom).ToList();
        }

        private void EmplFinderBtn_Click(object sender, RoutedEventArgs e)
        {
            ChitChatWindow chitChat = new ChitChatWindow();
            chitChat.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TopicLst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var top = TopicLV.SelectedItem as ChatMessage;
            TopicWindow topic = new TopicWindow(top);
            topic.Show();
            this.Close();

        }
    }
}