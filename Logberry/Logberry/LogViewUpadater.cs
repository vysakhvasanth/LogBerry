using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Logberry
{
    public class LogViewUpadater
    {
        private DataGrid _LogView;
        private MainWindow mainWindow;
        public List<LogData> _logData = new List<LogData>();
        public string _file = "46_simplex_elv_bcsp.out";
        public bool isLogLoaded = false;
        public static string FILENAME = "";
        private NotifyMessage notifyMessage;
        public  bool isLoading;


        public LogViewUpadater(DataGrid _LogView, MainWindow mainWindow)
        {
            this._LogView = _LogView;
            this.mainWindow = mainWindow;
        }

        public bool UpdateView(Object data)
        {
            try
            {
               if(isLogLoaded&&data!=null) 
                   _LogView.ItemsSource = (IEnumerable)data;

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async void asyncLoad()
        {
            _logData = await asyncReadFile();
            if (_logData != null)
            {
                _LogView.ItemsSource = _logData;
                isLogLoaded = true;
            }

            mainWindow.MainInfoBar.Text = "Log loaded from " + new FileInfo(_file).FullName;
            FILENAME=mainWindow.dockDataGrid.Title = new FileInfo(_file).Name;
            isLoading = false;
        }

        public async Task<List<LogData>> asyncReadFile()
        {
            List<LogData> readLines = new List<LogData>();
            int count = 0;

            using (StreamReader sr = new StreamReader(_file))
            {

                while (true)
                {
                    mainWindow.MainInfoBar.Text = "Loading log...";
                    mainWindow.dockDataGrid.Title = "Loading...";
                    isLoading = true;
                    string line = await sr.ReadLineAsync();
                    if (line == null) break;

                    LogData vt = new LogData() { ID = count++, INFO = line };
                    if(line!="")
                        readLines.Add(vt);
                }
            }

            return readLines;
        }

        public async void doFilter(string regex)
        {
            List<LogData> data = await asyncFilter(regex);
            UpdateView(data);
            mainWindow.LogBerryWindow.Title = FILENAME;
           
            if (notifyMessage.IsActive)
            {
                notifyMessage.Close();
                notifyMessage = null;
            }
        }


        //TODO: Implement a callback function to cancel loader form
        public async Task<List<LogData>> asyncFilter(string regex)
        {
            List<LogData> _filtered = new List<LogData>();
            string rgx = regex;
            mainWindow.LogBerryWindow.Title = "Loading...";
            Task t = Task.Run( () =>  {
                                 foreach (LogData item in _logData)
                                 {
                                     Match mth = Regex.Match(item.INFO, rgx, RegexOptions.IgnoreCase);
                                     if (mth.Success)
                                         _filtered.Add(item);
                                 }
            });
            
            if (notifyMessage==null)
            {
                notifyMessage = new NotifyMessage("Loading", "Running regex...");
                notifyMessage.Show();
            }
            await t;
            return _filtered;
            
        }

    }
}
