
using PrisonerSim;
using System;
using System.Runtime.CompilerServices;

const float SIMULATIONS_TO_RUN = 100000;
const float DIVIDEND = SIMULATIONS_TO_RUN / 100;

Console.Clear();

int executions = 0;
int releases = 0;

for (int simulation = 0; simulation < SIMULATIONS_TO_RUN; simulation++)
{
    Boolean executed = RunPrisonerSimulation();

    if(executed)
    {
        executions++;
    }
    else
    {
        releases++;
    }
    //ConsoleUtility.WriteProgressBar((int)(simulation / DIVIDEND), true);
}
Console.WriteLine();
Console.WriteLine("Release Count: {0}, Percentage: {1}", releases, (releases/ SIMULATIONS_TO_RUN));
Console.WriteLine("Executions Count: {0}, Percentage: {1}", executions, (executions/ SIMULATIONS_TO_RUN));





public static partial class Program
{
    public static int[] CreatePopulatedArray()
    {
        int[] arr = new int[100];
        for (int i = 0; i < 100; i++)
        {
            arr[i] = i;
        }
        return arr;
    }

    public static int[] CreateRandomPopulatedArray()
    {
        int[] arr = CreatePopulatedArray();
        Random rand = new Random();
        int temp;
        int swapIndex;
        for (int loops = 0; loops < 20; loops++)
        {
            for (int i = 0; i < 100; i++)
            {
                swapIndex = rand.Next(100);
                temp = arr[i];
                arr[i] = arr[swapIndex];
                arr[swapIndex] = temp;
            }
        }

        return arr;
    }

    public static Boolean RunPrisonerSimulation()
    {
        int[] boxes = CreateRandomPopulatedArray();

        // Initialize Execution to False
        Boolean beginExecution = false;

        // Loop through all Prisoners
        for (int prisonerNumber = 0; prisonerNumber < 100; prisonerNumber++)
        {
            Boolean found = false;

            // Open First Box (Set Slip number and attempts to 1)
            int slip = boxes[prisonerNumber];
            int boxOpenAttempts = 1;
            
            // Loop through opening boxes
            while (boxOpenAttempts <= 50)
            {
                // Check if Slip # is same as Prisoner number
                if (slip == prisonerNumber)
                {
                    found = true;
                    break;  // Number found
                }

                // Open next box
                slip = boxes[slip];
                boxOpenAttempts++;
            }

            // If slip is not found begin execution (no need to process other prisoners)
            if (!found)
            {
                beginExecution = true; 
                break;
            }
        }

        return beginExecution;

    }
}
