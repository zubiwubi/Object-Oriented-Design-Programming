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
                    Console.WriteLine(@"
                    FAQ - Press any key to continue

                    Q: How do I order tickets?
                    A: Via the website or the app.

                    Q: When are the opening hours?
                    A: Monday to Saturday 8AM to 11PM, Sunday 12PM to 10PM
                    
                    Q: What does your Club membership subcription card do?
                    A: A loyalty program where you earn points and get discounts on tickets and snacks.
                    
                    Q:What are the benefits from joining Club?
                    A: Unlimited films per month depending on your plan, starting from €19,99/month.
                    
                    
                    Q: Which methods of travel are avaliable to reach the cinema?
                    A: Tram, metro, bus. Bike and car parking is avaliable too with an underground parking area.
                    ");



                    Console.ReadKey();

                    break;
                case 1: // ------------ About us -------------
                    // codehere
                    Console.WriteLine(@"
                        Welcome to Rotterdam Cinema, your home for the ultimate movie experience.
    
                    Founded in 1998, we've grown from a single screen to a modern multi-screen
                    cinema welcoming over half a million visitors each year.
                    
                    We offer the latest blockbusters, indie films, and international cinema 
                    on premium screens with Dolby Atmos sound and comfortable reclining seats.
                    
                    Our mission is simple: a great film deserves a great audience. 
                    
                    Thank you for choosing Rotterdam Cinema!
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    ");
                    Console.ReadKey();

                    break;
                case 2: // ------------ Contact -------------
                    //code here
                    Console.WriteLine(@"
                    
                    Rotterdam Cinema

                    Phone: 0900-2357284
                    Website: 010Cinema.nl
                    
                    ");
                    Console.ReadKey();

                    break;
                case 3: // ------------ Adress information -------------
                    //code here
                    Console.WriteLine(@"
                    Schouwburgplein 101, 3012 CL Rotterdam
                    ");
                    Console.ReadKey();
                    break;
                case 4: // ------------ Return to homepage -------------
                    return;//haalt je uit elke loop. handig voor void methods
            }
        }
    }
}

// static betekent dat er geen instances van komen
