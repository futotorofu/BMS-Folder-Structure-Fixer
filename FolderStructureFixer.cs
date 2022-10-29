using Microsoft.VisualBasic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace FolderStructureFixer
{
    public partial class FolderStructureFixer : Form
    {
        public static string targetPath = "";
        public static int progress = 0;
        public static int maximum = 0;

        private static string logFilePath;
        private static StringBuilder log = new StringBuilder();

        public FolderStructureFixer()
        {
            InitializeComponent();
            logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                targetPath = folderBrowserDialog1.SelectedPath;
                bmsPathBox.Text = targetPath;
            }   
        }

        private void fixBtn_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrWhiteSpace(targetPath))
                return;
            timer1.Start();
            bmsPathBox.ReadOnly = true;
            fixBtn.Enabled = false;

            maximum = Directory.GetDirectories(targetPath).Length;

            //thread to not lag out the GUI
            ThreadStart fixer = new ThreadStart(Fix);
            Thread thread = new Thread(fixer);
            thread.Start();
        }

        public static void Fix()
        {
            string[] folders = Directory.GetDirectories(targetPath);
            foreach(string folder in folders)
            {
                string[] parentFolder = folder.Split('\\'); //scuffed, I wrote this part very early sorry
                string targetName = parentFolder[parentFolder.Length - 1];
                string extraFolder = Path.Combine(folder, targetName);
                if (Directory.Exists(extraFolder))
                {
                    foreach (string f in Directory.GetFiles(extraFolder)) //the extra folder we're looking for
                    {
                        string safeFileName = Path.GetFileName(f);
                        #region subdirectory handling
                        foreach (string sd in Directory.GetDirectories(extraFolder))
                        {
                            string dest = Path.Combine(folder, Path.GetFileName(sd));
                            if (!Directory.Exists(dest)) //sometimes the script attempted to move stuff after the directory was made and windows would error out
                                Directory.Move(sd, dest);
                            else
                            {
                                foreach (string file in Directory.GetFiles(sd)) //a failsafe for above issue
                                {
                                    File.Move(file, Path.Combine(folder, Path.GetFileName(file)));
                                }
                            }
                            if (Directory.Exists(sd)) //if the directory's moved it won't exist anymore so no worries
                                Directory.Delete(sd, false);
                        }
                        #endregion
                        #region individual file handling
                        string fdest = Path.Combine(folder, safeFileName); //final file destination
                        if (!File.Exists(fdest))
                        {   
                            if(Path.GetFileNameWithoutExtension(f).ToLower() == targetName.ToLower())
                            {
                                fdest += "bruh"; // in case someone named a file the exact same as the folder without an extension it would fail miserably, thanks windows
                            }
                            File.Move(f, fdest);
                        }
                        #endregion
                    }
                    log.AppendLine("Moved files in " + extraFolder);
                    try //probably unnecessary for the original use case but I'll leave it
                    {
                        File.SetAttributes(extraFolder, FileAttributes.Normal); //can't delete a read-only folder
                        Directory.Delete(extraFolder, true);
                    }
                    catch (UnauthorizedAccessException exception)
                    {
                        log.AppendLine("Failed to delete directory " + extraFolder + ", probably not serious but try running the tool as admin");
                    }
                }
                Interlocked.Increment(ref progress);
            }
            File.AppendAllText(logFilePath, log.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            curStatLbl.Text = "Progress: Folder " + progress.ToString() + " out of " + maximum.ToString();
        }

        private void FolderStructureFixerForm_Load(object sender, EventArgs e)
        {
            string warning = "Hey. This is a tool designed for a VERY niche use case.\n" +
                "It might be usable for other things as well, however, misuse may result in SERIOUS data loss.\n" +
                "I AM NOT RESPONSIBLE IF THAT HAPPENS.\n" +
                "As the old adage goes, with great power comes great responsibility.\n" + 
                "Do you agree with these terms?";
            DialogResult dialogResult = MessageBox.Show(warning, "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
                Application.Exit();
        }
    }
}