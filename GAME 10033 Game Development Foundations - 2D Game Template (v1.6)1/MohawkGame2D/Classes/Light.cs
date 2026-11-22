using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D
{
    public class Light
    {
        // Color variable
        // Color of lights changes as level progress is made
        public Color LightColor;

        // Fixture position variables
        public float LightX;
        public float LightY;
        public float LightW;
        public float LightH;

        // Light shaft variables
        public float BeamX1;
        public float BeamX2;
        public float BeamX3;
        public float BeamY1;
        public float BeamY2;

        public void Update()
        {
            // Light fixture
            Draw.SetFillColor(LightColor);
            Draw.Rectangle(LightX, LightY, LightW, LightH);

            // Cone of light
            Draw.SetFillColor(LightColor);
            Draw.Triangle(BeamX1, BeamY1, BeamX2, BeamY2, BeamX3, BeamY1);
        }
    }
}