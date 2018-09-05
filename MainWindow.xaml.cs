using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GetFileInformation
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string SourceDirectory = @"D:\workspace\サンプルデータ\駅データ";
            if (textbox1.Text != "")
            {
                string SourceDirectory = textbox1.Text;
                IEnumerable<System.IO.FileInfo> files = GetFileInformations(SourceDirectory);
                foreach (var file in files)
                {
                    textBox2.AppendText(file.FullName + "," + file.Name + "," + file.LastWriteTime + Environment.NewLine);
                }
            }
            else
            {
                MessageBox.Show("検索するディレクトリを入力してください");
            }
        }

        static IEnumerable<System.IO.FileInfo> GetFileInformations(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            return di.EnumerateFiles("*", SearchOption.AllDirectories);
        }
    }
    class FileInformation
    {
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public DateTime AccessTime { get; set; }
        public DateTime WriteTime { get; set; }
    }
}
