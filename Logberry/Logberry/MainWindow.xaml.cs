using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;
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
            logViewUpadter = new LogViewUpadater(LogView, this);
            
            displayMemoryUsage();

            logViewUpadter.asyncLoad();
        }

        private void displayMemoryUsage()
        {
            DispatcherTimer dp = new DispatcherTimer();
            dp.Interval = new TimeSpan(0,0,1);
            dp.Tick += dp_Tick;
            dp.Start();
        }

        void dp_Tick(object sender, EventArgs e)
        {
            InfoBar.Text = string.Format("Total Memory Usage: {0:0.00} MB", GC.GetTotalMemory(true) / 1024.0 / 1024.0);
        }


        private void LogView_Drop(object sender, DragEventArgs e)
        {
            string[] files;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                logViewUpadter._file = files[0];
                logViewUpadter.asyncLoad();

            }
        }

        private void btn_rgx_filter_Click(object sender, RoutedEventArgs e)
        {
            string rgx = regex_Txt.Text;
            List<LogData> _filtered = new List<LogData>();
            foreach (LogData item in logViewUpadter._logData)
            {
                Match mth = Regex.Match(item.INFO, rgx, RegexOptions.IgnoreCase);
                if (mth.Success) _filtered.Add(item);
            }

            logViewUpadter.UpdateView(_filtered);
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            regex_Txt.Clear();
            if (btn_rgx_filter != null) btn_rgx_filter.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            InfoBar.Text = "<none>";
        }
    }
}
