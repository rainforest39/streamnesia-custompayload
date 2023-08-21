using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Streamnesia.Payloads.Entities;

namespace Streamnesia.Payloads
{
    public class LocalPayloadLoader : IPayloadLoader
    {
        public string payloadsDirectory = "payloads";

        public Task<IEnumerable<Payload>> GetPayloadsAsync()
        {
            var payloads = GetLocalPayloads();

            return Task.FromResult(payloads);
        }

        private IEnumerable<Payload> GetLocalPayloads()
        {
            if(HasInternetConnection())
            {
                System.Console.WriteLine("Downloading payloads...");
                UpdatePayloads();
            }

            var json = File.ReadAllText(Path.Combine(payloadsDirectory, "payloads.json"));
            var payloadDefinitions = JsonConvert.DeserializeObject<IEnumerable<PayloadModel>>(json);

            return payloadDefinitions.Select(p => new Payload
            {
                Name = p.Name,
                Sequence = ToCoreEntity(p.Sequence)
            });
        }

        private SequenceItem[] ToCoreEntity(SequenceModel[] sequence)
        {
            return sequence.Select(i => new SequenceItem
            {
                AngelCode = GetPayloadFileText(i.File),
                Delay = i.Delay
            }).ToArray();
        }

        private static void UpdatePayloads()
        {
            const string PayloadsUrl = "https://github.com/USERNAME/NAME/archive/main.zip";

            using (var client = new WebClient())
            {
                if(System.IO.Directory.Exists("main-payloads"))
                {
                    System.IO.Directory.Delete("main-payloads", true);
                }

                client.DownloadFile(PayloadsUrl,  @"main.zip");
                System.IO.Compression.ZipFile.ExtractToDirectory(@"main.zip", "main-payloads");
                System.IO.File.Delete(@"main-payloads\streamnesia-payloads-main\LICENSE");
                System.IO.File.Delete(@"main-payloads\streamnesia-payloads-main\README.md");
                DirectoryCopy(@"main-payloads\streamnesia-payloads-main", "..", true);
                System.IO.File.Delete(@"main.zip");
                System.IO.Directory.Delete("main-payloads", true);
            }

            System.Console.WriteLine("Finished downloading payloads!");
        }

    private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        // Get the subdirectories for the specified directory.
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        // If the destination directory doesn't exist, create it.
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        // Get the files in the directory and copy them to the new location.
        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, true);
        }

        // If copying subdirectories, copy them and their contents to new location.
        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }

        public static bool HasInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                    using (client.OpenRead("http://google.com/generate_204")) 
                        return true; 
            }
            catch
            {
                return false;
            }
        }

        private string GetPayloadFileText(string file)
        {
            if(file is null)
                return null;

            return File.ReadAllText(Path.Combine(payloadsDirectory, file));
        }

        private string FormatPayloadName(string name)
            => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.Replace("-", " ").ToLower());
    }
}
