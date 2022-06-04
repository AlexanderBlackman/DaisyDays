using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DaisyDays.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitPicturePage : Page
    {
        //List<SagaPhotoViewModel> PicturesInFolder { get; set; } = new();
        List<ImageEx> PicturesInFolder { get; set; } = new();
        public SplitPicturePage()
        {
            this.InitializeComponent();
            List<String> ImagePaths = System.IO.Directory.GetFiles("B:\\Output").ToList();
            foreach (string path in ImagePaths)
            {
                //PicturesInFolder.Add(new SagaPhotoViewModel(path));
                PicturesInFolder.Add(new ImageEx()
                { Source = new BitmapImage(new Uri(path)) });
            }
        }
    }
}
