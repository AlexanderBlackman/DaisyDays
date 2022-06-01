using System.Drawing;

namespace DaisyDays.Tools
{
    public class ImageSpliter
    {


        public void SplitImage()
        {



            //Create a new Bitmap object from the specified file
            Bitmap myBitmap = new Bitmap("b://847.jpg");

            //store original format
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;

            //Get the original image's width and height
            int width = myBitmap.Width;
            int height = myBitmap.Height;


            //Make a rectangle for the new image's dimensions
            RectangleF cloneRect = new RectangleF(0, 0, myBitmap.Width / 2, myBitmap.Height / 2);
            //Create a new Bitmap object based on the specified width and height
            Bitmap myBitmap2 = myBitmap.Clone(cloneRect, format);




            ////Create a Graphics object
            //Graphics g = Graphics.FromImage(myBitmap2);

            ////Draw the specified image onto the new Bitmap object
            //g.DrawImage(myBitmap, 0, 0, myBitmap2.Width, myBitmap2.Height);

            //Save the new image to the specified file
            myBitmap2.Save("b://847_4.jpg");

            //Dispose of the Graphics object
            //         g.Dispose();

            //Dispose of the Bitmap objects
            myBitmap.Dispose();
            myBitmap2.Dispose();
        }

        public void SplitImage(string selectedImagePath, int numberOfParts)
        {
            //Create a new bitmap object from the specified file.
            Bitmap originalImage = new Bitmap(selectedImagePath);
            //Store original format
            System.Drawing.Imaging.PixelFormat format = originalImage.PixelFormat;
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
                    splitImage.Save($"{selectedImagePath}_r{r}c{c}.jpg");
                }


        }
    }
}
