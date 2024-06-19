using System.IO;
using System.Security.AccessControl;


namespace Lab27
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                listBox1.Items.Add(drive.Name);
                listBox1.Items.Add("");
            }


        }

        // Кнопка для перегляду властивостей диску
        private void button1_Click(object sender, EventArgs e)
        {
            DriveInfo selectedDrive = null;

            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string selectedDriveName = selectedItem.Split(':')[0];

                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.Name.StartsWith(selectedDriveName, StringComparison.OrdinalIgnoreCase))
                    {
                        selectedDrive = drive;
                        break;
                    }
                }

                if (selectedDrive != null)
                {
                    MessageBox.Show($"Назва диску: {selectedDrive.Name}\n" +
                                    $"Тип диску: {selectedDrive.DriveType}\n" +
                                    $"Ємність диску: {(selectedDrive.TotalSize / (1024 * 1024 * 1024)).ToString()} ГБ\n" +
                                    $"Вільна ємність диску: {(selectedDrive.TotalFreeSpace / (1024 * 1024 * 1024)).ToString()} ГБ");
                }
                else
                {
                    MessageBox.Show("Диск не знайдено.");
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }

        // Кнопка для переміщення файлів у диск
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Виберіть файл для переміщення!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Виберіть місце для переміщення файла";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Move(sourcePath, targetPath);
                        MessageBox.Show("Файл переміщено.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Помилка при переміщенні: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка для перегляду властивостей файлу або каталогу
        private void button4_Click(object sender, EventArgs e)
        {
            DirectoryInfo selectedDirectory = null;
            FileInfo selectedFile = null;

            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                selectedDirectory = new DirectoryInfo(selectedItem);

                if (selectedDirectory.Exists)
                {
                    MessageBox.Show($"Назва каталогу: {selectedDirectory.FullName}\n" +
                                    $"Дата створення: {selectedDirectory.CreationTime}\n" +
                                    $"Остання зміна: {selectedDirectory.LastWriteTime}\n" +
                                    $"Файли: {selectedDirectory.GetFiles().Length}\n" +
                                    $"Підкаталоги: {selectedDirectory.GetDirectories().Length}");
                }
                else
                {
                    selectedFile = new FileInfo(selectedItem);

                    if (selectedFile.Exists)
                    {
                        MessageBox.Show($"Назва файлу: {selectedFile.Name}\n" +
                                       $"Розмір: {(selectedFile.Length / (1024)).ToString()} KB\n" +
                                       $"Дата створення: {selectedFile.CreationTime}\n" +
                                       $"Остання зміна: {selectedFile.LastWriteTime}");
                    }
                    else
                    {
                        MessageBox.Show("Елемент не знайдено.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }

        // Кнопка для перегляду каталогів диску
        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo selectedDirectory = null;

            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                selectedDirectory = new DirectoryInfo(selectedItem);

                if (selectedDirectory.Exists)
                {
                    listBox2.Items.Clear();

                    string[] dirs = Directory.GetDirectories(selectedItem);
                    foreach (string s in dirs)
                    {
                        listBox2.Items.Add("Підкаталоги:");
                        listBox2.Items.Add(s);
                    }
                    string[] files = Directory.GetFiles(selectedItem);
                    foreach (string s in files)
                    {
                        listBox2.Items.Add("Файли:");
                        listBox2.Items.Add(s);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("Каталог не знайдено.");
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Ви нічого не обрали.");
            }
        }

        // Кнопка для фільтрування
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedDrive = listBox1.SelectedItem.ToString();
                string rootPath = Path.GetPathRoot(selectedDrive);

                string[] allDirs = Directory.GetDirectories(rootPath);
                var filteredDirs = allDirs.Where(dir => dir.Contains(textBox1.Text));

                listBox3.Items.Clear();

                foreach (string dir in filteredDirs)
                {
                    listBox3.Items.Add(dir);
                }
            }
            else
            {
                MessageBox.Show("Виберіть диск зі списку.");
            }
        }

        // Кнопка для перегляду атрибутів безпеки
        private void button6_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();

                try
                {
                    FileAttributes attr = File.GetAttributes(selectedItem);

                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        DirectoryInfo selectedDirectory = new DirectoryInfo(selectedItem);

                        if (selectedDirectory.Exists)
                        {
                            foreach (var dirInfo in selectedDirectory.GetAccessControl().GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                            {
                                if (dirInfo is FileSystemAccessRule fileRule)
                                {
                                    listBox4.Items.Add($"Користувач: {fileRule.IdentityReference}");
                                    listBox4.Items.Add($"Тип доступу: {fileRule.FileSystemRights}");
                                    listBox4.Items.Add($"Дозвіл: {fileRule.AccessControlType}");
                                    listBox4.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Каталог не існує.");
                        }
                    }
                    else
                    {
                        FileInfo selectedFile = new FileInfo(selectedItem);

                        if (selectedFile.Exists)
                        {
                            foreach (var fileInfo in selectedFile.GetAccessControl().GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                            {
                                if (fileInfo is FileSystemAccessRule fileRule)
                                {
                                    listBox4.Items.Add($"Користувач: {fileRule.IdentityReference}");
                                    listBox4.Items.Add($"Тип доступу: {fileRule.FileSystemRights}");
                                    listBox4.Items.Add($"Дозвіл: {fileRule.AccessControlType}");
                                    listBox4.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Файл не існує.");
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Помилка доступу: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл або каталог зі списку.");
            }
        }

        // Кнопка для перегляду вмісту текстового файлу
        private void button7_Click(object sender, EventArgs e)
        {
            FileInfo selectedFile = null;
            listBox5.Items.Clear();
            if (listBox2.SelectedItem != null)
            {
                string path = listBox2.SelectedItem.ToString();

                try
                {
                    string readText = File.ReadAllText(path);
                    listBox5.Items.Add(readText); // Змінили listBox4 на listBox5
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при читанні файлу: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Ви нічого не обрали.");
            }
        }
    }
}
