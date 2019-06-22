using _27_WPF_MVVM.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_WPF_MVVM.Model
{
    public class Photo : ObservObject
    {
        private string filename;
        private string filepath;
        private int filesize;

        public string FileName
        {
            get { return filename; }
            set
            {
                filename = value;
                OnPropertyChanged("FileName");
            }
        }
        public string FilePath
        {
            get { return filepath; }
            set
            {
                filepath = value;
                OnPropertyChanged("FilePath");
            }
        }
        public int FileSize
        {
            get { return filesize; }
            set
            {
                filesize = value;
                OnPropertyChanged("FileSize");
            }
        }
    }
}
