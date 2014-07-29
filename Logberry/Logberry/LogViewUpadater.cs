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
        private DataGrid LogView;
        private List<String> LogItems = new List<string>();
        public List<LogData> logData = new List<LogData>();
        public string FILENAME = @"46_simplex_elv_bcsp.out";

        public LogViewUpadater(DataGrid LogView)
        {
            this.LogView = LogView;
            LoadFile();
        }


        /*
         * Loads the log file
         */
        public void LoadFile()
        {
            //remove previous entries
            LogItems.Clear();
            logData.Clear();
            if (ReadFromFile(FILENAME))
            {
                UpdateView(GetItemInfo());
            }
        }

        /*
         * Simply populate the datagrid view with
         * the entire contents of the list
         */
        public List<LogData> GetItemInfo()
        {
            int _id = 0;
            foreach (String item in LogItems)
            {
                LogData dat = new LogData();
                dat.ID = _id++;
                dat.Log_Data = item;
                logData.Add(dat);
            }
            return logData;
        }

        public bool UpdateView(Object data)
        {
            try
            {
                LogView.ItemsSource = (IEnumerable)data;

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /*
         * Read everything from the file and dump it into
         * a list
         */
        private bool ReadFromFile(string FILE)
        {
            try
            {
               using (StreamReader reader = new StreamReader(FILE))
               {
                  while(!reader.EndOfStream) 
                  LogItems.Add(reader.ReadLine());
               }
                
            }
            catch (Exception ex)
            {
                InformerPrompt info = new InformerPrompt("FileError",ex.Message);
                return false;
            }


            return true;
        }
    }
}
