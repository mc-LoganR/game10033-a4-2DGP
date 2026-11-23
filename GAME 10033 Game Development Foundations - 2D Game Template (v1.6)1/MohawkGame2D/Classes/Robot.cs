
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

        // Physics
        public float velocityY = 0;
        public float gravity = 1800;
        public float jumpForce = -950;

        // Ground position
        public float groundY = 400;
        bool isGrounded = true;

        // Jump input
        bool spaceWasPressed = false;

        // Leg movements relative to body
        Vector2 footFoward = new Vector2(15, 40);
        Vector2 footBackward = new Vector2(-15, 40);

        // Animation
        public float walkingTime = 0;
        public float walkSpeed = 10;

        // Colors
        public Color geoEye = Color.Black;
        public Color geoForehead = Color.Black;

        // Physics update
        public void PhysicsUpdate()
        {
            float deltaTime = Time.DeltaTime;

            // Spacebar input
            bool spaceDown =
                Input.IsKeyboardKeyDown(KeyboardKey.Space);

            // Jump when space is first pressed
            if (spaceDown && !spaceWasPressed && isGrounded)
            {
                velocityY = jumpForce;
                isGrounded = false;
            }

            spaceWasPressed = spaceDown;

            // Apply gravity
            velocityY += gravity * deltaTime;

            // Move vertically
            robotY += velocityY * deltaTime;

            // Ground collision
            if (robotY >= groundY)
            {
                robotY = groundY;
                velocityY = 0;
                isGrounded = true;
            }

            // Update all component positions
            lineX = robotX + 30;
            lineY1 = robotY + 1;
            lineY2 = robotY + 79;

            ventX1 = robotX + 5;
            ventX2 = robotX + 25;
            ventY = robotY + 50;
        }

        // Leg animation
        public void LegAnimation()
        {
            // Hip positions
            Vector2 leftHip =
                new Vector2(lineX, lineY1 + 80);

            Vector2 rightHip =
                new Vector2(lineX + 30, lineY1 + 80);

            // Advance animation
            walkingTime += Time.DeltaTime;

            // Smooth swing between 0 and 1
            float swing =
                (MathF.Sin(walkingTime * walkSpeed) + 1f) / 2f;

            // Foot positions
            Vector2 leftFootPos =
                leftHip + Vector2.Lerp(
                    footBackward, footFoward, swing);

            Vector2 rightFootPos =
                rightHip + Vector2.Lerp(
                    footFoward, footBackward, swing);

            // Draw legs
            Draw.Line(leftHip, leftFootPos);
            Draw.Line(rightHip, rightFootPos);
        }

        public void Update()
        {
            // Update physics first
            PhysicsUpdate();

            // Body
            Draw.LineSize = 2;
            Draw.FillColor = Color.Gray;

            Draw.Square(robotX, robotY, 80);

            // Side line
            Draw.Line(lineX, lineY1, lineX, lineY2);

            // Vent
            Draw.Line(ventX1, ventY, ventX2, ventY);
            Draw.Line(ventX1, ventY + 5, ventX2, ventY + 5);
            Draw.Line(ventX1, ventY + 10, ventX2, ventY + 10);

            // Legs
            LegAnimation();

            // Eyes
            Draw.LineSize = 1;
            Draw.FillColor = Color.White;

            Draw.Circle(robotX + 60, robotY + 50, 18);

            // Eye diamond
            Draw.FillColor = geoEye;

            Draw.Polygon(
                robotX + 65, robotY + 50,
                8, 4, 0, 0
            );

            // Forehead diamond
            Draw.FillColor = geoForehead;

            Draw.Polygon(
                robotX + 65, robotY + 17,
                8, 4, 0, 0
            );
        }
    }
}