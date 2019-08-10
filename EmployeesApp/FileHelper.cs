using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace EmployeesApp
{
    public static class FileHelper
    {
        public async static void WriteTextFileAsync(string filename, string content)
        {
            // gives access to local folder
            var storageFolder = ApplicationData.Current.LocalFolder;
            //create a file
            var textFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            //open file 
            var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite);
            //data writer
            var textWriter = new DataWriter(textStream);
            textWriter.WriteString(content);
            await textWriter.StoreAsync();

        }




        public async static Task<string> ReadTextFileAsync(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();

            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }


    }
}

