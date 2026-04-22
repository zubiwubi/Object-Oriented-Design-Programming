class OverviewMapsSeats : MenuOptionSelect
{
    protected override List<string> Options { get; set; } = new List<string>() { "Auditorium 1", "Auditorium 2", "Auditorium 3" };

    public DrawMap DrawMap = new();
    public int[] auditorium1 = [8, 10, 10, 12, 12, 12, 12, 12, 12, 12, 12, 10, 8, 8];
    public int[] auditorium2 = [16, 16, 16, 16, 16, 16, 18, 18, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12];
    public int[] auditorium3 = [22, 24, 24, 24, 24, 26, 28, 30, 30, 30, 30, 30, 28, 26, 26, 24, 24, 20, 16, 14];

    public void Render(string caller = "", int locationId = 0)
    {
        if (locationId == 0)
        {
            int selectedOption = MenuRenderer(Options);
            switch (selectedOption)
            {
                case 0:
                    RenderAud1(caller);
                    break;

                case 1:
                    RenderAud2(caller);
                    break;


                case 2:
                    RenderAud3(caller);
                    break;

            }
        }
        else if (locationId == 1)
        {
            RenderAud1(caller);
        }
        else if (locationId == 2)
        {
            RenderAud2(caller);
        }
        else if (locationId == 3)
        {
            RenderAud3(caller);
        }
        else
        {
            Console.WriteLine("Wrong auditiorium ID");
            Thread.Sleep(3000);
            return;
        }
    }
    private void RenderAud1(string caller)
    {
        Console.WriteLine();
        char[,] aud1 = DrawMap.DrawAuditorium(auditorium1);

        string info1 =
            "Amount of seats    :    150\n" +
            "Basic ticket       :  € 9.99\n" +
            "Standard ticket    :  €29.99\n" +
            "Premium ticket     :  €38.99\n" +
            "Technology         :  IMAX, Dolby Sounds-System";

        string screen1 =
        "            ════════════════\n" +
        "            │    SCREEN    │\n" +
        "            ════════════════";

        // seats bekijken op de map
        DrawMap.StartPosition(aud1);
        DrawMap.SeatSelection(caller,aud1, "Auditorium 1", info1, screen1);

        Console.ReadKey();      // readkey to pause the screen
        return;
    }
    private void RenderAud2(string caller)
    {
        char[,] aud2 = DrawMap.DrawAuditorium(auditorium2);

        string info2 =
            "Amount of seats    :    300\n" +
            "Basic ticket       :  € 9.99\n" +
            "Standard ticket    :  €29.99\n" +
            "Premium ticket     :  €38.99\n" +
            "Technology         :  IMAX 3D digital certified visual projectors.\n\t\tDolby Sounds-System";

        string screen2 =
        "                  ════════════════\n" +
        "                  │    SCREEN    │\n" +
        "                  ════════════════";

        // seats bekijken op de map
        DrawMap.StartPosition(aud2);
        DrawMap.SeatSelection(caller,aud2, "Auditorium 2", info2, screen2);

        Console.ReadKey();      // readkey to pause the screen

        return;
    }
    private void RenderAud3(string caller)
    {
        char[,] aud3 = DrawMap.DrawAuditorium(auditorium3);

        string info3 =
            "Amount of seats    :    500\n" +
            "Basic ticket       :  € 9.99\n" +
            "Standard ticket    :  €29.99\n" +
            "Premium ticket     :  €38.99\n" +
            "Technology         :  IMAX 3D digital certified visual projectors.\n\t\tAuro 3D certified cinema sound system\n\t\tsuper comfortable (VIP) seats with plenty of legroom and space in between";

        string screen3 =
        "                                    ════════════════\n" +
        "                                    │    SCREEN    │\n" +
        "                                    ════════════════";

        // seats bekijken op de map
        DrawMap.StartPosition(aud3);
        DrawMap.SeatSelection(caller,aud3, "Auditorium 3", info3, screen3);

        Console.ReadKey();      // readkey to pause the screen
        return;
    }
}
