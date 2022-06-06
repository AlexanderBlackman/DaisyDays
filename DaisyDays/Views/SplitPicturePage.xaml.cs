using DaisyDays.ViewModels;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DaisyDays.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitPicturePage : Page
    {
        ObservableCollection<SagaPhotoViewModel> SagaPhotos { get; } = new();
        public SplitPicturePage()
        {
            this.InitializeComponent();
            GetItemsAsync();
        }

        private async Task GetItemsAsync()
        {
            //Replace with dedicated in appsubfolder once you finish saga setup 
            StorageFolder imageFolder = await
                StorageFolder.GetFolderFromPathAsync(@"b:\\Output");
            var result = imageFolder.CreateFileQueryWithOptions
                (new Windows.Storage.Search.QueryOptions());
            IReadOnlyList<StorageFile> imageFiles = await result.GetFilesAsync();
            foreach (StorageFile imageFile in imageFiles)
                SagaPhotos.Add(await LoadImageInfo(imageFile));

        }

        private async Task<SagaPhotoViewModel> LoadImageInfo(StorageFile imageFile)
        {
            var properties = await imageFile.Properties.GetImagePropertiesAsync();
            SagaPhotoViewModel photo = new SagaPhotoViewModel
                (properties, imageFile, String.Empty);
            return photo;
        }
    }
}
