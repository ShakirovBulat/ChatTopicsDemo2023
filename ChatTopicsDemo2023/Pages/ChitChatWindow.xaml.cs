﻿using System;
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
    /// Логика взаимодействия для ChitChatWindow.xaml
    /// </summary>
    public partial class ChitChatWindow : Window
    {
        public ChatDBEntities dbEntities = new ChatDBEntities();
        public ChitChatWindow()
        {
            InitializeComponent();
            SearchLst.ItemsSource = dbEntities.Employee.ToList();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
