﻿using System.IO;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using ComponentManager = Autodesk.Windows.ComponentManager;
using IWin32Window = System.Windows.Forms.IWin32Window;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using RoomEditorApp;


namespace TCCO_PLUGIN
{
    [Transaction (TransactionMode.Manual)]
    public class nwcCommand: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            IWin32Window revit_window = new kwWindowHandle
                (ComponentManager.ApplicationWindow);
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            nwcForm nwcFM = new nwcForm(doc);
            nwcFM.ShowDialog();

            return Result.Succeeded;
        }
    }
}
