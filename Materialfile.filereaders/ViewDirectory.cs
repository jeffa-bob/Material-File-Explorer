using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Materialfile.filereader
{

  public class FileHistory : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private int location { get; set; } = 0;

    public DirectoryInfo directory { get; set; }

    private List<DirectoryInfo> _DirBackHistory;
    private List<DirectoryInfo> DirBackHistory
    {
      get
      {
        return _DirBackHistory;
      }
      set
      {
        _DirBackHistory = value;
        OnPropertyChanged();
      }
    }

    private List<DirectoryInfo> _DirForHistory;
    private List<DirectoryInfo> DirForHistory
    {
      get
      {
        return _DirForHistory;
      }
      set
      {
        _DirForHistory = value;
        OnPropertyChanged();
      }
    }

    public void backhistory()
    {
      directory = DirBackHistory[0];
      DirForHistory.Insert(0, DirBackHistory[0]);
      DirBackHistory.RemoveAt(0);
    }
    public void forhistory()
    {
      directory = DirForHistory[0];
      DirBackHistory.Insert(0, DirForHistory[0]);
      DirForHistory.RemoveAt(0);
    }
    public void addtoHistory(DirectoryInfo dir)
    {
      try { DirBackHistory.Insert(location, dir); }
      catch (NullReferenceException) { }
    }


    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
  }

  public class ViewDirectory : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public FileHistory history = new FileHistory();

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
        this.history.addtoHistory(this.CurDir);
        OnPropertyChanged();
      }
    }

    private List<FileInfo> _Files;
    public List<FileInfo> Files
    {
      get { return _Files; }
      set
      {
        _Files = value;
        OnPropertyChanged();
      }
    }
    private List<DirectoryInfo> _Dirs;
    public List<DirectoryInfo> Dirs
    {
      get { return _Dirs; }
      set
      {
        _Dirs = value;
        OnPropertyChanged();
      }
    }

    private void getitems()
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
