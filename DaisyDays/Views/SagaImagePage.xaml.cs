using DaisyDays.Model;
using DaisyDays.Tools;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DaisyDays.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SagaImagePage : Page
    {
        string sagaImage { get; set; }
        public SagaImagePage()
        {
            this.InitializeComponent();
            string sagaImage = "B://Motivate9.jpg";
            //Look at your old SagaPhotoViewModel to see how to make a new one.
            var rabbit = SafeImageSpliter.SplitIntoRegions(sagaImage, 9);

            foreach (SagaEntry sagaEntry in rabbit)
            {

                var bunny = new Button()
                {
                    Width = sagaEntry.ObscurableArea.Width,
                    Height = sagaEntry.ObscurableArea.Height,

                };
                Canvas.SetLeft(bunny, sagaEntry.ObscurableArea.Left);
                Canvas.SetTop(bunny, sagaEntry.ObscurableArea.Top);
                rootCanvas.Children.Add(bunny);
            }


        }
    }
}
