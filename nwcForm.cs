using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Application = Autodesk.Revit.ApplicationServices.Application;
using Form = System.Windows.Forms.Form;

namespace TCCO_PLUGIN
{
    public partial class nwcForm : Form
    {
        Document _doc;
        public IList<View3D> viewList = new List<View3D>();
        
        public nwcForm(Document doc)
        {
            InitializeComponent();

            FilteredElementCollector coll = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views);
            coll.OfClass(typeof(View3D));

            foreach(View3D v3D in coll)
            {
                if(v3D.CanBePrinted == true)
                {
                    viewList.Add(v3D);
                }
            }
            _doc = doc;
        }

        private void NwcForm_Load(object sender, EventArgs e)
        {
            //Data source for ComboBox
            checkedListBox1.DataSource = viewList;
            checkedListBox1.DisplayMember = "Name";

            String pth = "";
            String txtLocation = @"C:\Users\Public\Documents\ExportCONFIG.txt";
            if (File.Exists(txtLocation))
            {
                TextReader tr = new StreamReader(txtLocation);
                pth = tr.ReadLine();
                tr.Close();

                if(pth != "")
                {
                    label2.Text = pth;
                }
            }
            //Add Tooltips later
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Code will export all selected views in the check list box



            //When export is click the views will be exported and the window will close.
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
