public class AdminManageMerchandise
{
    public static void StartPage()
    {
        Console.WriteLine(@$"

  __  __                                                  
 |  \/  | __ _ _ __   __ _  __ _  ___                     
 | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \                    
 | |  | | (_| | | | | (_| | (_| |  __/                    
 |_|  |_|\__,_|_| |_|\__,_|\__, |\___|       _ _          
 |  \/  | ___ _ __ ___| |__|___/ _ _ __   __| (_)___  ___ 
 | |\/| |/ _ \ '__/ __| '_ \ / _` | '_ \ / _` | / __|/ _ \
 | |  | |  __/ | | (__| | | | (_| | | | | (_| | \__ \  __/
 |_|  |_|\___|_|  \___|_| |_|\__,_|_| |_|\__,_|_|___/\___|
                                                          
        
        ");


        Tools.ColorYellowMessage($"press 'BACKSPACE' to go back");
        Tools.ColorYellowMessage($"press 'ENTER' to continue");

    }
}