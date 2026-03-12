using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
        // main will run a menu in a loop as in other projects
        // instantiate goal subclasses as needed
        string menuInput = "";
        List<string> saveFormatGoals = new List<string>();
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;
        string rank;
        while (menuInput != "6")
        {
            // this ranking system is extra, just fyi
            if (totalScore >= 10000)
            {
                rank =  "the ultimate goal master";
            }
            else if (totalScore >= 5000)
            {
                rank = "the chosen one";
            }
            else if (totalScore >= 2000)
            {
                rank = "hero";
            }
            else if (totalScore >= 500)
            {
                rank = "journeyman";
            }
            else if (totalScore >= 100)
            {
                rank = "getting there";
            }
            else
            {
                rank = "noob";
            }
            Console.WriteLine();
            Console.WriteLine($"You have {totalScore} total points. Your rank is {rank}.");
            Console.WriteLine();
            
            Console.WriteLine("Menu options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            menuInput = Console.ReadLine();
            // now a ton of if statements
            if (menuInput == "1")
            {
               Console.WriteLine();
               Console.WriteLine("The types of goals you can set are: ");
               Console.WriteLine("  1. Simple Goal");
               Console.WriteLine("  2. Eternal Goal");
               Console.WriteLine("  3. Multi-Step Goal");
               Console.Write("Which type of goal would you like to create? ");
               string goalTypeSelect = Console.ReadLine();
               if (goalTypeSelect == "1")
                {
                    Console.Write("What is the name of your goal? ");
                    string goalName = Console.ReadLine();
                    Console.Write("Please enter a short description of your goal: ");
                    string goalDescription = Console.ReadLine();
                    Console.Write("How many points is this goal worth? ");
                    string strPoints = Console.ReadLine();
                    int points = int.Parse(strPoints);
                    // now to actually make one finally
                    OneTimeGoal simpleGoal = new OneTimeGoal(goalName, goalDescription, points);
                    saveFormatGoals.Add(simpleGoal.FormatGoalToSave());
                    goals.Add(simpleGoal);
                }
                else if (goalTypeSelect == "2")
                {
                    Console.Write("What is the name of your goal? ");
                    string goalName = Console.ReadLine();
                    Console.Write("Please enter a short description of your goal: ");
                    string goalDescription = Console.ReadLine();
                    Console.Write("How many points is this goal worth? ");
                    string strPoints = Console.ReadLine();
                    int points = int.Parse(strPoints);
                    
                    EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, points);
                    saveFormatGoals.Add(eternalGoal.FormatGoalToSave());
                    goals.Add(eternalGoal);
                }
                else if (goalTypeSelect == "3")
                {
                    Console.Write("What is the name of your goal? ");
                    string goalName = Console.ReadLine();
                    Console.Write("Please enter a short description of your goal: ");
                    string goalDescription = Console.ReadLine();
                    Console.Write("How many times do you want to complete this goal? ");
                    string targetNumber = Console.ReadLine();
                    int goalTimes = int.Parse(targetNumber);
                    Console.Write("How many points is this goal worth each time you complete it? ");
                    string strPoints = Console.ReadLine();
                    int points = int.Parse(strPoints);
                    Console.Write("How many points is your bonus for finishing this goal? ");
                    string strBonus = Console.ReadLine();
                    int bonus = int.Parse(strBonus);
                    
                    MultiStepGoal multiGoal = new MultiStepGoal(goalName, goalDescription, bonus, points, goalTimes);
                    saveFormatGoals.Add(multiGoal.FormatGoalToSave());
                    goals.Add(multiGoal);
                }
            }
            else if (menuInput == "2")
            {
                Console.WriteLine("Your goals are: ");
                int goalNum = 1;
                foreach (Goal goal in goals)
                {
                    Console.Write($"{goalNum}. ");
                    goal.PrintGoal();
                    goalNum ++;
                }
            }
            else if (menuInput == "3")
            {
               Console.Write("What file name would you like to use to save your goals? ");
               string fileName = Console.ReadLine();
               using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    outputFile.WriteLine(totalScore);
                    foreach (string goal in saveFormatGoals)
                    {
                        outputFile.WriteLine(goal);
                    }
                } 
            }
            else if (menuInput == "4")
            {
                Console.Write("What is the name of te file to load? ");
                string fileName = Console.ReadLine();
                string [] lines = System.IO.File.ReadAllLines(fileName);
                // don't forget to find how to make it do something different with line 1
                foreach (string line in lines)
                {
                    string[] parts = line.Split(";");

                    string goalType = parts[0];
                    // think I need to check the type here, there aren't enough indexes in all of them otherwise
                    if (goalType == "EternalGoal")
                    {
                    string goalName = parts[1];
                    string goalDescription = parts[2];
                    string value = parts[3];
                    int goalPoints = int.Parse(value);
                    EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                    goals.Add(eternalGoal);
                    saveFormatGoals.Add(eternalGoal.FormatGoalToSave());
                    }
                    else if (goalType == "OneTimeGoal")
                    {
                        string goalName = parts[1];
                        string goalDescription = parts[2];
                        string value = parts[3];
                        int goalPoints = int.Parse(value);
                        string status = parts[4];
                        OneTimeGoal oneTimeGoal = new OneTimeGoal(goalName, goalDescription, goalPoints, status);
                        goals.Add(oneTimeGoal);
                        saveFormatGoals.Add(oneTimeGoal.FormatGoalToSave());
                    }
                    else if (goalType == "MultiStepGoal")
                    {
                        string goalName = parts[1];
                        string goalDescription = parts[2];
                        string value = parts[3];
                        int goalPoints = int.Parse(value);
                        //string status = parts[4]; 
                        // don't forget you still need to have a status, it just won't be a parameter
                        string compBonus = parts[4];
                        int completeBonus = int.Parse(compBonus);
                        string strToComplete = parts[5];
                        int toComplete = int.Parse(strToComplete);
                        string strDone = parts[6];
                        int TimesDone = int.Parse(strDone);
                        MultiStepGoal multiStepGoal = new MultiStepGoal(goalName, goalDescription, completeBonus, goalPoints, toComplete, TimesDone);
                        goals.Add(multiStepGoal);
                        saveFormatGoals.Add(multiStepGoal.FormatGoalToSave());
                    }

                }
            }
            else if (menuInput == "5")
            {
                Console.WriteLine("Your goals are: ");
                int goalNum = 1;
                foreach (Goal goal in goals)
                {
                    Console.Write($"{goalNum}. ");
                    goal.PrintGoal();
                    goalNum ++;
                }
                Console.Write("Which goal did you accomplish? ");
                string recGoalNumber = Console.ReadLine();
                int goalNumber = int.Parse(recGoalNumber);
                Goal goalToUpdate = goals[(goalNumber-1)];
                int points = goalToUpdate.RecordGoal();
                totalScore += points;
                Console.WriteLine($"Congratulations! You got {points} points!");
            }           
                
      
    }
}

}
