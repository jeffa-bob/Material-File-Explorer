using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Materialfile.filereader
{
  public class CurDirectory
  {
    public DirectoryInfo CurDir = new DirectoryInfo("c:\\");
    public List<FileInfo> Files { get; private set; }
    public List<DirectoryInfo> Dirs { get; private set; }

    public void getitems()
    {
      Files = CurDir.GetFiles().ToList();
      Dirs = CurDir.GetDirectories().ToList();
    }
  }
}
