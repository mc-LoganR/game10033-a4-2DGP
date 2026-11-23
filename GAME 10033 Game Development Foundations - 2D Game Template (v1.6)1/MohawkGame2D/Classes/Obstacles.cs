using System;

namespace MohawkGame2D
{
    public class Obstacle
    {
        /*
         * Shared class for the obstacles
         * Includes spikes, lasers,
         * tesla coils, and ceiling coils
         */

        // Shared variables
        public float X;
        public float Y;
        public float Speed = 200;

        public bool Active = false;
        public bool Moving = true;

        // Shared movement
        public virtual void Update()
        {
            if (Active == true && Moving == true)
            {
                X -= Speed * Time.DeltaTime;
            }
        }
    }
}
