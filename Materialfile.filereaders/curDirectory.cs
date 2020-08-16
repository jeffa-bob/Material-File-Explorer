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

    public DirectoryInfo CurDir{get; set;}

    public ObservableCollection<FileInfo> Files {get; set;}
    public ObservableCollection<DirectoryInfo> Dirs {get; set;}

    public void getitems()
    {
      Files = new ObservableCollection<FileInfo>(CurDir.GetFiles().ToList());
      Dirs = new ObservableCollection<DirectoryInfo>(CurDir.GetDirectories().ToList());
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }
}
