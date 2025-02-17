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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JobSearch.Views;

namespace JobSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            LoginView view = new LoginView();
            view.Show();
        }

        private void Registration_OnClick(object sender, RoutedEventArgs e)
        {
            RegistrationView view = new RegistrationView();
            view.Show();
        }

        private void Profile_OnClick(object sender, RoutedEventArgs e)
        {
            UserProfileView view = new UserProfileView();
            view.Show();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FindVacancies_OnClick(object sender, RoutedEventArgs e)
        {
            VacanciesView view = new VacanciesView();
            view.Show();
        }

        private void AddVacancy_OnClick(object sender, RoutedEventArgs e)
        {
            AddVacancyView view = new AddVacancyView();
            view.Show();
            this.Close();
        }
    }
}
