using Avalonia;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Materialfile.filereader;
using ReactiveUI;

namespace Materialfile
{
  public class MainWindow : Window
  {
    public CurDirectory cur { get; set; }
    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;
      cur = new CurDirectory();
      cur.path = "C:\\";
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
