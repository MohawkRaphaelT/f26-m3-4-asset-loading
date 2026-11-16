using System;
using System.Numerics;

namespace MohawkGame2D;

public class Character
{
    Texture2D spritesheet = Graphics.LoadTexture("../../../../assets/graphics/gbc.png");
    Vector2 position;
    int currentFrame;
    int[] currentAnimation;
    int characterRow;
    float speed;
    float timeElapsedSinceLastFrame;

    // Character inputs
    KeyboardKey up;
    KeyboardKey down;
    KeyboardKey left;
    KeyboardKey right;
    int controllerID;


    // Game data
    // Frame counts
    int[] animDown = [1, 0, 1, 2];
    int[] animUp = [4, 3, 4, 5];
    int[] animLeft = [6, 7, 6, 7];
    int[] animRight = [8, 9, 8, 9];
    // Size
    const int width = 16;
    const int height = 16;
    const float secondsPerFrame = 0.100f;

    public void Setup(int spritesheetRow, KeyboardKey u, KeyboardKey d, KeyboardKey l, KeyboardKey r, int controllerID)
    {
        // Initialize which animation to use
        currentAnimation = animDown;
        // Pick which character to display from spritesheet
        characterRow = spritesheetRow;

        // Set up initial variables
        speed = 16 * 4 * 4;

        // TEMP
        position = Window.Size / 2;

        // Set character inputs
        up = u;
        down = d;
        left = l;
        right = r;
        this.controllerID = controllerID;
    }

    public void Update()
    {
        // Update time used to play animation
        timeElapsedSinceLastFrame += Time.DeltaTime;
        // used to know if we update animation frame
        bool hasMoved = false;

        // Up
        if (Input.IsKeyboardKeyDown(up) || Input.IsControllerButtonDown(controllerID, ControllerButton.LeftFaceUp))
        {
            currentAnimation = animUp;
            position.Y -= speed * Time.DeltaTime;
            hasMoved = true;
        }
        // Down
        if (Input.IsKeyboardKeyDown(down) || Input.IsControllerButtonDown(controllerID, ControllerButton.LeftFaceDown))
        {
            currentAnimation = animDown;
            position.Y += speed * Time.DeltaTime;
            hasMoved = true;
        }
        // Left
        if (Input.IsKeyboardKeyDown(left) || Input.IsControllerButtonDown(controllerID, ControllerButton.LeftFaceLeft))
        {
            currentAnimation = animLeft;
            position.X -= speed * Time.DeltaTime;
            hasMoved = true;
        }
        // Right
        if (Input.IsKeyboardKeyDown(right) || Input.IsControllerButtonDown(controllerID, ControllerButton.LeftFaceRight))
        {
            currentAnimation = animRight;
            position.X += speed * Time.DeltaTime;
            hasMoved = true;
        }

        // If moving, run the animation
        if (hasMoved == true)
        {
            if (timeElapsedSinceLastFrame >= secondsPerFrame)
            {
                // Move frame index forward and wrap it around
                currentFrame += 1;
                currentFrame %= currentAnimation.Length;
                // Reset time since last update
                timeElapsedSinceLastFrame = 0;
            }
        }
        else // hasMoved == false
        {
            // Reset to resting frame for animation
            currentFrame = 0;
        }

        // Change between different rows in spritesheet
        if (Input.IsKeyboardKeyPressed(KeyboardKey.Z))
        {
            characterRow += 1;
        }

        // Select which frames to use from the spritesheet
        int spriteFrame = currentAnimation[currentFrame];
        int subsetX = spriteFrame * width;
        int subsetY = characterRow * height;
        Vector2 subsetOrigin = new Vector2(subsetX, subsetY);
        Vector2 subsetSize = new Vector2(width, height);

        Graphics.Scale = 4;
        Graphics.DrawSubset(spritesheet, position, subsetOrigin, subsetSize);
    }
}
