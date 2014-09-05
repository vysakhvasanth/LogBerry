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

namespace Logberry
{
    /// <summary>
    /// Interaction logic for NotifyMessage.xaml
    /// </summary>
    public partial class NotifyMessage : Window
    {
        public NotifyMessage()
        {
            InitializeComponent();
        }

        public NotifyMessage(string title, string message)
        {
            InitializeComponent();
            messageBox.Content = message;
            NotifyWindow.Title = title;
        }
    }
}
