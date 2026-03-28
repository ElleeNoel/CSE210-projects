public class Inventory
{
    List<string> items = new List<string>();

    public Inventory()
    {
        // in a full version this would import the info from a save file, but for now we'll
        // set it to a default
        items.Add("Bubblegum");
        items.Add("Bubblegum");
        items.Add("Timestream Syrup");
        items.Add("Bubblegum");
        items.Add("Bubblegum");
        items.Add("Timestream Syrup");
        items.Add("Bubblegum");
        items.Add("Timestream Syrup");
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
            if (selectedItem == item)
            {
                // can break loop then return, or return from loop
                items.Remove(item);
                if (selectedItem == "Bubblegum")
                {
                    statIncrease =  5;
                    break;
                }
                else
                {
                    statIncrease =  3;
                    break;
                }
            }
        }
        return statIncrease;
    }
}