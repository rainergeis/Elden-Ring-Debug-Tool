﻿using Elden_Ring_Debug_Tool_ViewModels.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Erd_Tools.ERHook;

namespace Elden_Ring_Debug_Tool_WPF.Views
{
    /// <summary>
    /// Interaction logic for Cheats.xaml
    /// </summary>
    public partial class DebugView : UserControl
    {
        public DebugView()
        {
            InitializeComponent();
        }

        private DebugViewViewModel _itemGibViewModel;

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext is DebugViewViewModel vm)
            {
                _itemGibViewModel = vm;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            Key key = e.Key;
            if (key == Key.Escape)
                textBox.Text = "Unbound";
            else
                textBox.Text = key.ToString();
            e.Handled = true;

            DG.Focus();
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
                return;

            textBox.Background = Brushes.LightGreen;

        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
                return;

            textBox.Background = Brushes.White;

        }

    }
}
