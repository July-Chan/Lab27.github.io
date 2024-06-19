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

        // ������ ��� ��������� ������������ �����
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
                    MessageBox.Show($"����� �����: {selectedDrive.Name}\n" +
                                    $"��� �����: {selectedDrive.DriveType}\n" +
                                    $"������ �����: {(selectedDrive.TotalSize / (1024 * 1024 * 1024)).ToString()} ��\n" +
                                    $"³���� ������ �����: {(selectedDrive.TotalFreeSpace / (1024 * 1024 * 1024)).ToString()} ��");
                }
                else
                {
                    MessageBox.Show("���� �� ��������.");
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }

        // ������ ��� ���������� ����� � ����
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "������� ���� ��� ����������!";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "������� ���� ��� ���������� �����";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetPath = saveFileDialog.FileName;

                    try
                    {
                        File.Move(sourcePath, targetPath);
                        MessageBox.Show("���� ���������.");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("������� ��� ���������: " + ex.Message);
                    }
                }
            }
        }

        // ������ ��� ��������� ������������ ����� ��� ��������
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
                    MessageBox.Show($"����� ��������: {selectedDirectory.FullName}\n" +
                                    $"���� ���������: {selectedDirectory.CreationTime}\n" +
                                    $"������� ����: {selectedDirectory.LastWriteTime}\n" +
                                    $"�����: {selectedDirectory.GetFiles().Length}\n" +
                                    $"ϳ���������: {selectedDirectory.GetDirectories().Length}");
                }
                else
                {
                    selectedFile = new FileInfo(selectedItem);

                    if (selectedFile.Exists)
                    {
                        MessageBox.Show($"����� �����: {selectedFile.Name}\n" +
                                       $"�����: {(selectedFile.Length / (1024)).ToString()} KB\n" +
                                       $"���� ���������: {selectedFile.CreationTime}\n" +
                                       $"������� ����: {selectedFile.LastWriteTime}");
                    }
                    else
                    {
                        MessageBox.Show("������� �� ��������.");
                    }
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }

        // ������ ��� ��������� �������� �����
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
                        listBox2.Items.Add("ϳ���������:");
                        listBox2.Items.Add(s);
                    }
                    string[] files = Directory.GetFiles(selectedItem);
                    foreach (string s in files)
                    {
                        listBox2.Items.Add("�����:");
                        listBox2.Items.Add(s);
                    }
                }
                else
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("������� �� ��������.");
                }
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("�� ����� �� ������.");
            }
        }

        // ������ ��� ������������
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
                MessageBox.Show("������� ���� � ������.");
            }
        }

        // ������ ��� ��������� �������� �������
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
                                    listBox4.Items.Add($"����������: {fileRule.IdentityReference}");
                                    listBox4.Items.Add($"��� �������: {fileRule.FileSystemRights}");
                                    listBox4.Items.Add($"�����: {fileRule.AccessControlType}");
                                    listBox4.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("������� �� ����.");
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
                                    listBox4.Items.Add($"����������: {fileRule.IdentityReference}");
                                    listBox4.Items.Add($"��� �������: {fileRule.FileSystemRights}");
                                    listBox4.Items.Add($"�����: {fileRule.AccessControlType}");
                                    listBox4.Items.Add("-------------------------------------------");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("���� �� ����.");
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"������� �������: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�������: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("������� ���� ��� ������� � ������.");
            }
        }

        // ������ ��� ��������� ����� ���������� �����
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
                    listBox5.Items.Add(readText); // ������ listBox4 �� listBox5
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������� ��� ������ �����: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("�� ����� �� ������.");
            }
        }
    }
}
