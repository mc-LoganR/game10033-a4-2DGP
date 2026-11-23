using System;

namespace MohawkGame2D
{
    public class Laser: Obstacle
    {
        // Base variables
        public float BaseW = 100;
        public float BaseH = 20;

        // Laser variables
        public float LaserW = 60;
        public float LaserH = 475;

        // Colors
        public Color BaseColor = Color.DarkGray;
        public Color LaserColor = new(204, 51, 51);

        public override void Update()
        {
            base.Update(); // Update parent

            if (Active == true)
            {
                // Draw laser
                Draw.SetFillColor(BaseColor); // Color
                Draw.Rectangle(X, Y, BaseW, BaseH); // Draw base
                Draw.SetFillColor(LaserColor); // Color
                Draw.Rectangle(X + (BaseW - LaserW) / 2, Y - LaserH, LaserW, LaserH); // Draw laser
            }
        }
    }
}
