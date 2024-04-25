using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace SpartaDungeonGame
{
    internal class FileControl
    {
        public void Save(string fileName)
        {
            string directory = ".\\..\\..\\..\\sav";
            string filePath = directory + "\\" + fileName;
            string saveInfo = JsonSerializer.Serialize(Program.character);
            try
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                if (!di.Exists) 
                    di.Create();
                FileInfo fi = new FileInfo(filePath);
                if (fi.Exists)
                {
                    fi.Delete();
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.WriteLine(saveInfo);
                    sw.Close();
                    Program.systemMessage.SetMessage("동일한 이름의 저장 파일이 있어 덮어쓰기 하였습니다.");

                }
                else
                {
                    StreamWriter sw = new StreamWriter(filePath);
                    sw.WriteLine(saveInfo);
                    sw.Close();
                    Program.systemMessage.SetMessage("저장했습니다.");
                }
                
            }
            catch (Exception e)
            {
                Program.systemMessage.SetMessage("저장에 실패했습니다. " + e.Message);
            }
        }

        public void Load(string fileName)
        {
            string directory = ".\\..\\..\\..\\sav";
            string filePath = directory + "\\" + fileName;
            string fileInfo;
            DirectoryInfo di = new DirectoryInfo(directory);
            FileInfo fi = new FileInfo(filePath);
            try
            {
                if (!(di.Exists && fi.Exists))
                {
                    Program.systemMessage.SetMessage("그런 이름의 저장 파일이 존재하지 않습니다.");
                    return;
                }
                else
                {
                    StreamReader sr = new StreamReader(filePath);
                    fileInfo = sr.ReadToEnd();
                    sr.Close();
                    Program.character = JsonSerializer.Deserialize<Character>(fileInfo);
                    Program.systemMessage.SetMessage($"{fileName} 파일 불러오기에 성공했습니다.");
                }
            } catch (Exception e)
            {
                Program.systemMessage.SetMessage("불러오기에 실패했습니다. " + e.Message);
            }
        }
    }
}
