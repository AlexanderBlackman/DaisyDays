using System.Drawing;

namespace DaisyDays.Tools
{
    public class ImageSpliter
    {


        string outputFolder = "B://Output";

        public void SplitImage(string selectedImagePath, int numberOfParts)
        {
            //Create a new bitmap object from the specified file.
            Bitmap originalImage = new Bitmap(selectedImagePath);




            //Store original format
            System.Drawing.Imaging.PixelFormat format = originalImage.PixelFormat;
            //Store filename
            int startStr = selectedImagePath.LastIndexOf("/") - 1;
            int endStr = selectedImagePath.LastIndexOf(".") - startStr - 1;
            string pictureName = selectedImagePath.Substring(startStr, endStr);
            //Get dimensions of original.
            int width = originalImage.Width;
            int height = originalImage.Height;

            //Calculate Width and Height of each split file.

            int numberPerRow = (int)System.Math.Sqrt(numberOfParts);
            float widthOfEachPart = (width / numberOfParts) * numberPerRow;
            float heightOfEachPart = (height / numberOfParts) * numberPerRow;

            //Make array for output image dimensions
            RectangleF[,] outputRects = new RectangleF[numberPerRow, numberPerRow];
            for (int r = 0; r < numberPerRow; r++)
                for (int c = 0; c < numberPerRow; c++)
                {
                    outputRects[r, c] = new RectangleF(c * widthOfEachPart,
                     r * heightOfEachPart, widthOfEachPart, heightOfEachPart);
                    Bitmap splitImage = originalImage.Clone(outputRects[r, c], format);

                    splitImage.Save($"{outputFolder}/{pictureName}_r{r}c{c}.jpg");
                }


        }
    }
}
