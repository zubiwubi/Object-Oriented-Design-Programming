class OverviewlogicSeats : MenuOptionSelect
{
    protected override List<string> Options {get; set;} = new List<string>() {"Zaal 1", "Zaal 2", "Zaal 3"};

    private MakeMapLogic logic = new MakeMapLogic();
    public int[] auditorium1 = [8, 10, 10, 12, 12, 12, 12, 12, 12, 12, 12, 10, 8, 8 ];
    public int[] auditorium2 = [16, 16, 16, 16, 16, 16, 18, 18, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12];
    public int[] auditorium3 = [22, 24, 24, 24, 24, 26, 28, 30, 30, 30, 30, 30, 28, 26, 26, 24, 24, 20, 16, 14];

    public override void Render()
    {
        int selectedOption = MenuRenderer(Options);

        switch (selectedOption)
        {
            case 0:
                Console.WriteLine();
                char[,] aud1 = logic.DrawAuditorium(auditorium1);
                logic.PrintAuditorium("Auditorium 1", aud1);
                Console.WriteLine();
                break;

            case 1:
                char[,] aud2 = logic.DrawAuditorium(auditorium2);
                logic.PrintAuditorium("Auditorium 2", aud2);
                Console.WriteLine();
                break;

            case 2:
                char[,] aud3 = logic.DrawAuditorium(auditorium3);
                logic.PrintAuditorium("Auditorium 3", aud3);
                Console.WriteLine();
                break;
        }
    }
}