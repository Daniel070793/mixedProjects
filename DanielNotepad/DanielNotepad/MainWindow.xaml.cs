﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DanielNotepad
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

        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(txtEditor.Text == "")
            {
                txtEditor.Clear();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Danielpad", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        save();
                        break;
                    case MessageBoxResult.No:
                        txtEditor.Text = "";
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("fiks så den går tilbage til editor");
                        break;                      
                }
            }            
        } 

        private void save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Title = "save file";
            saveFile.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
            if (saveFile.ShowDialog() == true)
            {
                StreamWriter write = new StreamWriter(File.Create(saveFile.FileName));

                write.Write(txtEditor.Text);
                write.Dispose();
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            save();
        }

        private void open()
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Title = "Open file";
            open.Filter = "Text Files (*txt)|*txt";
            
            if(open.ShowDialog() == true)
            {
                StreamReader read = new StreamReader(File.OpenRead(open.FileName));

                txtEditor.Text = read.ReadToEnd();
                read.Dispose();
            }
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            open();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            aboutWindow about = new aboutWindow();
            about.ShowDialog();
        }

        private void print()
        {
            //
        }

        private void Print_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Print_Execute(object sender, ExecutedRoutedEventArgs e)
        {
            //
        }
    }
}
