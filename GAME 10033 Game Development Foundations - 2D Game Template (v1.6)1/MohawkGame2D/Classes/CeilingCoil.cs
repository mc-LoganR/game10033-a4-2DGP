using System;

namespace MohawkGame2D
{
    public class CeilingCoil : Obstacle
    {
        // Coil variables
        public float TeslaW = 100;
        public float TeslaH = 20;

        // Generator variables
        public float SphereRadius = 20;

        // Colors
        public Color TeslaColor;
        public Color SphereColor;

        public override void Update()
        {
            base.Update();

            if (Active == true)
            {
                // Ceiling-mounted base
                Draw.SetFillColor(TeslaColor);
                Draw.Rectangle(X, Y, TeslaW, TeslaH);

                // Hanging generator
                Draw.SetFillColor(SphereColor);
                Draw.Circle(X + TeslaW / 2, Y + TeslaH + SphereRadius, SphereRadius);
            }
        }
    }
}