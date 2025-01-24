using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlappyBirdConsoleApp
{
    internal class Program
    {
        class Pipe 
        {
            private int x;
            private int y;
            private int OrigX;
            public void setX(int x1)
            { x = x1; }
            public int getX()
            { return x; }

            public void setY(int y1)
            { y = y1; }
            public int getY()
            { return y; }
            public int getOrigX() 
            { return OrigX; }

            public void Move() 
            {
                if (getX() != 0) 
                {
                setX(getX() - 1);   
                }
                else
                {

                    setX(OrigX);
                }

            }
            public Pipe(int x1, int y1) 
            {
            x = x1;
            y = y1;
            OrigX = x;
            }
            

            

        }
        class Bird 
        {
            private int x;
            private int y;
            public Bird(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void setX(int x1)
            { x = x1; }
            public int getX()
            { return x; }

            public void setY(int y1)
            { y = y1; }
            public int getY()
            { return y; }
           


        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            const int Width = 100;
            const int Height = 25;

            Console.SetWindowSize(Width,Height);
            List<Pipe> pipes = new List<Pipe>();
            Bird bird = new Bird(5,Height/2);

            int LowerHeight=10;
            int UpperHeight=8;
            for(int i = 0; i < LowerHeight; i++) 
            {
                pipes.Add(new Pipe(Width-1, i));
            }
            for (int i = 0; i < UpperHeight; i++)
            {
                pipes.Add(new Pipe(Width-1, Height-1-i));
            }

            Console.WriteLine("Press any key, Fullscreen recommended");
            Console.ReadKey();
            bool GameOver = false;
            while (GameOver==false) 
            {
                
                Console.Clear();
                for (int i = 0; i < Width - 1; i++)
                {
                    Console.SetCursorPosition(i, Height - 1);
                    Console.Write("=");
                }

                



                for (int i = 0; i < LowerHeight + UpperHeight; i++)
                {
                    Console.SetCursorPosition(pipes[i].getX(), pipes[i].getY());
                    Console.Write("::");
                    if (bird.getY() == pipes[i].getY() && bird.getX() == pipes[i].getX())
                    { GameOver = true; }
                    pipes[i].Move();

                }
                Console.SetCursorPosition(bird.getX(), bird.getY());
                Console.Write("->");
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            
                            if (bird.getY() > -Height)
                            {
                                bird.setY(bird.getY() - 5);
                            }
                            break;
                    }
                }

                
            
                
                

                if (bird.getY() < Height-1) 
                {
                bird.setY(bird.getY() + 1);
                }
                else { GameOver=true; }
                
                Thread.Sleep(35);
            
            }
            Console.Write("Dead");
            
            
            Console.ReadKey();

        }
    }
}
