// Include the namespaces (code libraries) you need below.
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
        // Used for robot eyes
        Color calmBlue = new(9, 243, 245);
        Color alertYellow = new(200, 204, 50);
        Color angryRed = new(204, 51, 51);

        //Arrays
        // Robot tool arrays

        // Energy blast array
        EnergyBlast[] EnergyBlasts;
        // Hologram array
        Hologram[] PlatformHologram;

        // Obstacle arrays

        // Spike array
        Spike[] spikes;
        // Laser array
        Laser[] lasers;
        // Tesla coil array
        ElectricCoil[] teslaCoils;
        // Ceiling coil array
        CeilingCoil[] ceilingCoils;

        // Decoration arrays

        // Cameras array
        Camera[] argos;

        public void Setup()
        {
            Window.SetTitle("Robot Rush");
            Window.SetSize(800, 600);
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

            // Changing lights WIP
            if (secondsElapsed < 60 && secondsElapsed > 0)
            {
                Window.ClearBackground(calmBlue);
            }

            else if (secondsElapsed > 60 && secondsElapsed < 120)
            {
                Window.ClearBackground(alertYellow);
            }

            else
            {
                Window.ClearBackground(angryRed);
            }

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
            // Both hologram and energy blast used
            if (Input.IsMouseButtonDown(MouseButton.Left) && Input.IsKeyboardKeyDown(KeyboardKey.E))
            { 
                Geo.geoEye = Color.White;
                Geo.geoForehead = Color.White;
            }

            // Only hologram used
            else if (Input.IsKeyboardKeyDown(KeyboardKey.E))
            {
                Geo.geoForehead = Color.White;
            }

            // Only energy blast used
            else if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                Geo.geoEye = Color.White;
            } 
            Geo.Update();
        }
    }
}