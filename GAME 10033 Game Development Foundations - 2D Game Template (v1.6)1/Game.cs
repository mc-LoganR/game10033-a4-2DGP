using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        // Variables
        // Time variables
        float x;
        float speed = 200;

        // Color variables
        // Used for lights and robot eyes
        Color calmBlue = new(9, 243, 245);
        Color alertYellow = new(200, 204, 50);
        Color angryRed = new(204, 51, 51);

        // Classes and arrays
        Robot Geo; // Player character class
        Laser ChaseLaser; // Laser behind player
        Obstacle[] Obstacles; // Obstacle parent array

        public void Setup()
        {
            Window.SetTitle("Robot Rush");
            Window.SetSize(800, 600);
            Window.ClearBackground(Color.White);

            Geo = new Robot // Player initialize
            {
                robotX = 150,
                robotY = 400,
                lineX = 180,
                lineY1 = 401,
                lineY2 = 479,
                ventX1 = 155,
                ventX2 = 175,
                ventY = 450,
                geoEye = calmBlue,
                geoForehead = calmBlue
            };

            ChaseLaser = new Laser // Unique ever-present laser
            {
                X = 20,
                Y = 500,
                Active = true,
                Moving = false
            };

            Obstacles = new Obstacle[100]; // Obstacles array initialize

            for (int i = 0; i < Obstacles.Length; i++) // Random obstacle generator
            {
                int type = Random.Integer(0, 4); // Picks random value of which to spawn

                if (type == 0)
                {
                    Obstacles[i] = new Spike(); // Initializes spike
                }
                else if (type == 1)
                {
                    Obstacles[i] = new Laser(); // Initializes laser
                }
                else if (type == 2)
                {
                    Obstacles[i] = new ElectricCoil(); // Initializes tesla coil
                }
                else
                {
                    Obstacles[i] = new CeilingCoil(); // Initializes ceiling coil
                }
            }
        }

        public void Update()
        {
            Window.ClearBackground(Color.White); // Background is constantly updated

            // Time variables
            float deltaTime = Time.DeltaTime; // Time in seconds between last frame and current frame
            x += deltaTime * speed;  // Speed calculation

            // Basic environment
            Draw.SetFillColor(Color.DarkGray); // Color
            Draw.Rectangle(0, 0, 800, 25); //Ceiling
            Draw.Rectangle(0, 520, 800, 100); // Ground

            for (int i = 0; i < Obstacles.Length; i++)
            {
                Obstacles[i].Update();
            }

            // Determine eye color based on player input
            // Spawn abilities on player input

            // Both abilities at once
            if (Input.IsMouseButtonDown(MouseButton.Left) && Input.IsKeyboardKeyDown(KeyboardKey.E)) // Both abilities at once
            {
                Geo.geoEye = Color.White;
                Geo.geoForehead = Color.White;

                // Spawn hologram

                // Fire energy blast

            }

            else if (Input.IsKeyboardKeyDown(KeyboardKey.E)) // Spawn hologram
            {
                Geo.geoForehead = Color.White;
                
                // Spawn hologram
            }

            else if (Input.IsMouseButtonDown(MouseButton.Left)) // Shoot energy blast
            {
                Geo.geoEye = Color.White;

                // Fire energy blast
            }

            else
            {
                // Reset colours when nothing is used
                Geo.geoEye = calmBlue;
                Geo.geoForehead = calmBlue;
            }
            Geo.Update(); // Keeps changes to player

            ChaseLaser.Update();
        }
    }
}