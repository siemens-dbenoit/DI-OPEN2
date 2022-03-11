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

                /*

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
                //Open TIA Portal 
                MyTiaPortalAsProcess = new TiaPortal(TiaPortalMode.WithUserInterface);
                Console.Write("done!\r\n");
                //--------------------------
                #endregion
                #region ProjectHandling
                //--------------------------
                //Create project
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
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // Console.Write("Copying tag table " + item.Name + "...");
                // Console.Write("done!\r\n");



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
                */

                #endregion

                #region skipChapter5

                // WORKAROUND SKIP CHAPTER5 => SAVE TIME
                var skipChapter5 = true;

                TiaPortalProcess MyTiaPortalInstance = null;
                TiaPortal MyTiaPortalAsProcess = null;

                Device MyCPU = null;
                DeviceItem MyPLCDeviceItem = null;

                Device MyET200SP = null;
                DeviceItem MyET200SPDeviceItem = null;

                Device MyTouchpanel = null;
                DeviceItem MyTouchpanelDeviceItem = null;

                if (skipChapter5)
                {
                    IList<TiaPortalProcess> MyRunningTias = TiaPortal.GetProcesses();
                    if (MyRunningTias.Count == 0) { return; }

                    MyTiaPortalInstance = MyRunningTias[0];
                    MyTiaPortalAsProcess = MyTiaPortalInstance.Attach();

                    MyProject = MyTiaPortalAsProcess.Projects.First();

                    MyCPU = MyProject.Devices.Find("S71500/ET200MP-Station_1");
                    MyPLCDeviceItem = MyCPU.DeviceItems.First(DI => DI.Name.Equals("PLC_1"));

                    MyET200SP = MyProject.Devices.Find("ET 200SP-Station_1");
                    MyET200SPDeviceItem = MyET200SP.DeviceItems.First(DI => DI.Name.Equals("ET200SP"));

                    MyTouchpanel = MyProject.Devices.Find("Touchpanel");
                    MyTouchpanelDeviceItem = MyTouchpanel.DeviceItems.First(DI => DI.Name.Equals("HMI_RT_1"));
                }

                #endregion

                #region Chapter6

                #region AdjustName



                Console.Write("Adjusting Name to S7-1500...");

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // change the name of the PLC to "S7-1500". For that, use the DeviceItem that represents the PLC
                // de:
                // Namen des Controllers anpassen. Dazu das DeviceItem, welches die CPU repräsentiert, nutzen
                // Neuer Name: "S7-1500"
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");




                #endregion
                #region IP_Address_CPU
                Console.Write("Setting IP-Address of CPU...");


                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find the network-Interface-submodule of the PLC
                // The Name is "PROFINET interface_1" (as default!)
                // Get the Network Interface service of this DeviceItem
                // Find the Node in the Network Interface
                // Change the attribute "Address" to "192.168.111.102"
                // Save the network that is connected to the node in a variable since it is needed later
                // de:
                // Netzwerk Interface-Submodul der CPU heraussuchen.
                // Name lautet "PROFINET interface_1" (als Standardname!)
                // Daraus das Netzwerk-Interface ermitteln
                // Im Netzwerk-Interface den Knoten "Node" ermitteln
                // Dort das Attribut "Address" auf "192.168.111.102" setzen
                // Das am Node angeschlossene Subnetz in eine Variable speichern, da später benötigt!
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++


                Console.Write("done!\r\n");
                #endregion
                #region IP_Address_ET200SP
                Console.Write("Setting IP-Address of ET200SP...");


                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // set the IP-Address of the ET200SP the same way
                // IP Address should be set to "192.168.111.104"
                // de:
                // IP-Adresse der ET200SP ebenfalls auf gleichem Weg setzen
                // Soll-IP-Adresse lautet "192.168.111.104"
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion
                #region IP_Address_TP
                Console.Write("Setting IP address of TP...");



                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Set IP-Address of the Touchpanel
                // Important: The IP address has to be set at the element called "Touchpanel".
                // The address shall be "192.168.111.200" after setting it.
                // But there are two of them - one for the rack where the TP is plugged and the second one that represents the Network interface
                // --> the second element found with the name "Touchpanel" is the correct!
                // de:
                // IP-Adresse des Touchpanels setzen
                // Wichtig: Die IP-Adresse muss am Element "Touchpanel" gesetzt werden. Aber nicht am Ersten Element, da dies das Rack ist
                // --> erst das Zweite mit dem Namen gefundene Element ist das korrekte!
                // Die IP-Adresse soll auf "192.168.111.200" gesetzt werden.
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion
                #region Create IO-System
                Console.Write("Creating IO-System...");




                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Find the IO-Controller of the CPU
                // If no IO-System is already there, create a new one.
                // Otherwise use the existing one.
                // de:
                // IO-Controller der CPU ermitteln
                // Wenn kein IO-System am IO-Controller hängt, ein IO-System erstellen
                // Wenn bereits ein IO-System existiert, dieses für die weitere Benutzung speichern
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion
                #region Connect ET200SP
                Console.Write("Assigning ET200SP to the IO-System of the CPU...");



                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Assign the ET200SP to the Subnet that is connected to the CPU
                // Get the IO-Connector of the ET200SP and connect it to the IO-System
                // de:
                // ET200SP an das Subnetz anschließen, welches an der CPU anliegt
                // IO-Connector der ET200SP ermitteln und diesen an das IO-System anschließen
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion
                #region Connect_TP
                Console.Write("Connecting Touchpanel to subnet...");


                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Connect the node of the Touchpanel to the subnet that is connected with the PLC
                // de:
                // Node des Touchpanels an das Subnetz anschließen, welches mit der CPU verbunden ist
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion

                
                #region ConsoleWriting
                Console.WriteLine("xxxxxxx End Section HWAdjustment xxxxxxx");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("xxxxxxx Section Finishing xxxxxxx");
                Console.Write("Saving Project...");
                MyProject.Save();
                Console.Write("done!\r\n");
                #endregion
                #region Compile_CPU
                Console.Write("Compiling CPU...");

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Get the Service "ICompilable" at the CPU
                // Call the Compile of the Service
                // Show Compile errors and compile warnings in the console
                // de:
                // Service ICompilable an der CPU abrufen
                // Compile des Service anstoßen
                // Compile-Fehler und Warnungen in die Konsole ausgeben
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++

                #endregion

                #region Compile_TP

                Console.Write("Compiling Touchpanel...");
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                //TODO:
                // en:
                // Get the service "ICompilable" at the HMI-RT (Data type "HmiRuntime"!) of the Touchpanel
                // Call Compile of the Service
                // Show the count of errors and warnings in the console
                // de:
                // Service ICompilable an der HMI-RT des Touchpanels abrufen
                // Compile des Service anstoßen
                // Anzahl der Fehler und Anzahl der Warnungen ausgeben
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                #endregion
                #region Download_CPU
                Console.Write("Downloading CPU...");

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Get Service "DownloadProvider" from the Controller Module
                // Create the IConfiguration for the Controller (PN/IE --> Intel(R) 82574L Gigabit Network Connection, 1 --> 1 X1)
                // Instanciate the Delegates
                // Write the delegates (Region "Delegates" at the end of this file)
                // Perform the download
                // de:
                // Service Download-Provider aus dem Controller-Module ermitteln
                // IConfiguration für den Controller ermitteln (PN/IE --> Intel(R) 82574L Gigabit Network Connection, 1 --> 1 X1)
                // Delegates instanziieren
                // Delegates schreiben (in der Region "delegates" am Ende dieser Datei)
                // Download durchführen
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++


                Console.Write("done!\r\n");

                #endregion
                #region Download_TP

                Console.Write("Downloading Touchpanel...");

                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++
                // TODO:
                // en:
                // Get the Service "DownloadProvider" from the Hmi-Runtime-Module
                // Create the correct IConfiguration (PN/IE --> Intel(R) 82574L Gigabit Network Connection, 1 --> 5 X1)
                // Perform the download
                // de:
                // Service Download-Provider aus dem HMI-Runtime-Modul ermitteln
                // IConfiguration für den Controller ermitteln (PN/IE --> Intel(R) 82574L Gigabit Network Connection, 1 --> 5 X1)
                // Download durchführen
                // ++++++++++++++++++++++++++++++++++
                // ++++++++++++++++++++++++++++++++++



                Console.Write("done!\r\n");
                #endregion

                #region Postpare
                Console.Write("Saving again...");
                MyProject.Save();
                Console.Write("done!\r\n");
                Console.Write("Disconnecting from TIA-Portal...");
                MyTiaPortalAsProcess.Dispose();
                Console.Write("done!\n\r");
                Console.WriteLine("Program ended at " + System.DateTime.UtcNow.ToLocalTime().ToString());
                Console.WriteLine("-------------------------------");
                //----------------------------------
                //Wait until user ends the program
                Console.WriteLine("Please press Enter to close the Program");
                Console.ReadLine();
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
            // Perform a real Download to the CPU and Touchpanel to find out which information messages appear
            // Implement the relevant solutions with the corresponding data types
            // de:
            // Durch einen echten Download prüfen, welche Meldungen bei der CPU auftreten
            // Die entsprechenden Datentypen implementieren
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
        }


        private static void PostConfigureDownload(DownloadConfiguration downloadConfiguration)

        {
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
            // TODO:
            // en:
            // Perform a real Download to the CPU and Touchpanel to find out which information messages appear
            // Implement the relevant solutions with the corresponding data types
            // de:
            // Durch einen echten Download prüfen, welche Meldungen bei der CPU auftreten
            // Die entsprechenden Datentypen implementieren
            // ++++++++++++++++++++++++++++++++++
            // ++++++++++++++++++++++++++++++++++
        }

        #endregion
    }
}
