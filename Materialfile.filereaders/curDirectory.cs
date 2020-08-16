using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Materialfile.filereader
{
  public class CurDirectory : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    readonly public string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
    
    readonly public string OSslash = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ? "/" : "\\";

    private DirectoryInfo _CurDir;
    public DirectoryInfo CurDir
    {
      get { return _CurDir; }
      set
      {
        _CurDir = value;
        getitems();
        OnPropertyChanged();
      }
    }

    public List<FileInfo> Files { get; set; }
    public List<DirectoryInfo> Dirs { get; set; }

    protected void getitems()
    {
      Files = CurDir.GetFiles().ToList();
      Dirs = CurDir.GetDirectories().ToList();
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
