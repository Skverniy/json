using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;

namespace LR4.Classes
{
    class FileService
    {
        string pathFile = "../../../Result/Jdata.json";
        List<User> _users = new List<User>();

        public string FileUserWriter(User user)
        {
            string result = "Файл записан";
            FileUserReader();
            _users.Add(user);

            try
            {
                string directoryPath = Path.GetDirectoryName(pathFile);
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (StreamWriter writer = new StreamWriter(pathFile))
                {
                    string json = JsonSerializer.Serialize(_users);
                    writer.WriteLine(json);
                }
            }
            catch (IOException ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public void FileUserReader()
        {
            _users.Clear();
            try
            {
                if (File.Exists(pathFile))
                {
                    string json = File.ReadAllText(pathFile);
                    if (json != null)
                    {
                        _users = JsonSerializer.Deserialize<List<User>>(json);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<User> LoadUsers()
        {
            FileUserReader();
            return _users;
        }

        public string getNewImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string distinPath = @"..\..\..\Image\profile.png";

            if ((bool)openFileDialog.ShowDialog())
            {
                string picFileName = Path.GetFileName(openFileDialog.FileName);
                distinPath = @"..\..\..\Image\" + picFileName;

                string directoryPath = Path.GetDirectoryName(distinPath);
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (!File.Exists(distinPath))
                {
                    File.Copy(openFileDialog.FileName, distinPath);
                }
            }
            return distinPath;
        }
    }
}