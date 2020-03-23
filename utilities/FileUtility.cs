using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace utilities
{
    public static class FileUtility
    {
        public static bool IsValidFilePathAndName(string filePath)
        {
            // Summary
            //
            // Validates supplied path for a file does not contain any invalid characters

            // Validate no invalid characters are in path
            string invalidCharacters = new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars());

            foreach (char c in invalidCharacters)
            {
                if (filePath.Contains(c)) return false;
            }

            // Use FileInfo to validate File could be made
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
            }
            catch (Exception)
            {
                return false;                
            }

            return true;
        }
    }
}
