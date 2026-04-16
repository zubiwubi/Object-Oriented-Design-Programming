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

                string info1 =
                    "\nTotal seats:       150\n" +
                    "Basic ticket:      € 9.99\n" +
                    "Standard ticket:   €29.99\n" +
                    "Premium ticket:    €38.99\n" +
                    "Technology:        IMAX, Dolby Sounds-System";
                    
                string screen1 =
                "            ════════════════\n" +
                "            │    SCREEN    │\n" +
                "            ════════════════";
                
                // seats bekijken op de map
                _drawMap.StartPosition(aud1);
                _drawMap.SeatSelection(aud1, "Auditorium 1", info1, screen1);

                Console.ReadKey();      // readkey to pause the screen
                break;

            case 1:
                char[,] aud2 = _drawMap.DrawAuditorium(auditorium2);

                string info2 =
                    "Aantal stoelen:    300\n" +
                    "Basic ticket:      € 9.99\n" +
                    "Standard ticket:   €29.99\n" +
                    "Premium ticket:    €38.99\n" +
                    "Technology:        IMAX 3D Digitalgecertificeerd viseel projectoren\n\t\tDolby Sounds-System";
                
                string screen2 = 
                "                  ════════════════\n" +
                "                  │    SCREEN    │\n" +
                "                  ════════════════";

                // seats bekijken op de map
                _drawMap.StartPosition(aud2);
                _drawMap.SeatSelection(aud2, "Auditorium 2", info2, screen2);

                Console.ReadKey();      // readkey to pause the screen
                break;


            case 2:
                char[,] aud3 = _drawMap.DrawAuditorium(auditorium3);

                string info3 =
                    "Aantal stoelen:    500\n" +
                    "Basic ticket:      € 9.99\n" +
                    "Standard ticket:   €29.99\n" +
                    "Premium ticket:    €38.99\n" +
                    "Technology:        IMAX 3D digitaal gecertificeerd viseel projectoren.\n\t\tAuro 3D-gecertificeerd bioscoopgeluidssysteem\n\t\tSupercomfortabele VIP-stoelen met veel beenruimte en ruime afstand tussen de stoelen";

                string screen3 =
                "                                    ════════════════\n" +
                "                                    │    SCREEN    │\n" +
                "                                    ════════════════";
                
                // seats bekijken op de map
                _drawMap.StartPosition(aud3);
                _drawMap.SeatSelection(aud3, "Auditorium 3", info3, screen3);

                Console.ReadKey();      // readkey to pause the screen
                break;

        }
    }
}