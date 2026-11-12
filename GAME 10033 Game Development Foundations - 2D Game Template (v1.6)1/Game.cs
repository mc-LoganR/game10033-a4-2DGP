// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

// The namespace your code is in.
namespace MohawkGame2D
{
    // Obstacle classes
    /// Spike
    public class Spike()
    {
        // Position variables
        public float triX1;
        public float triX2;
        public float triX3;
        public float triY1;
        public float triY2;

        public void Update()
        {
            Draw.SetLineColor(Color.Black);
            Draw.SetFillColor(Color.DarkGray);
            Draw.Triangle(triX1, triY1, triX2, triY2, triX3, triY1);
        }
    }

    /// Laser
    public class Laser()
    {
        public void Update()
        {

        }
    }

    /// Tesla and ceiling coil
    public class elecCoil()
    {
        public void Update()
        {

        }
    }

    public class topCoil()
    {
        public void Update()
        {

        }
    }

    // Robot player classes
    /// Body
    public class Robot()
    {
        // Variables
        // Position
        public float robotX;
        public float robotY;

        // Line position
        public float lineX;
        public float lineY1;
        public float lineY2;

        // Vent Position
        public float ventX1;
        public float ventX2;
        public float ventY;

        // Color
        public Color geoEye;
        public Color geoForehead;

        public void Update()
        {
            // Body
            Draw.SetFillColor(Color.Gray);
            Draw.Square(robotX, robotY, 80);
            // Cube line
            Draw.SetLineSize(2);
            Draw.Line(lineX, lineY1, lineX, lineY2);
            // Vent
            // Top vent
            Draw.Line(ventX1, ventY, ventX2, ventY);
            // Middle vent
            Draw.Line(ventX1, ventY + 5, ventX2, ventY + 5);
            // Bottom vent
            Draw.Line(ventX1, ventY + 10, ventX2, ventY + 10);

            // Legs
            // Left leg
            Draw.Line(lineX, lineY1 + 80, lineX, lineY2 + 40);
            // Right leg
            Draw.Line(lineX + 30, lineY1 + 80, lineX + 30, lineY2 + 40);

            Draw.SetLineSize(1);

            // Eyes
            // Eyeball
            Draw.SetFillColor(Color.White);
            Draw.Circle(robotX + 60, robotY + 50, 18);
            // Sclera
            Draw.FillColor = geoEye;
            Draw.Polygon(robotX + 65, robotY + 50, 8, 4, 0, 0);

            // Forehead sclera
            Draw.FillColor = geoForehead;
            Draw.Polygon(robotX + 65, robotY + 17, 8, 4, 0, 0);
        }
    }

    /// Energy blast
    public class eBlast
    {
        public void Update()
        {

        }
    }

    /// Hologram platform
    public class Hologram
    {
        public void Update()
        {

        }
    }

    /// Argos security camera
    public class Camera
    {
        // Variables

        public void Update()
        {

        }
    }

    public class Game
    {
        // Variables
        // Time variables
        float x;
        float speed = 200;

        // Color variables
        // Used for robot eyes
        Color calmBlue = new Color(9, 243, 245);
        Color alertYellow = new Color(200, 204, 50);
        Color angryRed = new Color(204, 51, 51);

        //Arrays
        // Robot tool arrays
        // Energy blast array
        eBlast[] energyBlasts;
        // Hologram array
        Hologram[] platformHologram;

        // Obstacle arrays
        // Spike array
        Spike[] spikes;
        // Laser array
        Laser[] lasers;
        // Tesla coil array
        elecCoil[] teslaCoils;
        // Ceiling coil array
        topCoil[] ceilingCoils;

        // Decoration arrays
        Camera[] argos;

        public void Setup()
        {
            Window.SetTitle("Robot Rush");
            Window.SetSize(800, 600);
        }

        public void Update()
        {
            // Time variables
            // Used for energy blasts 

            // Time in seconds between last frame and current frame
            float deltaTime = Time.DeltaTime;
            // Seconds elapsed since system start-up
            float secondsElapsed = Time.SecondsElapsed;
            // Speed calculation
            x += Time.DeltaTime * speed;

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
                Geo.geoForehead = Color.White;
                Geo.geoEye = Color.White;
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