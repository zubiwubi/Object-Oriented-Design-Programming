public class StudentAccountLogic
{
    private static readonly List<string> SchoolDomains = new List<string>
    {
        "hr.nl",
        "student.hr.nl",
        "hu.nl",
        "student.hu.nl",
        "hva.nl",
        "student.hva.nl",
        "vu.nl",
        "uva.nl",
        "uu.nl",
        "ru.nl",
        "rug.nl",
        "utwente.nl",
        "student.utwente.nl",
        "tudelft.nl",
        "student.tudelft.nl",
        "tue.nl",
        "wur.nl",
        "ou.nl",
        "fontys.nl",
        "student.fontys.nl",
        "avans.nl",
        "student.avans.nl",
        "saxion.nl",
        "student.saxion.nl",
        "han.nl",
        "student.han.nl",
        "inholland.nl",
        "zuyd.nl",
        "windesheim.nl",
        "hsleiden.nl",
        "hhs.nl",
        "artez.nl",
        "codarts.nl",
        "buas.nl",
        "nhlstenden.com",
        "rocva.nl",
        "albeda.nl",
        "deltion.nl"
    };

    public bool IsSchoolEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        string domain = email.Split('@').Last().ToLower();

        return SchoolDomains.Any(d =>
            domain.Equals(d.ToLower()));
    }
}