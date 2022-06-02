using System.Drawing;
using static System.Math;

namespace DaisyDays.Tools
{
    public class ImageSpliter
    {


        string outputFolder = "B://Output";

        public string[][] SplitImage(string selectedImagePath, int numberOfParts)
        {
            //Create a new bitmap object from the specified file.
            Bitmap originalImage = new Bitmap(selectedImagePath);



            //Store original format
            System.Drawing.Imaging.PixelFormat format = originalImage.PixelFormat;
            //Store filename
            int startStr = selectedImagePath.LastIndexOf("/");
            int endStr = selectedImagePath.LastIndexOf(".") - startStr;
            string pictureName = selectedImagePath.Substring(startStr, endStr);
            //Get dimensions of original.
            int width = originalImage.Width;
            int height = originalImage.Height;

            //Calculate The number of Rows and Columns
            //int regularRow = (width > height) ?
            //    (int)Ceiling(Sqrt(numberOfParts)) :
            //    (int)Floor(Sqrt(numberOfParts));
            int regularRow = (int)Floor(Sqrt(numberOfParts));//This is an attempt to isolate a bug   - using this splits everything into three rows of
                                                             //four image, plus one final one for the final part 13 instead of 17


            int lastRow = numberOfParts % regularRow;
            int numberOfRows = (numberOfParts - lastRow) / regularRow;




            //Calculate Width and Height of each split file.

            float heightOfEachPart = height / regularRow;





            int r;
            var ResultArray = new string[regularRow][];
            lastRow = (lastRow == 0) ? regularRow : lastRow;

            //for (r = 0; r < regularRow - 1; r++)
            for (r = 0; r < numberOfRows - 1; r++)
                GenerateRowOfPictures(r, regularRow);
            GenerateRowOfPictures(r, lastRow);
            return ResultArray;


            //for (int c = 0; c < regularRow; c++)
            //{
            //    outputRects[r, c] = new RectangleF(c * widthOfEachPart,
            //     r * heightOfEachPart, widthOfEachPart, heightOfEachPart);
            //    Bitmap splitImage = originalImage.Clone(outputRects[r, c], format);

            //    splitImage.Save($"{outputFolder}/{pictureName}_r{r}c{c}.jpg");
            //}


            //Let's try to rewrite it for any row number.
            void GenerateRowOfPictures(int r, int numberOfCols)
            {
                float widthOfEachPart = width / numberOfCols;
                ResultArray[r] = new string[numberOfCols];
                for (int c = 0; c < numberOfCols; c++)
                {
                    var myRec = new RectangleF(c * widthOfEachPart,
                                     r * heightOfEachPart, widthOfEachPart, heightOfEachPart);
                    Bitmap splitImage = originalImage.Clone(myRec, format);

                    splitImage.Save($"{outputFolder}/{pictureName}_r{r}c{c}.jpg");
                }

            }






        }
    }
}
