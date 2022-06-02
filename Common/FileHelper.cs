using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace Common
{
    public class FileHelper
    {
        public void ReadExcle(string fileDirectoryWithName, Action<string> actionAfterReadColumn)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var stream = File.Open(fileDirectoryWithName, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            do
            {
                while (reader.Read())
                    for (int column = 0; column < reader.FieldCount; column++)
                    {
                        var columnValue = reader.GetValue(column);
                        actionAfterReadColumn(columnValue?.ToString());
                        Console.WriteLine(columnValue);
                        
                    }
            } while (reader.NextResult());
        }

        public IEnumerable<string> GetAvalibleFiles(string directoriPath, string fileExtension)
            => Directory.GetFiles(directoriPath, $"*.{fileExtension}");

    }
}