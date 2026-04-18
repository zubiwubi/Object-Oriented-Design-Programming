public interface IPage
{
    static ConsoleKeyInfo Key { get; set; }
    static int Arrow { get; set; }
    static int MenuChoice { get; set; }
    static bool IsOptionSelected { get; set; }
    static List<string> Menu {get; set;} = new(); 
}