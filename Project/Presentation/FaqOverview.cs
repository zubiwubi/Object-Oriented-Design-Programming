class FaqOverview : MenuOptionSelect
{
    //fields
    protected override List<string> Options { get; set; } = new List<string>() { "FAQ", "About us", "Contact", "Adress information", "Return to homepage" };


    //constructor (niet nodig)

    //methods
    public void Render()//public = elke class kan er bij void. = returnt niks. render is naam van de method
    {
        Console.Clear(); // ingebouwde functie cleared alles wat op je scherm staat

        while (true)// zo lang de conditie true is gaan we code binnen in de body uitvoeren
        {
            int selectedOption = MenuRenderer(Options); //getal 

            switch (selectedOption)
            {
                case 0: // ------------ FAQ -------------
                    //type code here 
                    Console.WriteLine("FAQ. press something to continue");
                    Console.ReadKey();

                    break;
                case 1: // ------------ About us -------------
                    // codehere
                    Console.WriteLine("About us. press. something to continue");
                    Console.ReadKey();

                    break;
                case 2: // ------------ Contact -------------
                    //code here
                    Console.WriteLine("Conact. press something to continue");
                    Console.ReadKey();

                    break;
                case 3: // ------------ Adress information -------------
                    //code here
                    Console.WriteLine("Adress info. press something to continue");
                    Console.ReadKey();
                    break;
                case 4: // ------------ Return to homepage -------------
                    return;//haalt je uit elke loop. handig voor void methods
            }
        }
    }
}

// static betekent dat er geen instances van komen
