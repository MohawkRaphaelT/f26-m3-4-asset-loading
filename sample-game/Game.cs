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
    Character character = new Character();

    public void Setup()
    {
        Window.SetTitle("Cool Game with Assets");
        Window.SetSize(600, 600);

        character.Setup();
    }

    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        character.Update();

        Text.Size = 32;
        Text.Color = Color.Black;
        Text.Draw($"temp", 5, 5);
    }
}
