using System;

namespace MohawkGame2D
{
    public class Robot
    {
        // Variables
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

        // Colors
        public Color geoEye = Color.Black;
        public Color geoForehead = Color.Red;

        public void Update()
        {
            // Body
            Draw.FillColor = Color.Gray;
            Draw.Square(robotX, robotY, 80);

            // Thick line set
            Draw.LineSize = 2;

            // Cube line
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

            // Line size reset
            Draw.LineSize = 1;

            // Eyes
            // Eyeball
            Draw.FillColor = Color.White;
            Draw.Circle(robotX + 60, robotY + 50, 18);

            // Sclera
            Draw.FillColor = geoEye;
            Draw.Polygon(robotX + 65, robotY + 50, 8, 4, 0, 0);

            // Forehead sclera
            Draw.FillColor = geoForehead;
            Draw.Polygon(robotX + 65, robotY + 17, 8, 4, 0, 0);
        }
    }
}