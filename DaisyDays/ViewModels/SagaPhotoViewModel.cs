using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace DaisyDays.ViewModels
{
    [ObservableObject]
    public partial class SagaPhotoViewModel
    {
        //Add the duedate once you create the saga setter
        //[ObservableProperty]
        // DateTime dueDate;
        [ObservableProperty]
        String sagaEntry;

        public StorageFile ImageFile { get; }
        public uint ImageWidth => ImageProperties.Width;
        public ImageProperties ImageProperties { get; }

        public SagaPhotoViewModel(ImageProperties properties, StorageFile imageFile, String sagaEntry)
        {
            ImageProperties = properties;
            ImageFile = imageFile;
            SagaEntry = sagaEntry;
        }


        public async Task<BitmapImage> GetImageSourceAsync()
        {
            using IRandomAccessStream fileStream = await ImageFile.OpenReadAsync();

            // Create a bitmap to be the image source.
            BitmapImage bitmapImage = new();
            bitmapImage.SetSource(fileStream);

            return bitmapImage;
        }








    }


}
