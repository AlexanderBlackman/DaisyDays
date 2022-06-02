using System.Drawing;

namespace DaisyDays.Tools
{
    public class ImageSpliter
    {


        string outputFolder = "B://Output";

        public string[][] SplitImage(string selectedImagePath, int numberOfParts)
        {
            //Create a new bitmap object from the specified file.
            Bitmap originalImage = new Bitmap(selectedImagePath);

            // CREATE A WAY TO ALLOW NON PRIMES


            int regularRow = (int)System.Math.Sqrt(numberOfParts);//try increasing by 1
            //int numberOfRows = regularRow;
            int remainingRow = numberOfParts - (regularRow * regularRow);
            if (remainingRow != 0)
                regularRow++;

            //Store original format
            System.Drawing.Imaging.PixelFormat format = originalImage.PixelFormat;
            //Store filename
            int startStr = selectedImagePath.LastIndexOf("/");
            int endStr = selectedImagePath.LastIndexOf(".") - startStr;
            string pictureName = selectedImagePath.Substring(startStr, endStr);
            //Get dimensions of original.
            int width = originalImage.Width;
            int height = originalImage.Height;

            //Calculate Width and Height of each split file.


            //!!!!!!
            // 'Index was outside the bounds of the arra


            //SquareNumberArea

            // float widthOfEachPart = width / regularRow;
            //if (remainingRow != 0)
            //    float widthOfRemainder = width / remainingRow;

            //float heightOfEachPart = (remainingRow == 0) ? (height / regularRow) : height / (regularRow + 1);
            float heightOfEachPart = height / regularRow;


            //Make array for output image dimensions
            //RectangleF[,] outputRects = new RectangleF[regularRow, regularRow];//Check this
            //RectangleF[]





            int r;
            var ResultArray = new string[regularRow][];
            remainingRow = (remainingRow == 0) ? regularRow : remainingRow;

            for (r = 0; r < regularRow - 1; r++)
                GenerateRowOfPictures(r, regularRow);
            GenerateRowOfPictures(r, remainingRow);
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
