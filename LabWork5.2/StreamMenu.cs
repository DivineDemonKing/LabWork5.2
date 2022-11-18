using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabWork5._2
{
    class StreamMenu
    {
        public FileInfo[] StringArrayToFileInfo(string[] stringArray)
        {
            FileInfo[] result = new FileInfo[stringArray.Length ];

            for (int i = 0; i < stringArray.Length; i++)
            {
                result[i] = new FileInfo(stringArray[i]);
            }

            return result;
        }  
        public FileInfo[] FileInfoLengthToLong(FileInfo[] array)
        {
            FileInfo temp;
            int j = 1;
            while (j < array.Length)
            {
                if (array[j - 1].Length > array[j].Length)
                {
                    temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                    j = 0;
                }
                j++;
            }
            return array;
        }
    }
}
