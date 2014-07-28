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
using Path = System.IO.Path;

namespace Logberry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LogViewUpadater logViewUpadter;
        public MainWindow()
        {
            InitializeComponent();
            logViewUpadter = new LogViewUpadater(LogView);
        }

        private void LogBerryWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //resize the layoutpanels to ratio
            dockDataGrid.FloatingWidth = e.NewSize.Width/4;
            dockDataGrid.Title = Path.GetFileName(logViewUpadter.FILENAME);
            
        }

        private void LogView_Drop(object sender, DragEventArgs e)
        {
            string[] files;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                logViewUpadter.FILENAME = files[0];
                logViewUpadter.LoadFile();

            }
        }

    }
}
