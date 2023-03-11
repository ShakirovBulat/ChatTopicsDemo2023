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
    /// Логика взаимодействия для TopicWindow.xaml
    /// </summary>
    public partial class TopicWindow : Window
    {
        ChatMessage chat = new ChatMessage();
        public TopicWindow(ChatMessage chat)
        {
            InitializeComponent();
            this.chat = chat;
        }
    }
}