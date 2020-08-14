using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Materialfile.filereader
{
  public struct filitem
  {
    public string path { get; set; }
    public bool isdir { get; set; }
    public string fileexten { get; set; }
  }
  public class CurDirectory
  {
    public string path { get; set; }
    private List<string> directories { get; set; }
    private List<string> files { get; set; }
    public List<filitem> items { get; private set; }

    public void getitems()
    {
      getdir();
      getfiles();
      foreach (string i in directories)
      {
        filitem temp = new filitem();
        temp.path = i;
        temp.isdir = true;
        items.Add(temp);
      }
      foreach (string i in files)
      {
        filitem temp = new filitem();
        temp.path = i;
        temp.isdir = false;
        temp.fileexten = Path.GetExtension(temp.path);
        items.Add(temp);
      }
    }

    private void getdir()
    {
      this.directories = (Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly)).ToList();
    }
    private void getfiles()
    {
      this.files = (Directory.GetFiles(path)).ToList();
    }
  }
}
