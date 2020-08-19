using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Materialfile.filereader;
using Materialfile.Drives;

namespace Materialfile
{
  public class MainWindow : Window
  {
    public static ViewDirectory cur { get; set; }
    public static Drive drives { get; set; } 
    public MainWindow()
    {
      cur = new ViewDirectory();
      drives = new Drive();


      cur.CurDir = new System.IO.DirectoryInfo(cur.homePath);
      cur.history.DirBackHistory.Add(cur.CurDir);
      System.Console.WriteLine(Materialfile.MainWindow.cur.CurDir.FullName);
      InitializeComponent();
      DataContext = this;
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void OpenFile(object sender, RoutedEventArgs e)
    {
      string path = ((Button)sender).Tag.ToString() + cur.OSslash;
      path = path.Remove(path.Length - 1);
      System.Console.WriteLine(path);
      System.Diagnostics.Process.Start(path);
    }

    private void ChangeFolder(object sender, RoutedEventArgs e)
    {
      cur.CurDir = new System.IO.DirectoryInfo(((Button)sender).Tag.ToString() + cur.OSslash);
      cur.history.addtoHistory(cur.CurDir);
      System.Console.WriteLine(((Button)sender).Tag.ToString());
    }

    private void backfolder()
    {
      cur.history.backhistory();
      cur.CurDir = cur.history.directory;
    }

    private void forfolder(){
      cur.history.forhistory();
      cur.CurDir = cur.history.directory;
    }

    private void UpFolder()
    {
      if (System.IO.Directory.GetParent(cur.CurDir.FullName) != null) {
        cur.CurDir = System.IO.Directory.GetParent(cur.CurDir.FullName);
        cur.history.addtoHistory(cur.CurDir);
        System.Console.WriteLine(cur.CurDir.FullName);
      }
      else
      {
        System.Console.WriteLine("At top");
      }
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
