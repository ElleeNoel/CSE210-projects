public class Inventory
{
    List<string> items = new List<string>();

    public Inventory()
    {
        // in a full version this would import the info from a save file, but for now we'll
        // set it to a default
        items.Add("BUBBLEGUM");
        items.Add("BUBBLEGUM");
        items.Add("TIMESTREAM SYRUP");
        items.Add("BUBBLEGUM");
        items.Add("BUBBLEGUM");
        items.Add("TIMESTREAM SYRUP");
        items.Add("BUBBLEGUM");
        items.Add("TIMESTREAM SYRUP");
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Inventory:");
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }
    }
    public int UseItem(string selectedItem)
    {
        int statIncrease = 0;
        foreach (string item in items)
        {
            if (selectedItem.ToUpper() == item)
            {
                // can break loop then return, or return from loop
                items.Remove(item);
                if (selectedItem.ToUpper() == "BUBBLEGUM")
                {
                    statIncrease =  5;
                    Console.WriteLine("You recoverd 5 HP!");
                    break;
                }
                else
                {
                    statIncrease =  3;
                    Console.WriteLine("You recovered 3 MP!");
                    break;
                }
            }
        }
        return statIncrease;
    }
}