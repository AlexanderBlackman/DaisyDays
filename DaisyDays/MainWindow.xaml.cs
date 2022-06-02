using DaisyDays.Tools;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DaisyDays
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            ImageSpliter mySplitter = new();
            this.InitializeComponent();
            mySplitter.SplitImage("b://thinImage.jpg", 17);
        }

        //Morning TODO
        //Solve the following errors
        /* 'Index was outside the bounds of the array.'.
        Exception thrown at 0x778BED42 (KernelBase.dll) in DaisyDays.exe: WinRT originate error - 0x80131508 : 'A failure occurred in Application::OnLaunched, the application is unable to start.'.
        */
    }
}
