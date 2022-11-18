using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabWork5._2
{
    class LaunchLab
    {
        public int StringToInt ()
        {
            string input;
            int result;
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out result));
            return result;
        }
        public void Lab()
        {
            StreamMenu streamMenu = new StreamMenu(); // хз нужно ли будет
            List<string> expansionList = new List<string>();
            string input;
            string path = @"C:\Games\Heroes3_HotA";

            //Пользователь вводит количество расширений и сами расширения
            Console.WriteLine("Введите количество расширений");
            //Решил не создавать переменную в мейне а сразу сделать все в методе
            int expansionCount = StringToInt();
            Console.WriteLine("Введите разширения");

            for (int i = 0; i < expansionCount; i++)
            {
                input = Console.ReadLine();
                expansionList.Add("." + input);
            }
            Console.Clear();
            FileInfo[][] fileInfoArray = new FileInfo[expansionCount][];
            string[][] stringArray = new string[expansionCount][];
            FileInfo[] tempArray;

            expansionList.Sort();

            //Получаем только файлы с указанным расширением
            for (int i = 0; i < expansionList.Count; i++)
            {
                stringArray[i] = Directory.GetFiles(path, $"*{expansionList[i]}");
                tempArray = new FileInfo[stringArray[i].Length];

                for (int j = 0; j < tempArray.Length; j++)
                {
                    tempArray[j] = new FileInfo(stringArray[i][j]);
                }
                fileInfoArray[i] = tempArray;
            }

            //Сортировка массива по длине
            for (int i = 0; i < fileInfoArray.Length; i++)
            {
                fileInfoArray[i] = streamMenu.FileInfoLengthToLong(fileInfoArray[i]);
            }

            for (int i = 0; i < fileInfoArray.Length; i++)
            {
                for (int j = 0; j < fileInfoArray[i].Length; j++)
                {
                    Console.WriteLine($"Имя: {fileInfoArray[i][j].Name} Размер: {fileInfoArray[i][j].Length} байт");
                }
            }
        }
    }
}
