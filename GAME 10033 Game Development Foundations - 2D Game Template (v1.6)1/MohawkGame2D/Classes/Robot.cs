using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Robot
    {
        // Position
        public float robotX;
        public float robotY;

        // Line position
        public float lineX;
        public float lineY1;
        public float lineY2;

        // Vent position
        public float ventX1;
        public float ventX2;
        public float ventY;

        // Vectors
        Vector2 position;
        Vector2 velocity;

        // Leg movements relative to body
        Vector2 footFoward = new Vector2(15, 40);
        Vector2 footBackward = new Vector2(-15, 40);

        // Animation
        public float walkSpeed = 10; // Determines how quickly legs move back/forth

        // Colors
        public Color geoEye = Color.Black;
        public Color geoForehead = Color.Black;

        public void Update()
        {
            // Body
            Draw.LineSize = 2; // Thicker lines
            Draw.FillColor = Color.Gray;
            Draw.Square(robotX, robotY, 80);
            Draw.Line(lineX, lineY1, lineX, lineY2); // Line on side of cube

            // Vent
            Draw.Line(ventX1, ventY, ventX2, ventY);           // Top
            Draw.Line(ventX1, ventY + 5, ventX2, ventY + 5);   // Middle
            Draw.Line(ventX1, ventY + 10, ventX2, ventY + 10); // Bottom

            // Swing of legs
            float swing = (MathF.Sin(Time.SecondsElapsed * walkSpeed) + 1) / 2;

            // Coordinates for top of legs
            Vector2 leftHip = new Vector2(lineX, lineY1 + 80);
            Vector2 rightHip = new Vector2(lineX + 30, lineY1 + 80);

            // Interpolation between coordinates
            Vector2 leftFootPos = leftHip + Vector2.Lerp(footBackward, footFoward, swing);
            Vector2 rightFootPos = rightHip + Vector2.Lerp(footFoward, footBackward, swing);

            // Legs are drawn and animated running
            Draw.Line(leftHip, leftFootPos);
            Draw.Line(rightHip, rightFootPos);

            // Eyes
            Draw.LineSize = 1;  // Line size reset
            Draw.FillColor = Color.White;
            Draw.Circle(robotX + 60, robotY + 50, 18); // Eyeball

            // Diamond
            Draw.FillColor = geoEye;
            Draw.Polygon(robotX + 65, robotY + 50, 8, 4, 0, 0);

            // Forehead diamond
            Draw.FillColor = geoForehead;
            Draw.Polygon(robotX + 65, robotY + 17, 8, 4, 0, 0);
        }
    }
}