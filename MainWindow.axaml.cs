using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Materialfile.filereader;

namespace Materialfile
{
  public class MainWindow : Window
  {
    public CurDirectory cur { get; set; }
    public MainWindow()
    {
      cur = new CurDirectory();
      cur.getitems();
      InitializeComponent();
      DataContext = this;
#if DEBUG
      this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}
