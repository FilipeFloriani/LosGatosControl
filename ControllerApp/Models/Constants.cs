using System;
using System.IO;

namespace ControllerApp.Models
{
    public static class Constants
    {
        public static string WorkingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ControllerApp");
    }
}
