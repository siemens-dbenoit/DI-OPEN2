using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Screen;
using System.IO;
using Siemens.Engineering.Library.Types;


using Siemens.Engineering.Download;
using Siemens.Engineering.Connection;
using Siemens.Engineering.Download.Configurations;

namespace Create_Project
{
    class Program
    {
        #region global staticTags
        public static TiaPortal MyTiaPortalAsProcess;
        public static Project MyProject;
        public static UserGlobalLibrary MyLib;
        #endregion

        static void Main(string[] args)
        {
            try
            {
                #region Chapter5


                #region StartOfProgram
                Console.WriteLine("Program started at " + System.DateTime.UtcNow.ToLocalTime().ToString());
                Console.WriteLine("-------------------------------");
                Console.WriteLine("xxxxxxx Section Prepare xxxxxxx");
                if (!File.Exists(@"D:\Kurse\DI-OPEN2_BIB\DI-OPEN2_Bib.al16"))
                {
                    throw new Exception("Could not find Library for Course");
                }
                if (! Directory.Exists(@"D:\Kurse\DI-OPEN2\"))
                {
                    System.IO.Directory.CreateDirectory(@"D:\Kurse\DI-OPEN2\");
                }
                Console.Write("Creating a new TIA-Portal...");
                //open TIA Portal
                MyTiaPortalAsProcess = new TiaPortal(TiaPortalMode.WithUserInterface);
                Console.Write("done!\r\n");
                //--------------------------
                #endregion
                #region ProjectHandling
                //--------------------------
                //create Projekt 
                if (System.IO.Directory.Exists(@"D:\Kurse\DI-OPEN2\Projekt"))
                {
                    Console.Write("Deleting old Project...");
                    System.IO.Directory.Delete(@"D:\Kurse\DI-OPEN2\Projekt", true);
                    Console.Write("done!\r\n");
                }
                Console.Write("Creating a Project...");
                System.IO.DirectoryInfo DirectoryToSave = new System.IO.DirectoryInfo(@"D:\Kurse\DI-OPEN2\Projekt");
                MyProject = MyTiaPortalAsProcess.Projects.Create(DirectoryToSave, "MyOpennessGeneratedProject");
                Console.Write("Project " + MyProject.Name + " successfully created at " + MyProject.Path.ToString() + "\r\n");
                //--------------------------
                #endregion



                #region OpenGlobalLibrary



                Console.Write("Opening library...");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en: 
                // Open global library (D:\Kurse\DI-OPEN2_BIB\DI-OPEN2_Bib.al16)
                // Static variable to save the library handle: MyLib
                // de:
                // Globale Bibliothek (D:\Kurse\DI-OPEN2_BIB\DI-OPEN2_Bib.al16) öffnen
                // Statische Variable zum Speichern der Bibliothek: MyLib
                MyLib = MyTiaPortalAsProcess.GlobalLibraries.Open(new FileInfo(@"D:\Kurse\DI-OPEN2_BIB\DI-OPEN2_Bib.al16"), OpenMode.ReadOnly);
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                Console.Write("done!\r\n");



                #endregion



                #region ConsoleWriting



                Console.WriteLine("xxxxxxx End Section Prepare xxxxxxx");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("xxxxxxx Section Copy xxxxxxx");




                #endregion



                #region CopyHardware


                Console.Write("Copying CPU-Station from Mastercopies...");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find folder Mastercopies --> Mastercopies\001_copy
                // Copy PLC "PLC_1" in the project
                // de:
                // Ordner Kopiervorlagen --> Hardware\001_copy suchen
                MasterCopyFolder FirstLevelFolder = MyLib.MasterCopyFolder.Folders.Find("Hardware");
                MasterCopyFolder SecondLevelFolder = FirstLevelFolder.Folders.Find("001_copy");
                MasterCopy MyCPUMasterCopy = SecondLevelFolder.MasterCopies.Find("PLC_1");
                Device MyCPU = MyProject.Devices.CreateFrom(MyCPUMasterCopy);
                // CPU "PLC_1" in Projekt kopieren
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                Console.Write("done!\r\n");
                Console.Write("Copying ET200-Station from Mastercopies...");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Copy "ET200SP_16DI" or "ET200SP_8DI" from the same folder - depending on which Hardware is really present
                MasterCopy MyET200SPMasterCopy = SecondLevelFolder.MasterCopies.Find("ET200SP_8DI");
                Device MyET200SP = MyProject.Devices.CreateFrom(MyET200SPMasterCopy);
                // de:
                // ET200 "ET200SP_16DI" oder "ET200SP_8DI" aus dem gleichen Ordner kopieren, je nachdem, welche Hardware tatsächlich vorhanden ist
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++

                Console.Write("done!\r\n");
                Console.Write("Copying Touchpanel from Master Copies...");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Copy TP700 called "Touchpanel"
                MasterCopy MyTouchpanelMasterCopy = SecondLevelFolder.MasterCopies.Find("Touchpanel");
                Device MyTouchpanel = MyProject.Devices.CreateFrom(MyTouchpanelMasterCopy);
                // de:
                // TP700 Comfort mit Namen "Touchpanel" kopieren
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                Console.Write("done!\r\n");
                //-------------------------
                #endregion
                #region GetPlcSw



                Console.Write("Getting PLC Software Container...\r\n");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Iterate through the DeviceItems of the PLC-Station. 
                // to be found: DeviceItem that contains an SW-Container (Name of the DeviceItem: "PLC_1")
                // get the PLC SoftwareContainer and PlcSoftware from that DeviceItem
                // de:
                // DeviceItems der CPU-Station durchsuchen. 
                // gesucht: DevieItem mit SW-Container ("PLC_1")
                // Aus diesem DeviceItem PLC SoftwareContainer und PlcSoftware ermitteln
                DeviceItem MyPLCDeviceItem = MyCPU.DeviceItems.First(DI => DI.Name.Equals("PLC_1"));
                SoftwareContainer MyPLCSoftwareContainer = ((IEngineeringServiceProvider)MyPLCDeviceItem).GetService<SoftwareContainer>();
                PlcSoftware MyPLCSoftware = MyPLCSoftwareContainer.Software as PlcSoftware;
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                Console.Write("done!\r\n");


                #endregion
                #region CopyBlocks


                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find the folder Mastercopies --> "Blocks"
                MasterCopyFolder MyCopyBlockFolder = MyLib.MasterCopyFolder.Folders.Find("Blocks");
                foreach (MasterCopy item in MyCopyBlockFolder.MasterCopies)
                {
                    Console.Write("Copying " + item.Name + "...");
                    MyPLCSoftware.BlockGroup.Blocks.CreateFrom(item);
                    Console.Write("done!\r\n");
                }
                // Copy all Elements in this folder into the PLC blocks
                // use both commented program rows for debugging --> which block is currently being copied?
                // de:
                // Ordner Kopiervorlagen --> "Blocks" suchen
                // alle Elemente in diesem Ordner in die PLC-Blöcke kopieren
                // beide auskommentierte Zeilen Console.Write zum Debugging nutzen --> welcher Baustein wird gerade kopiert?
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // Console.Write("Copying " + item.Name + "...");
                // Console.Write("done!\r\n");



                #endregion
                #region CopyTagTables




                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find the folder Mastercopied --> "Tags"
                // copy all elements in the folder inside the PLC tag table folder
                // use the two outlined program rows for debugging --> which tag table is getting copied at the moment?
                // de:
                // Ordner Kopiervorlagen --> "Tags" suchen
                // alle Elemente in diesem Ordner in die PLC Variablentabellen-Ordner kopieren
                // beide auskommentierte Zeilen Console.Write zum Debugging nutzen --> welche Variablentabelle wird gerade kopiert?
                MasterCopyFolder MyTagTableCopyFolder = MyLib.MasterCopyFolder.Folders.Find("Tags");
                foreach (MasterCopy item in MyTagTableCopyFolder.MasterCopies)
                {
                    Console.Write("Copying tag table " + item.Name + "...");
                    MyPLCSoftware.TagTableGroup.TagTables.CreateFrom(item);
                    Console.Write("done!\r\n");
                }

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // Console.Write("Copying tag table " + item.Name + "...");
                // Console.Write("done!\r\n");
                System.Threading.Thread.Sleep(10);


                #endregion
                #region CopyTypes



                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find folder Types --> "Blocks"
                // copy all Elements from that folder inside the PLC blocks
                // use both outlined program rows for debugging --> which block is currently getting copied?
                // de:
                // Ordner Typen --> "Blocks" suchen
                LibraryTypeFolder MyTypesFolder = MyLib.TypeFolder.Folders.Find("Blocks");
                foreach (LibraryType item in MyTypesFolder.Types)
                {
                    Console.Write("Copying type " + item.Name + "...");
                    MyPLCSoftware.BlockGroup.Blocks.CreateFrom((CodeBlockLibraryTypeVersion)item.Versions.Last());
                    Console.Write("done!\r\n");
                }
                // alle Elemente in diesem Ordner in die PLC Blocks kopieren
                // beide auskommentierte Zeilen Console.Write zum Debugging nutzen --> welcher Block wird gerade kopiert?
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // Console.Write("Copying type " + item.Name + "...");
                // Console.Write("done!\r\n");



                #endregion
                #region GetHmiTarget
                Console.Write("Getting HMI SW Container...\r\n");
                //Durch die einzelnen gesteckten Elemente der Station
                HmiTarget MyTouchpanelHmiTarget = null;
                DeviceItem MyTouchpanel_RT_Module = null;
                foreach (DeviceItem LoopDevItem in MyTouchpanel.DeviceItems)
                {
                    Console.Write("\t" + LoopDevItem.Name+"\r\n");
                    SoftwareContainer MySoftwareContainer = ((IEngineeringServiceProvider)LoopDevItem).GetService<SoftwareContainer>();
                    if (MySoftwareContainer != null)
                    {
                        // ++++++++++++++++++++++++++++++++++
                        // ++++++++++++++++++++++++++++++++++
                        // TODO:
                        // en:
                        // Software-Container was found --> get the HmiTarget from it
                        // de:
                        // Software-Container wurde gefunden --> daraus die HmiTarget ermitteln
                        MyTouchpanelHmiTarget = MySoftwareContainer.Software as HmiTarget;
                        MyTouchpanel_RT_Module = LoopDevItem;
                        // ++++++++++++++++++++++++++++++++++
                        // ++++++++++++++++++++++++++++++++++
                        break;
                    }
                    
                }
                Console.Write("done!\r\n");
                #endregion
                #region CopyScreen




                LibraryTypeFolder myHMITypesFolder = MyLib.TypeFolder.Folders.Find("Screens");
                foreach (ScreenLibraryType LoopItem in myHMITypesFolder.Types)
                {
                    Console.Write("Copying screen " + LoopItem.Name + " from Type'...");
                    // ++++++++++++++++++++++++++++++++++
                    // ++++++++++++++++++++++++++++++++++
                    // TODO:
                    // en:
                    // Insert screen type in HmiTarget
                    // de:
                    // Bildertyp in HmiTarget einfügen
                    LibraryTypeFolder MyScreenFolder = MyLib.TypeFolder.Folders.Find("Screens");
                    LibraryTypeVersion MyLibraryTypeVersion = MyScreenFolder.Types.Find("Conveyor").Versions.Last();
                    MyTouchpanelHmiTarget.ScreenFolder.Screens.CreateFrom((ScreenLibraryTypeVersion)MyLibraryTypeVersion);
                        
                    // ++++++++++++++++++++++++++++++++++
                    // ++++++++++++++++++++++++++++++++++
                    Console.Write("done!\r\n");
                }



                #endregion



                #region ConsoleWriting



                //-----------------------------
                Console.WriteLine("xxxxxxx End Section Copy xxxxxxx");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("xxxxxxx Section HWAdjustment xxxxxxx");
                #endregion


                #endregion
            }

            #region ExceptionHandling

            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please press Enter to close the Program");
                Console.ReadLine();
                return;
            }

            #endregion
        }

        #region Delegates

        private static void PreConfigureDownload(DownloadConfiguration downloadConfiguration)
        {
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
            // TODO:
            // en: 
            // Start a real download to check which messages come up
            // implement the data types
            // de: 
            // Durch einen echten Download prüfen, welche Meldungen bei der CPU auftreten
            // Die entsprechenden Datentypen implementieren
            AllBlocksDownload MYAllBlockDownload = downloadConfiguration as AllBlocksDownload;
            if (MYAllBlockDownload != null)
            {
                MYAllBlockDownload.CurrentSelection = AllBlocksDownloadSelections.DownloadAllBlocks;
            }
            AlarmTextLibrariesDownload MyAlarmDownload = downloadConfiguration as AlarmTextLibrariesDownload;
            if (MyAlarmDownload != null)
            {
                MyAlarmDownload.CurrentSelection = AlarmTextLibrariesDownloadSelections.ConsistentDownload;
            }
            StopModules MyStopModules = downloadConfiguration as StopModules;
            if (MyStopModules!=null)
            {
                MyStopModules.CurrentSelection = StopModulesSelections.StopAll;
            }            
            OverwriteTargetLanguages MyOverwriteTargetLanguages = downloadConfiguration as OverwriteTargetLanguages;
            if (MyOverwriteTargetLanguages != null)
            {
                MyOverwriteTargetLanguages.Checked = true;
            }
            ResetModule MyResetModule = downloadConfiguration as ResetModule;
            if (MyResetModule !=null)
            {
                MyResetModule.CurrentSelection = ResetModuleSelections.DeleteAll;
            }
            UpgradeTargetDevice MyUpgradeTargetDevice = downloadConfiguration as UpgradeTargetDevice;
            if (MyUpgradeTargetDevice!=null)
            {
                MyUpgradeTargetDevice.Checked = true;
            }
            OverwriteSystemData MyOverwriteSystemData = downloadConfiguration as OverwriteSystemData;
            if (MyOverwriteSystemData != null)
            {
                MyOverwriteSystemData.CurrentSelection = OverwriteSystemDataSelections.Overwrite;
            }
            ConsistentBlocksDownload MyConsistentBlocksDownload = downloadConfiguration as ConsistentBlocksDownload;
            if (MyConsistentBlocksDownload != null)
            {
                MyConsistentBlocksDownload.CurrentSelection = ConsistentBlocksDownloadSelections.ConsistentDownload;
            }
            DifferentTargetConfiguration MyDifferentTargetConfiguration = downloadConfiguration as DifferentTargetConfiguration;
            if (MyDifferentTargetConfiguration != null)
            {
                MyDifferentTargetConfiguration.CurrentSelection = DifferentTargetConfigurationSelections.AcceptAll;
            }
            OverwriteHmiData MyOverwriteHmiData = downloadConfiguration as OverwriteHmiData;
            if (MyOverwriteHmiData != null)
            {
                MyOverwriteHmiData.Checked = true;
            }
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
        }


        private static void PostConfigureDownload(DownloadConfiguration downloadConfiguration)

        {


            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
            // TODO:
            // en: 
            // Start a real download to check which messages come up
            // implement the data types
            // de: 
            // Durch einen echten Download prüfen, welche Meldungen bei der CPU auftreten
            // Die entsprechenden Datentypen implementieren
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
            StartModules MyStartModules = downloadConfiguration as StartModules;
            if (MyStartModules !=null)
            {
                MyStartModules.CurrentSelection = StartModulesSelections.StartModule;
            }
        }

        #endregion
    }
}
