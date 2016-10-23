using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileHelpers.FileLocator
{
    public class FileLocatorHelper
    {
        public static MachineFile LoadLocations(string code, string dataNo)
        {
            var directoryPath = $"Images\\machines\\{code}#{dataNo}";

            directoryPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                directoryPath);

            return Directory.Exists(directoryPath) ? MachineFile.Create(directoryPath) : null;
        }

        public static IEnumerable<MachineFile> LoadLocations()
        {
            var directoryPath = $"Images\\machines\\";
            var codeDirectories = Directory.EnumerateDirectories(directoryPath);
            return codeDirectories.Select(MachineFile.Create);
        }
    }

    public class MachineFile
    {
        internal static MachineFile Create(string directory)
        {
            var files = Directory.EnumerateFiles(directory).ToList();

            return new MachineFile
            {
                Code =  GetCode(directory), 
                Image = GetImage(files),
                Description = GetDescription(files)
            };
        }

        private static string GetImage(IReadOnlyCollection<string> files)
        {
            return files.FirstOrDefault(f => f.EndsWith("jpg") || f.EndsWith("png"));
        }

        private static string GetDescription(IReadOnlyCollection<string> files)
        {
            var textFile = files.FirstOrDefault(f => f.EndsWith("txt"));
            if(textFile == null)
            {
                return null;
            }
            return File.ReadAllText(textFile);
        }

        private static string GetCode(string directory)
        {
            return Path.GetDirectoryName(directory);
        }

        public bool IsValid
        {
            get
            {
                return !new[] { Code, Image, Description }.Any(string.IsNullOrEmpty);
            }
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
    }
}
