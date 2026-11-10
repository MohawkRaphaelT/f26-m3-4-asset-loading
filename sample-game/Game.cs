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
    Texture2D megaman = Graphics.LoadTexture("../../../../assets/graphics/mega man 8-bit.png");
    Sound coinSFX = Audio.LoadSound("../../../../assets/audio/coin.wav");
    //Sound targetSFX = Audio.LoadSound("../../../../assets/audio/target.ogg");
    //Music bgm = Audio.LoadMusic("../../../../assets/audio/country.mp3");
    Font font = Text.LoadFont("../../../../assets/fonts/Press_Start_2P/PressStart2P-Regular.ttf");
    int score = 0;

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Cool Game with Assets");
        Window.SetSize(600, 600);

        string cwd = System.IO.Directory.GetCurrentDirectory();
        Console.WriteLine($"CWD: {cwd}");
    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);

        //if (Audio.IsPlaying(bgm) == false)
        //{
        //    //Audio.Play(bgm);
        //}


        // "Simulate" getting a coin
        if (Input.IsKeyboardKeyPressed(KeyboardKey.C) == true)
        {
            score += 100;
            Audio.Play(coinSFX);
        }

        //if (Input.IsKeyboardKeyPressed(KeyboardKey.T) == true)
        //{
        //    Audio.Play(targetSFX);
        //}

        //Graphics.Scale = 1 / 4f;
        //Graphics.Rotation += 1;
        //Graphics.Draw(megaman, Window.Size / 2, new Vector2(megaman.Width / 2, megaman.Height));

        character.Update();

        Text.Size = 32;
        Text.Font = font;
        Text.Color = Color.Black;
        Text.Draw($"SCORE: {score}", 5, 5);
    }
}
