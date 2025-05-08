using System.IO;
using System.Text;

namespace SaveLoad {
    public class SaveLoadSystem
    {
        private static string baseDirectory = @"C:\FriendlyFriendsStudentCouncil\";
        private static string saveDirectory = Path.Combine(baseDirectory, "saves");
        private static string saveFilePath = Path.Combine(saveDirectory, "save.txt");

        public static void CreateSave(string content)
        {
            Directory.CreateDirectory(saveDirectory);

            if (!File.Exists(saveFilePath))
            {
                using (File.Create(saveFilePath)) { }
            }

            string binaryContent = BinarySystem.StringToBinary(content, Encoding.ASCII);

            File.WriteAllText(saveFilePath, binaryContent);

        }

        public static string ReadSave() {
            string readContent = File.ReadAllText(saveFilePath);

            return BinarySystem.BinaryToString(readContent, Encoding.ASCII);
        }
    }
}
