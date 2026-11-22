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

        // Arrays
        // Robot arrays
        // Energy blast array
        EnergyBlast[] EnergyBlasts;
        // Hologram array
        Hologram[] PlatformHologram;

        // Decoration arrays
        // Cameras array
        Camera[] Argos;

        // Light arrays
        Light[] Lights;

        // Obstacle arrays
        // Spike array
        Spike[] Spikes;
        // Laser array
        Laser[] Lasers;
        // Tesla coil array
        ElectricCoil[] TeslaCoils;
        // Ceiling coil array
        CeilingCoil[] CeilingCoils;

        public void Setup()
        {
            Window.SetTitle("Robot Rush");
            Window.SetSize(800, 600);

            // Add number of each arrayed object
            // Robot
            EnergyBlasts = new EnergyBlast[100];
            PlatformHologram = new Hologram[100];

            // Environment
            Argos = new Camera[100];
            Lights = new Light[100];

            // Obstacles
            Spikes = new Spike[100];
            Lasers = new Laser[100];
            TeslaCoils = new ElectricCoil[100];
            CeilingCoils = new CeilingCoil[100];

            // Initializes
            // Assign new class to specific array at index i

            // Energy blast
            for (int i = 0; i < EnergyBlasts.Length; i++)
            {
                EnergyBlasts[i] = new EnergyBlast();
            }

            // Hologram platform
            for (int i = 0; i < PlatformHologram.Length; i++)
            {
                PlatformHologram[i] = new Hologram();
            }

            // Argos security camera array
            for (int i = 0; i < Argos.Length; i++)
            {
                Argos[i] = new Camera();
            }

            // Light fixture array
            for (int i = 0; i < Lights.Length; i++)
            {
                Lights[i] = new Light();
            }

            // Spike array
            for (int i = 0; i < Spikes.Length; i++)
            {
                Spikes[i] = new Spike();
            }

            // Laser array
            for (int i = 0; i < Lasers.Length; i++)
            {
                Lasers[i] = new Laser();
            }

            // Tesla coil array
            for (int i = 0; i < TeslaCoils.Length; i++)
            {
                TeslaCoils[i] = new ElectricCoil();
            }

            // Ceiling coil array
            for (int i = 0; i < CeilingCoils.Length; i++)
            {
                CeilingCoils[i] = new CeilingCoil();
            }

        }

        public void Update()
        {
            // Time variables

            // Time in seconds between last frame and current frame
            float deltaTime = Time.DeltaTime;
            // Seconds elapsed since system start-up
            float secondsElapsed = Time.SecondsElapsed;
            // Speed calculation
            x += deltaTime * speed;

            /* Checks when object reachs window
            ///if (x - radius > Window.Width)
            {
                // X resets
               // x = -radius;
            }
            */

            x += Time.DeltaTime * speed;

            // Changing lights WIP
            if (secondsElapsed < 60 && secondsElapsed > 0)
            {
                Window.ClearBackground(Color.White);
            }

            // Basic environment
            Draw.SetFillColor(Color.DarkGray);
            //Ceiling
            Draw.Rectangle(0, 0, 800, 25);
            // Ground
            Draw.Rectangle(0, 520, 800, 100);

            // Physics


            // Player character
            Robot Geo = new Robot
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
            Geo.Update();

            // Determine eye color based on player input
            // Spawn abilities on player input

            // Both hologram and energy blast used
            if (Input.IsMouseButtonDown(MouseButton.Left) && Input.IsKeyboardKeyDown(KeyboardKey.E))
            { 
                Geo.geoEye = Color.White;
                Geo.geoForehead = Color.White;
                // Spawn hologram
                Hologram Hologram = new Hologram();
                Hologram.Update();
                // Fire energy

            }

            // Only hologram used
            else if (Input.IsKeyboardKeyDown(KeyboardKey.E))
            {
                // Make forehead eye white from blue
                Geo.geoForehead = Color.White;
                // Spawn hologram
                Hologram Hologram = new Hologram();
                Hologram.Update();
            }

            // Only energy blast used
            else if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                Geo.geoEye = Color.White;
                // Fire energy

            } 
            Geo.Update();

            // Laser behind player
            Laser ChaseLaser = new Laser()
            {
                BaseColor = Color.DarkGray,
                BaseX = 20,
                BaseY = 500,
                BaseH = 20,
                BaseW = 100,
                LaserX = 40,
                LaserY = 25,
                LaserH = 475,
                LaserW = 60
            };
            ChaseLaser.Update();
        }
    }
}