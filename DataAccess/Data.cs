using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;

namespace DataAccess
{
    public class Data
    {
        private readonly IFileSystem _fileSystem;
        public Data(string FilePath): this(FilePath,new FileSystem()) { }
        public Data(string FilePath, IFileSystem fileSystem )
        {
            _filePath = FilePath;
            _fileSystem = fileSystem;
        }
        private string _filePath { get; set; }

        public void WriteData(string line)
        {
            
            using (var outputStreamWriter = _fileSystem.File.AppendText(_filePath))
            {
               
                outputStreamWriter.WriteLine($"\n{line}");
            }
        }
        public List<string> ReadData()
        {
            {

                List<string> lines = new List<string>();
                

                using (var inputStreamReader = _fileSystem.File.OpenText(_filePath))

                    try
                    {                        
                        while (!inputStreamReader.EndOfStream)
                        {
                            lines.Add(inputStreamReader.ReadLine());
                        }

                        if (lines.Count == 0)
                        {
                            throw new ArgumentNullException(nameof(lines), "File is empty");
                        }
                        else if (lines.Count < 4)
                        {
                            throw new ArgumentOutOfRangeException(nameof(lines), "You are missing some part of the Settings.txt");
                        }
                        else
                            return lines;
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
            }

        }
    }


}
