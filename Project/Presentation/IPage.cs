public interface IPage
{
    ConsoleKeyInfo Key { get; set; }
    int Arrow { get; set; }
    int MenuChoice { get; set; }
    bool IsOptionSelected { get; set; }
}