using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Materialfile.filereader
{
  public class CurDirectory
  {
    public static string homePath = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
  
    public DirectoryInfo CurDir = new DirectoryInfo(homePath);
    public List<FileInfo> Files { get; private set; }
    public List<DirectoryInfo> Dirs { get; private set; }

    public void getitems()
    {
      Files = CurDir.GetFiles().ToList();
      Dirs = CurDir.GetDirectories().ToList();
    }
  }
}
