using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace delme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        IReadOnlyList<StorageFile> iol;
        StorageFile sf;
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderPicker fp = new FolderPicker();
            fp.FileTypeFilter.Add("*");
            fp.SuggestedStartLocation = PickerLocationId.Desktop;
            fp.ViewMode = PickerViewMode.Thumbnail;
            var files = await fp.PickSingleFolderAsync();
            iol = await files.GetFilesAsync();
           //IReadOnlyList<StorageFolder> file = iol
            Myobj myobj = new Myobj();
            ObservableCollection<Myobj> datasource = new ObservableCollection<Myobj>();
           //Windows.Storage.Streams.IRandomAccessStream iras = await sf.OpenAsync(FileAccessMode.Read);
           sf = iol[0];
           //IReadOnlyList<IStorageFile> file = ;
           foreach (StorageFile a in iol)
           {
               myobj.Name = sf.DisplayName.ToString();
               //gw.DisplayMemberPath = "Name";
               var tn = await sf.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.PicturesView);
               BitmapImage bi = new BitmapImage();
               bi.SetSource(tn);
               myobj.Thumbnail = bi;
               datasource.Add(myobj);
           }
               this.gw.ItemsSource = datasource;
             //  gw.DisplayMemberPath = "data";
               
           
        }
        
    }
}
