using System;

namespace MohawkGame2D
{
    public class Spike: Obstacle
    {
        // Spike variables
        public Color SpikeColor = Color.Black;

        public override void Update()
        {
            base.Update(); // Update parent

            if (Active == true)
            {
                // Draws spike
                Draw.SetLineColor(Color.DarkGray); // Outline
                Draw.SetFillColor(SpikeColor); // Color
                Draw.Triangle(X, Y, X + 30, Y - 50, X + 60, Y); // Triangle consistent wherever placed
            }
        }
    }
}