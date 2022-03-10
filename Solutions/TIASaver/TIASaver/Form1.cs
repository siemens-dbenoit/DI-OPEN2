using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ++++++++++++++++++++++++++++++++++
// ++++++++++++++++++++++++++++++++++
// TODO:
// en:
// include using-directives here!
// de:
// using-Anweisung hier einfügen!
using Siemens.Engineering;
using Siemens.Engineering.Hmi;
// ++++++++++++++++++++++++++++++++++
// ++++++++++++++++++++++++++++++++++

namespace TIASaver
{
    public partial class FMain : Form
    {

        // ++++++++++++++++++++++++++++++++++
        // ++++++++++++++++++++++++++++++++++
        // TODO:
        // en:
        // declare the globale variables here
        // de:
        // hier die globalen Variablen deklarieren
        public TiaPortalProcess MyTiaPortalInstance;
        public TiaPortal MyPortal;
        public Project MyOpenProject;
        public string ArchivePath = null;
        // ++++++++++++++++++++++++++++++++++
        // ++++++++++++++++++++++++++++++++++


        public FMain()
        {
            InitializeComponent();
        }

        private void btnConnectToTIA_Click(object sender, EventArgs e)
        {
            if (btnConnectToTIA.Text == "Connect to TIA Portal")
            {
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Get all running TIA instances
                // connect to the process
                // check if a Project is opened
                // if yes, assign it to the variable MyOpenProject
                // if not, assign null to the variable MyOpenProject
                // de:
                // Laufende Portale ermitteln
                // mit Prozess verbinden
                // Prüfung, ob ein Projekt geöffnet ist
                // Wenn ja, an die Variable MyOpenProject zuweisen
                // Wenn nein, der Variablen MyOpenProject ein null zuweisen
                IList<TiaPortalProcess> MyRunningTias = TiaPortal.GetProcesses();
                // Given the fact that only one TIA is running, otherwise handle as in slide.
                if (MyRunningTias.Count == 0)
                {
                    return;
                }
                MyTiaPortalInstance = MyRunningTias[0];
                MyPortal = MyTiaPortalInstance.Attach();

                // Given the fact that only one Project is opened
                if (!(MyPortal.Projects.Count == 0))
                {
                    MyOpenProject = MyPortal.Projects[0];
                }
                else
                {
                    MyOpenProject = null;
                }

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                btnSave.Enabled = true;
                btnSaveAs.Enabled = true;
                btnArchive.Enabled = true;
                btnConnectToTIA.Text = "Disconnect from TIA Portal";
            }
            else
            {
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Disconnect from TIA Portal
                // de:
                // Verbindung zum TIA Portal trennen
                MyPortal.Dispose();
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                btnSave.Enabled = false;
                btnSaveAs.Enabled = false;
                btnArchive.Enabled = false;
                btnConnectToTIA.Text = "Connect to TIA Portal";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
            // TODO:
            // en:
            // Check if a Project is opened
            // if yes, save the Project
            // de:
            // Abfrage, ob ein Projekt geöffnet ist
            // Wenn ja, dann Projekt speichern
            if (!(MyOpenProject == null))
            {
                MyOpenProject.Save();
            }
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (MyOpenProject == null)
            {
                return;
            }
            FolderBrowserDialog MyBrowserDialog = new FolderBrowserDialog();
            MyBrowserDialog.SelectedPath = MyOpenProject.Path.ToString();
            MyBrowserDialog.Description = "Please select an empty folder to save";
            if (MyBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Perform a "Save as" to the location that was selected via the Dialog
                // Access to the selected folder: MyBrowserDialog.SelectedPath
                // de:
                // "Speichern unter" durchführen auf den leeren Ordner, der vom Dialog ausgewählt wurde
                // Zugriff auf ausgewählten Ordner: MyBrowserDialog.SelectedPath
                MyOpenProject.SaveAs(new System.IO.DirectoryInfo(MyBrowserDialog.SelectedPath));
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
            }

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (MyOpenProject == null)
            {
                return;
            }
            if (ArchivePath == null)
            {
                FolderBrowserDialog MyBrowserDialog = new FolderBrowserDialog();
                MyBrowserDialog.SelectedPath = MyOpenProject.Path.ToString();
                MyBrowserDialog.Description = "Please select an empty folder to save";
                if (MyBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ArchivePath = MyBrowserDialog.SelectedPath;
                }
            }
            string ProjectName = MyOpenProject.Name +"_" +System.DateTime.Now.ToShortDateString() + "__"
                +System.DateTime.Now.ToShortTimeString().Replace(":","_")+".zap16";
            if (ArchivePath!=null & !System.IO.File.Exists(ArchivePath + "\\"+ MyOpenProject.Name + "_" 
                + System.DateTime.Now.ToShortDateString() + "__" + System.DateTime.Now.ToShortTimeString().Replace(":", "_") + ".zap16"))
            {
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Archive the opened Project.
                // The project should be archived in folder ArchivePath, 
                // the name should be ProjectName (not as a solid string, but the variable!) 
                // and it should be compressed with discard of restorable data
                // de:
                // Das geöffnete Projekt soll archiviert werden
                // Dies soll in den Ordner ArchivePath geschehen,
                // der Name soll durch die Variable ProjectName angegeben werden.
                // Das Projekt soll komprimiert werden und die wiederherstellbaren Daten gelöscht werden.
                MyOpenProject.Archive(new System.IO.DirectoryInfo(ArchivePath), ProjectName , ProjectArchivationMode.DiscardRestorableDataAndCompressed);
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
            }
        }
    }
}
