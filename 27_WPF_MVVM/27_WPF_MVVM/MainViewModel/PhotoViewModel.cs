using _27_WPF_MVVM.Helper;
using _27_WPF_MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_WPF_MVVM.MainViewModel
{
    public class PhotoViewModel : ObservObject
    {
        private Photo selectedPhoto;
        public ObservableCollection<Photo> Photos { get; set; }
        public Photo SelectedPhoto
        {
            get { return selectedPhoto; }
            set
            {
                selectedPhoto = value;
                OnPropertyChanged("SelectedPhoto");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == true)
                    {
                        FileInfo file = new FileInfo(ofd.FileName);
                        Photo photo = new Photo { FileName = file.Name, FilePath = ofd.FileName, FileSize = (int)file.Length };
                        Photos.Add(photo);
                        SelectedPhoto = photo;
                    }
                }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
           (removeCommand = new RelayCommand(obj =>
           {
               Photo photo = obj as Photo;
               if (photo != null)
               {
                   Photos.Remove(photo);
               }
           },
           (obj) => Photos.Count > 0));

            }
        }
        public PhotoViewModel()
        {
            Photos = new ObservableCollection<Photo>();
        }
    }
}
