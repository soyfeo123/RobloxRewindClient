using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RobloxRewindClient
{
    internal class Program
    {
        

        static void DrawMainScreen()
        {
            Console.WriteLine(@"
  _____       _     _           _____               _           _ 
 |  __ \     | |   | |         |  __ \             (_)         | |
 | |__) |___ | |__ | | _____  _| |__) |_____      ___ _ __   __| |      /  /
 |  _  // _ \| '_ \| |/ _ \ \/ /  _  // _ \ \ /\ / / | '_ \ / _` |     /__/__________
 | | \ \ (_) | |_) | | (_) >  <| | \ \  __/\ V  V /| | | | | (_| |     \  \
 |_|  \_\___/|_.__/|_|\___/_/\_\_|  \_\___| \_/\_/ |_|_| |_|\__,_|      \  \
                                                                  
  
(thanks for the name chatgpt)

Select an option!

1) Bring back the old OOF sfx
2) Replace new cursor with old cursor
3) Revert new volume slider sfx
4) Revert new topbar

5) Cancel
");
        }

        static void Main(string[] args)
        {
            DrawMainScreen();
            Console.Write("\nYour option: ");
            
            string selectedMode = Console.ReadLine();
            Console.WriteLine();
            string robloxClientPath = FindNewestRobloxClient();
            Console.WriteLine();
            if (selectedMode == "1")
            {
                

                Console.WriteLine("Replacing ouch.ogg with ouch.ogg...");
                Console.WriteLine("Current directory: " + AppDomain.CurrentDomain.BaseDirectory);
                Console.WriteLine("Renaming ouch.ogg from Roblox to ouch_new.ogg");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "sounds", "ouch.ogg"), "ouch_new.ogg");
                Console.WriteLine("\nGetting new sound...");
                Console.WriteLine("Copying to " + robloxClientPath);
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "ouch.ogg"), Path.Combine(robloxClientPath, "content", "sounds", "ouch.ogg"));
                Console.WriteLine("\nFinished applying changes!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            if(selectedMode == "2")
            {
                Console.WriteLine("Creating backup of new cursors...");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "ArrowFarCursor.png"), "ArrowFarCursor_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "ArrowCursor.png"), "ArrowCursor_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "IBeamCursor.png"), "IBeamCursor_new.png");
                Console.WriteLine("\nCopying cursors...");
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ArrowCursor.png"), Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "ArrowCursor.png"));
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ArrowCursor.png"), Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "IBeamCursor.png"));
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ArrowFarCursor.png"), Path.Combine(robloxClientPath, "content", "textures", "Cursors", "KeyboardMouse", "ArrowFarCursor.png"));
                Console.WriteLine("\nCompleted operation!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            if(selectedMode == "3")
            {
                Console.WriteLine("Creating backup of new volume slider SFX...");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "sounds", "volume_slider.ogg"), "volume_slider_new.ogg");
                Console.WriteLine("\nDuplicating ouch.ogg...");
                File.Copy(Path.Combine(robloxClientPath, "content", "sounds", "ouch.ogg"), Path.Combine(robloxClientPath, "content", "sounds", "volume_slider.ogg"));
                Console.WriteLine("\nCompleted operation!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(); 
            }

            if(selectedMode == "4")
            {
                Console.WriteLine("Creating backup of assets...");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "coloredlogo.png"), "coloredlogo_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "chatOff.png"), "chatOff_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "chatOn.png"), "chatOn_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "close.png"), "close_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "close@2x.png"), "close@2x_new.png");
                Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "iconBase.png"), "iconBase_new.png");
                Console.WriteLine("\nRemoving button background...");
                File.Delete(Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "iconBase.png"));
                Console.WriteLine("\nReplacing chat buttons...");
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ui", "Chat", "Chat.png"), Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "chatOff.png"));
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ui", "Chat", "ChatDown.png"), Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "chatOn.png"));
                Console.WriteLine("\nReplacing menu buttons...");
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ui", "Menu", "Hamburger.png"), Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "coloredlogo.png"));
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ui", "Menu", "HamburgerDown.png"), Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "close.png"));
                File.Copy(Path.Combine(robloxClientPath, "content", "textures", "ui", "Menu", "HamburgerDown.png"), Path.Combine(robloxClientPath, "content", "textures", "ui", "TopBar", "close@2x.png"));

                Console.WriteLine("\nCompleted operation!\nPress any key to exit.");
                Console.ReadKey();
            }
        }

        /*
         FEATURES TO DO

        replace stuff in textures/ui/TopBar/chatOff.png to textures/ui/Chat/Chat.png
        replace stuff in textures/ui/TopBar/chatOn.png to textures/ui/Chat/ChatDown.png
        replace stuff in textures/ui/TopBar/coloredLogo.pmg to textures/ui/Menu/Hamburger.png
        replace stuff in textures/ui/TopBar/close.png to textures/ui/Menu/HamburgerDown.png
        replace stuff in sounds/ouch
        replace cursor
         */

        static string FindNewestRobloxClient()
        {
            Console.WriteLine("Finding current roblox version...");
            string robloxPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox", "Versions");

            string[] versions = Directory.GetDirectories(robloxPath);

            foreach(string version in versions)
            {
                if(File.Exists(Path.Combine(version, "RobloxPlayerLauncher.exe")))
                {
                    Console.WriteLine("Found version: " + version);
                    return version;
                }
            }
            Console.WriteLine("Roblox not found! Try installing Roblox.");
            return null;
        }
    }
}
