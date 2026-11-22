using System;

namespace MohawkGame2D
{
    public class Hologram
    {
        // Colors
        public Color CalmBlue = new(9, 243, 245);

        public void Update()
        {
            Draw.SetLineSize(1);
            Draw.SetFillColor(CalmBlue);
            Draw.Quad(125, 300, 275, 300, 225, 350, 175, 350);
        }
    }
}