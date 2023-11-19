using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FACSVRCA
{
    public partial class Helper : Form
    {
        public Helper()
        {
            InitializeComponent();
        }

        private void Helper_Load(object sender, EventArgs e)
        {
            var programLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileExtractFolder = $"{programLocation}\\NewerViewer\\";
            if (!Directory.Exists(fileExtractFolder))
            {
                Directory.CreateDirectory(fileExtractFolder);
                ZipFile.ExtractToDirectory(programLocation + @"\NewerViewer.zip", fileExtractFolder);
            }

        }

        private static void DecompressToFileStr(string bundlePath)
        {
            try
            {
                string commands = string.Format($"\"{bundlePath}\" \"cacheDecompress\"");
                Console.WriteLine(commands);
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\NewerViewer\AssetViewer.exe",
                    Arguments = commands,
                    WindowStyle = ProcessWindowStyle.Maximized
                };
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "vrca files (*.vrca)|*.vrca|vrcw files (*.vrcw)|*.vrcw";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text != "")
            {
                DecompressToFileStr(txtFilePath.Text);
                ReplaceInfo($"{txtFilePath.Text}_decomp");
            }
        }

        private void ReplaceInfo(string pathInput)
        {
            string filename = Path.GetFileName(pathInput);
            string path = Path.GetDirectoryName(pathInput);
            string fixedName = $"{path}\\FACS_{filename.Replace("_decomp", "")}";
            var enc = Encoding.GetEncoding(28591);
            using (var vReader = new StreamReaderOver(pathInput, enc))
            {
                using (var vWriter = new StreamWriter(fixedName, false, enc))
                {
                    while (!vReader.EndOfStream)
                    {
                        var vLine = vReader.ReadLine();
                        var replace = CheckAndReplaceLine(vLine);
                        vWriter.Write(replace);
                    }
                }
            }

            try
            {
                File.Delete(pathInput);
            }
            catch { }
            MessageBox.Show($"Goto {fixedName} and use this to view VRCA inside Unity 2019");
        }

        private string CheckAndReplaceLine(string line)
        {
            var enc = Encoding.GetEncoding(28591);
            var edited = line;

            // CACHE VERSIONS REPLACE (NEW METHOD)
            if (edited.Contains("2023.1.18f1"))
            {
                edited = edited.Replace("\b5.x.x\02023.1.18f1", "\a5.x.x\02019.4.31f1");
            }

            return edited;
        }
    }
}