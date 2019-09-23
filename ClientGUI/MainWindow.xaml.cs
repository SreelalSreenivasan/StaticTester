using System;
using System.ComponentModel;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Text;
using FileSenderLib;

namespace GitHubUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient clientforGit = new WebClient();
        FileSenderLib.ZipFileSender zipFileSender = new ZipFileSender();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientforGit.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri githubUri = new Uri(GitHubUrl.Text);
            clientforGit.DownloadFileAsync(githubUri, @"C:\Users\320052122\Desktop\CaseStudyPhase2\MS2-Case2-Phase1\StaticAnalyzerWebServiceSolution\GitHubZipFiles\GitHub.zip");
            zipFileSender.GitFilepath = @"C:\Users\320052122\Desktop\CaseStudyPhase2\MS2-Case2-Phase1\StaticAnalyzerWebServiceSolution\GitHubZipFiles\GitHub.zip";
            zipFileSender.GetZipFilePath();


        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File Downloaded");
        }


    }
}
