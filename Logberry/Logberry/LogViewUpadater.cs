using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Logberry
{
    public class LogViewUpadater
    {
        private DataGrid _LogView;
        private MainWindow mainWindow;
        private List<String> LogItems = new List<string>();
        public List<LogData> _logData = new List<LogData>();
        public string _file = "46_simplex_elv_bcsp.out";
        public bool isLogLoaded = false;

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
        }

        public async Task<List<LogData>> asyncReadFile()
        {
            List<LogData> readLines = new List<LogData>();
            int count = 0;

            using (StreamReader sr = new StreamReader(_file))
            {

                while (true)
                {
                    string line = await sr.ReadLineAsync();
                    if (line == null) break;

                    LogData vt = new LogData() { ID = count++, INFO = line };
                    readLines.Add(vt);
                }
            }

            return readLines;
        }
    }
}
