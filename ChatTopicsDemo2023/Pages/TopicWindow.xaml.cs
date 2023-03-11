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
    /// Логика взаимодействия для TopicWindow.xaml
    /// </summary>
    public partial class TopicWindow : Window
    {
        public ChatDBEntities dbEntities = new ChatDBEntities();
        ChatMessage message;
        public TopicWindow(ChatMessage chatMessager)
        {
            InitializeComponent();
            this.message = chatMessager;
            TopicTB.Text = message.Chatroom.Topic;
            var chatRoom = LoginWindow.employee.Id;
            List<ChatMessage> chatMessages = dbEntities.ChatMessage.Where(x => x.Chatroom_Id == chatRoom).ToList();
            List<ChatMessage> distinct = chatMessages.Distinct().ToList();
            MemberLst.ItemsSource = distinct.ToList();
            ChatLst.ItemsSource = message.Chatroom.ChatMessage.ToList();
            //Лист идет по возрастанию datetime, а точнее времени.
            //Лист обновляется только при полном перезагрузке приложения т.к незнаю как обновить message в кнопке send.
        }


        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            ChitChatTopicsWindow chitopics = new ChitChatTopicsWindow();
            chitopics.Show();
            this.Close();
        }

        private void LeaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ChitChatWindow chit = new ChitChatWindow();
            chit.Show();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChatMessage chat = new ChatMessage();
                chat.Sender_Id = message.Sender_Id;
                chat.Chatroom_Id = message.Chatroom_Id;
                chat.Date = DateTime.Now;
                chat.Message = MessageTB.Text;
                dbEntities.ChatMessage.Add(chat);
                dbEntities.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                ChatLst.ItemsSource = message.Chatroom.ChatMessage.ToList();
            }
        }
    }
}

