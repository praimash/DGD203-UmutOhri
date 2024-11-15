using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
// I wanted to create a game which we can play in the console panale with basic commands and tried to add some sound effects and colors to it.
// i hope you like it !
//UMUT OHRİ-225040048-GAMEPROGRAMING1
namespace car;

class car
{
    private int oil = 100;
    private int speed;
    private bool engineOn = false;
    private int maxSpeed;
    private Random rand = new Random();




    public void chooseCar()
    {
        string carchoice = Console.ReadLine();


        if (carchoice == "1")
        {
            maxSpeed = 100;
            Console.WriteLine("-You choose sedan car! Your speed limit is 100. ");
        }
        else if (carchoice == "2")
        {
            maxSpeed = 150;
            Console.WriteLine("-You choose sport car! Your speed limit is 150. ");
        }
        else
        {
            maxSpeed = 100;
            Console.WriteLine("You made invalid choose, your car is sedan! Your speed limit is 100. ");
        }


    }



    public void randomObj()
    {
        int objChance = rand.Next(1, 3); // 1 veya 2
        Console.ForegroundColor = ConsoleColor.Green;

        string message = objChance == 1 ? "There is an obstacle, You should slow - PRESS SPACE -" :
                                          "There is an obstacle, You should slow - PRESS W -";
        Console.WriteLine(message);

        // Kullanıcıya 15 saniye süre tanıyoruz
        DateTime endTime = DateTime.Now.AddSeconds(4);
        ConsoleKey requiredKey = objChance == 1 ? ConsoleKey.Spacebar : ConsoleKey.W;

        bool isBraked = false;

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == requiredKey)
            {
                brake(); // Frenleme işlemi
                isBraked = true;
                break;
            }
        }

        if (!isBraked)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You could not break. Game Over !!");
            Environment.Exit(0);
        }
    }


    public void startEngine()
    {
        if (!engineOn)
        {
            engineOn = true;
            Console.Beep(1000, 500);
            Console.WriteLine("Engine is started!");
        }
        else
        {
            Console.WriteLine("Engine is already started.");
        }
    }
    public void stopEngine()
    {
        if (engineOn)
        {
            engineOn = false;
            Console.WriteLine("Engine is stoped!");
        }
        else
        {
            Console.WriteLine("Engine is already stoped.");
        }
    }

    public void getFast()
    {
        if (engineOn && speed < maxSpeed&& oil>0)
        {
            for (int i = 0; i < 3; i++)
            {
               

                Console.Beep(1500, 300);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("Accelerating...");
                Thread.Sleep(200);
            }
            speed += 20;
            oil -= 20;
            Console.Beep(2000, 300);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Car's speed increased, current speed:" + speed + "km/h");
        }
        else if (speed >= maxSpeed)
        {
            Console.WriteLine("Car has reached it's max speed!");
        }
        else if (oil<=0)
        {
            Console.WriteLine("Ran out of oil please change it!");
        }
        else
        {
            Console.WriteLine("Start the engine first!");
        }
    }
    public void brake()
    {
        
        if (engineOn && speed > 0)
        {
            for (int i = 0; i < 1; i++)
            {
                Console.Beep(500, 500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Breaking...");
                Thread.Sleep(100);
            }
            speed -= 10;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Beep(300, 500);
            Console.WriteLine("Car's speed decreased, current speed:" + speed + "km/h");
        }
        else if (!engineOn)
        {
            Console.WriteLine("Start the engine first!");
        }
        else
        {
            Console.WriteLine("Car is already stopped!");
        }
    }
    public void showSituation()
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(200, 500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Checking...");
            Thread.Sleep(100);
        }
        Console.WriteLine(" current speed:" + speed + "km/h \n And oil level is %" + oil);
    }
    public void changeOil(int amount)
    {
        for (int i = 0; i < 2; i++)
        {
            Console.Beep(100, 500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Refilling...");
            Thread.Sleep(100);
        }
        oil += amount;
        if (oil > 100) oil = 100;
        if (oil < 0) oil = 0;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Oil level has changed , new oil level is %" + oil);
    }
    public void controlOil()
    {
        for (int i = 0; i < 1; i++)
        {
            Console.Beep(500, 500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Checking...");
            Thread.Sleep(100);
        }
        if (oil == 100)
        {
            Console.WriteLine("-Oil level is FULL.-");
        }
        else if (oil < 100 & oil > 20)
        {
            Console.WriteLine("-Car oil level is between optimum range, the oil level is %" + oil + "-");
        }
        else if (oil == 0)
        {
            Console.WriteLine("-Ran out of oil, please change oil.- ");
        }
    }
    public void random()
    {
        if (speed < 40)
        {
            int random = rand.Next(0, 3);
            if (random == 1)
            {
                randomObj();
            }
        }
        else if(speed>40&&speed<100){
            int random = rand.Next(0,1 );
            if (random == 1)
            {
                randomObj();
            }

        }
        else {
            
                randomObj();
            }
    
       
    }
    public void km(int road)
    {
        road = 100;
        int km = road - speed / 10;
        Console.WriteLine("-"+km+"km left-");
    }
    public void gameLoop()
    { 
        bool loop = false;
        while (true)
        {
            Thread.Sleep(1000);           

            
            

        } 
    }




    internal class Program
    {
        static void Main(string[] args)
        {

            

            Console.WriteLine(" WELCOME TO THE CAR GAME!!\n Please enter command in lower case.\n Choose a car! Enter 1 for a sedan car or 2 for a sports car.");
            car mycar = new car();
           


            mycar.chooseCar();
            Console.WriteLine(" Starting the engine = start" +
                   "\n Stoping the engine = stop\n Increasing the car speed = fast\n Decreasing the car speed = slow" +
                   "\n Learning car condition = situation \n Learning car's oil level = oil \n Adding oil = add  ");
           
            bool exitProgram = false;

            while (!exitProgram)
            {
                
                string command = Console.ReadLine();

                mycar.random();
                switch (command)
                {
                    case "start":
                        mycar.startEngine();
                        break;
                    case "stop":
                        mycar.stopEngine();
                        break;
                    case "fast":
                        mycar.getFast();
                        break;
                    case "slow":
                        mycar.brake();
                        break;
                    case "situation":
                        mycar.showSituation();
                        break;
                    case "oil":
                        mycar.controlOil();
                        break;
                    case "add":
                        mycar.changeOil(50);
                        break;
                    case "1":
                    case "2":
                        mycar.chooseCar();
                        break;
                    case "demo":
                        
                        mycar.startEngine();
                        Thread.Sleep(800);
                        mycar.getFast();
                        Thread.Sleep(600);
                        mycar.getFast();
                        Thread.Sleep(800);                      
                        mycar.changeOil(-80);
                        Thread.Sleep(1200);
                        mycar.controlOil();
                        Thread.Sleep(1200);
                        mycar.getFast();
                        Thread.Sleep(600);
                        mycar.brake();
                        Thread.Sleep(800);
                        mycar.showSituation();
                        Thread.Sleep(2200);
                        mycar.getFast();
                        Thread.Sleep(600);
                        mycar.getFast();
                        Thread.Sleep(600);
                        mycar.getFast();
                        Thread.Sleep(600);
                        mycar.changeOil(+100);
                        Thread.Sleep(1200);
                        mycar.brake();
                        Thread.Sleep(400);
                        mycar.brake();
                        Thread.Sleep(400);
                        mycar.brake();
                        Thread.Sleep(400);
                        mycar.brake();
                        mycar.stopEngine();


                        break;

                    case "exit":
                        Console.WriteLine("Exiting program...");
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command, please try again.");
                        break;
                }
                mycar.km(100);
                

            }

        }
    }

}
