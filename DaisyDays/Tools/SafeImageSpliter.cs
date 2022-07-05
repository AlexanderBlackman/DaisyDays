using DaisyDays.Model;
using System.Collections.Generic;
using System.Drawing;
using static System.Math;


namespace DaisyDays.Tools
{
    public static class SafeImageSpliter
    {


        public static List<SagaEntry> SplitIntoRegions(string selectedImagePath, int numberOfParts)
        {
            //Create a new bitmap object from the specified file.
            Bitmap originalImage = new Bitmap(selectedImagePath);
            List<SagaEntry> SagaEntries = new();
            int idPlaceholder = 0;



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
            int regularRow = (int)Ceiling(Sqrt(numberOfParts)); //This works without a bug
            int lastRow = numberOfParts % regularRow;
            int numberOfRows = ((numberOfParts - lastRow) / regularRow) + 1;




            //Calculate Width and Height of each split file.
            float heightOfEachPart = height / numberOfRows;




            int r;
            //var ResultArray = new string[numberOfRows + 1][];
            lastRow = (lastRow == 0) ? regularRow : lastRow;

            //for (r = 0; r < regularRow - 1; r++)
            for (r = 0; r < numberOfRows - 1; r++)
                GenerateRowOfRegions(r, regularRow);
            GenerateRowOfRegions(r, lastRow);
            //Return list of regions.
            return SagaEntries;

            //Let's try to rewrite it for any row number.
            void GenerateRowOfRegions(int r, int numberOfCols)
            {
                float widthOfEachPart = width / numberOfCols;
                for (int c = 0; c < numberOfCols; c++)
                {
                    var myRec = new RectangleF(c * widthOfEachPart,
                                     r * heightOfEachPart, widthOfEachPart, heightOfEachPart);
                    SagaEntries.Add(new SagaEntry
                    {
                        ObscurableArea = myRec,
                        DiaryEntryId = idPlaceholder++
                    });
                }

            }
        }
    }
}