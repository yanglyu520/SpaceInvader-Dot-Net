using System;
using SplashKitSDK;

public class Program
{
  public static void Main()
  {
    Window windowOne = new Window("game", 600, 900);
    Game newGame = new Game(windowOne);
    SoundEffect backGroundMusic = new SoundEffect("game", "game.wav");

    newGame.myTimer.Start();
    backGroundMusic.Play();

    while (!newGame.Quit )
    {

      SplashKit.ProcessEvents();
      newGame.Draw();
      newGame.HandleInput();
      newGame.Update();
    }
    newGame.GameOverEffect();
    windowOne.Close();
  }
}



    // if (newGame.IsplayerWin)
    // {
    //   // newGame.WinEffect(windowOne);
    //   SplashKit.DrawText($"Congradulations! You Win!", Color.OrangeRed, "cool.ttf", 30, 50, 300);
    //   SplashKit.DrawText($"Your score is {newGame.Player.Score}", Color.OrangeRed, "cool.ttf", 30, 50, 260);
    //   windowOne.Refresh(60);
    //   SplashKit.Delay(8000);
    // }