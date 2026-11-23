using System;

namespace MohawkGame2D
{
    public class ElectricCoil : Obstacle
    {
        // Base dimensions
        public float TeslaW = 100;
        public float TeslaH = 20;

        // Generator dimensions
        public float SphereRadius = 20;

        // Colors
        public Color TeslaColor;
        public Color SphereColor;

        public override void Update()
        {
            // Update parent movement
            base.Update();

            if (Active == true)
            {
                // Base
                Draw.SetFillColor(TeslaColor);
                Draw.Rectangle(X, Y, TeslaW, TeslaH);

                // Electric generator
                Draw.SetFillColor(SphereColor);
                Draw.Circle(X + TeslaW / 2, Y - SphereRadius, SphereRadius);
            }
        }
    }
}
