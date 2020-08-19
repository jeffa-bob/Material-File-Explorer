using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Materialfile.Drives
{
  public class Drive : INotifyPropertyChanged
  {

    private List<DriveInfo> _DriveInfos;
    public List<DriveInfo> DriveInfos
    {
      get { return _DriveInfos; }
      set
      {
        _DriveInfos = value;
        OnPropertyChanged();
      }
    }

    public Drive()
    {
      DriveInfos = DriveInfo.GetDrives().Where(x => x.IsReady).ToList();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

  }
}
