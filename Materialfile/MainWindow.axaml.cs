using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Materialfile.filereader;

namespace Materialfile
{
  public class MainWindow : Window
  {
    public static ViewDirectory cur { get; set; }
    public MainWindow()
    {
      cur = new ViewDirectory();
      cur.CurDir = new System.IO.DirectoryInfo(cur.homePath);
      System.Console.WriteLine(Materialfile.MainWindow.cur.CurDir.FullName);
      InitializeComponent();
      DataContext = this;
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void ChangeFolder(object sender, RoutedEventArgs e)
    {
      cur.CurDir = new System.IO.DirectoryInfo(((Button)sender).Tag.ToString() + cur.OSslash);
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
