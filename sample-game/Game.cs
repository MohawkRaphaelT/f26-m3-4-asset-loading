// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    Character characterM = new Character();
    Character characterF = new Character();

    public void Setup()
    {
        Window.SetTitle("Cool Game with Assets");
        Window.SetSize(600, 600);

        characterM.Setup(0, KeyboardKey.W, KeyboardKey.S, KeyboardKey.A, KeyboardKey.D, 0);
        characterF.Setup(2, KeyboardKey.Up, KeyboardKey.Down, KeyboardKey.Left, KeyboardKey.Right, 1);
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        characterM.Update();
        characterF.Update();

        Text.Size = 32;
        Text.Color = Color.Black;
        Text.Draw($"temp", 5, 5);
    }
}
