using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace DaisyDays.ViewModels
{
    [ObservableObject]
    public partial class SagaPhotoViewModel
    {
        [ObservableProperty]
        private BitmapImage sourceImage;
        [ObservableProperty]
        private String sagaEntry;

        public SagaPhotoViewModel(String imageSource)
        {
            sagaEntry = "moo";//String.Empty;
            sourceImage = new BitmapImage(new Uri(imageSource));
        }

    }
}
