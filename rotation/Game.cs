// Include the namespaces (code libraries) you need below.
using Microsoft.VisualBasic.FileIO;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    Vector2 direction = Vector2.UnitY;

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Rotation");
        Window.SetSize(400, 400);
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        // Rotate direction using Quaternion
        Quaternion rotation = Quaternion.CreateFromYawPitchRoll(0, 0, MathF.Tau * Time.DeltaTime);
        direction = Vector2.Transform(direction, rotation);

        // From centre of window outward by 100px
        Draw.LineSize = 5;
        Draw.Line(Window.Size / 2, Window.Size / 2 + direction * 100);

        // Hacky debug
        Console.WriteLine($"{Input.IsAnyControllerButtonDown(ControllerButton.LeftFaceLeft)}");
    }
}
