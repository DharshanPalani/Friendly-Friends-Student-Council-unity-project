using System;
using System.IO;
using System.Linq;
using System.Text;

public class SaveLoadSystem
{

    public static void CreateSave(string content)
    {
        string baseDirectory = @"C:\FriendlyFriendsStudentCouncil\";
        string saveDirectory = Path.Combine(baseDirectory, "saves");
        string saveFilePath = Path.Combine(saveDirectory, "save.txt");

        Directory.CreateDirectory(saveDirectory);

        if (!File.Exists(saveFilePath))
        {
            using (File.Create(saveFilePath)) { }
        }

        string binaryContent = BinarySystem.BinaryConverter(content, Encoding.ASCII);

        File.WriteAllText(saveFilePath, binaryContent);

    }
}
