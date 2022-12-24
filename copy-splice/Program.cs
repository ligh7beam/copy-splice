var spliceSoundsFolderPath = "/Users/lightbeam/Splice/sounds";
var destinationPath = "/Volumes/EmoPunk/Splice/ALL SAMPLES I HAVE";

CopyAllFiles(spliceSoundsFolderPath);

Console.WriteLine("*********************************");
Console.WriteLine("\n\n\n\n   All Done!    \n\n\n\n");
Console.WriteLine("*********************************");

void CopyAllFiles(string path)
{
    var files = Directory.GetFiles(path);

    foreach (var file in files)
    {
        var fileName = Path.GetFileName(file);
        var fileExtension = Path.GetExtension(file);

        if (fileName == ".DS_Store") { continue; }
        if (fileExtension == ".asd") { continue; }

        var newFilePath = $"{destinationPath}/{fileName}";

        if (!File.Exists(newFilePath))
        {
            File.Copy(file, newFilePath, overwrite: false);
        }
    }

    var subdirectories = Directory.GetDirectories(path);

    foreach (var subdirectory in subdirectories)
    {
        CopyAllFiles(subdirectory);
    }
}