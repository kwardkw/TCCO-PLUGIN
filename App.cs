using System;
using System.Reflection;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Collections.Generic;
using System.IO;

namespace TCCO_PLUGIN
{
    class App: IExternalApplication
    {
        //Variable for TabName and RibbonName
        const String tabName = "TURNER CONSTRUCTION";
        const String rbName = "Setup Manager";
        const String rbExport = "Export Tools";
        const String rbAbout = "Turner";
        static string _namespace_prefix = typeof(App).Namespace + ".";

        BitmapImage NewBitmapImage(
      Assembly a,
      string imageName)
        {
            Stream s = a.GetManifestResourceStream(
              _namespace_prefix + imageName);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = s;
            img.EndInit();

            return img;
        }

        public Result OnStartup(UIControlledApplication a)
        {
            Assembly Path = Assembly.GetExecutingAssembly();
            string thisAssemblyPath = Path.Location;

            //Create a custom Ribbon Tab
            try
            {
                a.CreateRibbonTab(tabName);
            }
            catch { }

            //Creates a RibbonPanel
            RibbonPanel m_projectPanel = a.CreateRibbonPanel(tabName, rbName);
            RibbonPanel m_exportPanel = a.CreateRibbonPanel(tabName, rbExport);
            RibbonPanel m_projectAbout = a.CreateRibbonPanel(tabName, rbAbout);

            //---------------------------------------------------------------------------------------------------------------------------------------------//
            //Image Sources
            var globePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "dfwxExport.png");
            Uri uriImage = new Uri(globePath);
            BitmapImage dfwxImage = new BitmapImage(uriImage);
            var globePath02 = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "dwgExport.png");
            Uri uriImage02 = new Uri(globePath02);
            BitmapImage dwgImage = new BitmapImage(uriImage02);
            var globePath03 = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "nwcExport.png");
            Uri uriImage03 = new Uri(globePath03);
            BitmapImage nwcImage = new BitmapImage(uriImage03);

            //---------------------------------------------------------------------------------------------------------------------------------------------//
            //Create Tools
            PushButton btn01 = m_projectPanel.AddItem(new PushButtonData("btn01", "Create\r3D Grids", thisAssemblyPath, "TCCO_PLUGIN.grid3dCommand")) as PushButton;
            btn01.LargeImage = NewBitmapImage(Path, "LINE TEST-01.png");
            //ToolTip
            btn01.ToolTip = "Place 3D Grids by Selecting all available grids within an Active View";
            PushButton btn02 = m_projectPanel.AddItem(new PushButtonData("btn02", "Create 3D\rRooms Names", thisAssemblyPath, "TCCO_PLUGIN.rooms3DCommand")) as PushButton;
            btn02.LargeImage = NewBitmapImage(Path, "ROOM-NAMES--26x26.png");
            //ToolTip
            btn02.ToolTip = "Automatically place 3D Room names to all rooms available in the Project";
            PushButton btn03 = m_projectPanel.AddItem(new PushButtonData("btn03", "Place\rInsertion Cube", thisAssemblyPath, "TCCO_PLUGIN.Command")) as PushButton;
            btn03.LargeImage = NewBitmapImage(Path, "insertion cube- 26x26-01.png");
            //ToolTip

            //---------------------------------------------------------------------------------------------------------------------------------------------//
            //Export Tools
            btn03.ToolTip = "Create a Insertion Cube at an specific distance from chosen grid lines. Default Insertion Cube Family will be used.";
            PushButton btn04 = m_exportPanel.AddItem(new PushButtonData("btn04", "Grids", thisAssemblyPath, "TCCO_PLUGIN.Command")) as PushButton;
            btn04.LargeImage = NewBitmapImage(Path, "EXPORT GRIDLINES- 26x26.png");
            //ToolTip
            btn04.ToolTip = "Create 3D Grids using 2D grids.";
            PushButton btn05 = m_exportPanel.AddItem(new PushButtonData("btn05", "DWG", thisAssemblyPath, "TCCO_PLUGIN.dwgCommand")) as PushButton;
            btn05.LargeImage = NewBitmapImage(Path, "dwg-26x26.png");
            //ToolTip
            btn05.ToolTip = "Export 2D/3D CAD Models";
            PushButton btn06 = m_exportPanel.AddItem(new PushButtonData("btn06", "NWC", thisAssemblyPath, "TCCO_PLUGIN.nwcCommand")) as PushButton;
            btn06.LargeImage = NewBitmapImage(Path, "nwc-26x26.png");
            //ToolTip
            btn06.ToolTip = "Export to DWFX";
            PushButton btn07 = m_exportPanel.AddItem(new PushButtonData("btn07", "DWFX", thisAssemblyPath, "TCCO_PLUGIN.dwfxCommand")) as PushButton;
            btn07.LargeImage = NewBitmapImage(Path, "dwfx-26x26.png");
            //ToolTip
            btn07.ToolTip = "Export DWFX";
            PushButton btn08 = m_exportPanel.AddItem(new PushButtonData("btn08", "Export\rSettings", thisAssemblyPath, "TCCO_PLUGIN.Command")) as PushButton;
            btn08.LargeImage = NewBitmapImage(Path, "ex settings- 26x26.png");
            //ToolTip

            //---------------------------------------------------------------------------------------------------------------------------------------------//
            //About 
            PushButton btnAbout = m_projectAbout.AddItem(new PushButtonData("btnAbout", "About", thisAssemblyPath, "TCCO_PLUGIN.aboutCommand")) as PushButton;
            //Place here Image Source
            //ToolTip
            btnAbout.ToolTip = "About Turner Plug-In";

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
