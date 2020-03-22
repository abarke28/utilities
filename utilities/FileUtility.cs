using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace utilities
{
    public static class FileUtility
    {
        public static bool IsValidFilePath(string filePath)
        {
            // Summary
            //
            // Validates supplied path for a file does not contain any invalid characters

            string invalidCharacters = new string(Path.GetInvalidPathChars()) + new string(Path.GetInvalidFileNameChars());

            foreach (char c in invalidCharacters)
            {
                if (filePath.Contains(c)) return false;
            }

            return true;
        }
    }
}
