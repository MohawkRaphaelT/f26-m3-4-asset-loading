using System;
using System.Numerics;

namespace MohawkGame2D;

public class Character
{
    Texture2D spritesheet = Graphics.LoadTexture("../../../../assets/graphics/gbc.png");
    Vector2 position;
    float currentFrame;
    int[] currentAnimation = animDown;
    int facingDirection;
    int characterRow;

    // Game data
    // Frame counts
    static readonly int[] animDown = [0, 1, 2, 1];
    static readonly int[] animUp = [3, 4, 5, 4];
    static readonly int[] animLeft = [6, 7];
    static readonly int[] animRight = [8, 9];
    // Size
    const int width = 16;
    const int height = 16;


    public void Update()
    {
        // Up
        if (Input.IsKeyboardKeyPressed(KeyboardKey.W) || Input.IsKeyboardKeyPressed(KeyboardKey.Up))
        {
            currentAnimation = animUp;
        }
        // Down
        if (Input.IsKeyboardKeyPressed(KeyboardKey.S) || Input.IsKeyboardKeyPressed(KeyboardKey.Down))
        {
            currentAnimation = animDown;
        }
        // Left
        if (Input.IsKeyboardKeyPressed(KeyboardKey.A) || Input.IsKeyboardKeyPressed(KeyboardKey.Left))
        {
            currentAnimation = animLeft;
        }
        // Right
        if (Input.IsKeyboardKeyPressed(KeyboardKey.D) || Input.IsKeyboardKeyPressed(KeyboardKey.Right))
        {
            currentAnimation = animRight;
        }


        currentFrame += 1f / 6; // once every 6 frames, draw 1 frame
        currentFrame %= currentAnimation.Length;
        //if (currentFrame >= downFrameCount)
        //    currentFrame = 0;

        if (Input.IsKeyboardKeyPressed(KeyboardKey.Z))
        {
            characterRow += 1;
        }


        Vector2 position = Window.Size / 2;
        int spriteFrame = currentAnimation[(int)currentFrame];
        int subsetX = spriteFrame * width;
        int subsetY = characterRow * height;
        Vector2 subsetOrigin = new Vector2(subsetX, subsetY);
        Vector2 subsetSize = new Vector2(width, height);

        Graphics.Scale = 4;
        Graphics.DrawSubset(spritesheet, position, subsetOrigin, subsetSize);
    }
}
