class OverviewMapsSeats : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>() { "Zaal 1", "Zaal 2", "Zaal 3" };

    private DrawMap _drawMap = new();
    public int[] auditorium1 = [8, 10, 10, 12, 12, 12, 12, 12, 12, 12, 12, 10, 8, 8];
    public int[] auditorium2 = [16, 16, 16, 16, 16, 16, 18, 18, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12];
    public int[] auditorium3 = [22, 24, 24, 24, 24, 26, 28, 30, 30, 30, 30, 30, 28, 26, 26, 24, 24, 20, 16, 14];

    public override void Render()
    {
        int selectedOption = MenuRenderer(Options);
        switch (selectedOption)
        {
            case 0:
                Console.WriteLine();
                char[,] aud1 = _drawMap.DrawAuditorium(auditorium1);
                _drawMap.PrintAuditorium("Zaal 1", aud1);
                Console.WriteLine();
                Console.WriteLine("════════════════");
                Console.WriteLine("│    SCHERM    │");
                Console.WriteLine("════════════════");
                Console.WriteLine();
                Console.WriteLine("Aantal stoelen: 150");
                Console.WriteLine("Tier 1:         9.99 euro");
                Console.WriteLine("Tier 2:         29.99 euro");
                Console.WriteLine("Tier 3:         38.99 euro");
                Console.WriteLine("Technolgie:     IMAX, Dolby Sounds-System");

                // readkey to pause the screen
                Console.WriteLine("\nDruk op Enter om verder te gaan.");
                Console.ReadKey();
                break;

            case 1:
                char[,] aud2 = _drawMap.DrawAuditorium(auditorium2);
                _drawMap.PrintAuditorium("Zaal 2", aud2);
                Console.WriteLine();
                Console.WriteLine("════════════════");
                Console.WriteLine("│    SCHERM    │");
                Console.WriteLine("════════════════");
                Console.WriteLine();
                Console.WriteLine("Aantal stoelen: 300");
                Console.WriteLine("Tier 1:         9.99 euro");
                Console.WriteLine("Tier 2:         29.99 euro");
                Console.WriteLine("Tier 3:         38.99 euro");
                Console.WriteLine("Technolgie:     IMAX 3D digitaal gecertificeerd viseel projectoren\n\t\tDolby Sounds-System");
                // readkey to pause the screen
                Console.WriteLine("\nDruk op Enter om verder te gaan.");
                Console.ReadKey();
                break;


            case 2:
                char[,] aud3 = _drawMap.DrawAuditorium(auditorium3);
                _drawMap.PrintAuditorium("Zaal 3", aud3);
                Console.WriteLine();
                Console.WriteLine("════════════════");
                Console.WriteLine("│    SCHERM    │");
                Console.WriteLine("════════════════");
                Console.WriteLine();
                Console.WriteLine("Aantal stoelen: 500");
                Console.WriteLine("Tier 1:         9.99 euro");
                Console.WriteLine("Tier 2:         29.99 euro");
                Console.WriteLine("Tier 3:         38.99 euro");
                Console.WriteLine("Technologie:    IMAX 3D digitaal gecertificeerd viseel projectoren.\n\t\tAuro 3D-gecertificeerd bioscoopgeluidssysteem\n\t\tSupercomfortabele VIP-stoelen met veel beenruimte en ruime afstand tussen de stoelen.");

                // readkey to pause the screen
                Console.WriteLine("\nDruk op Enter om verder te gaan.");
                Console.ReadKey();
                break;

        }
    }
}