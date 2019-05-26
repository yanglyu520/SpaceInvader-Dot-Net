using System;
using SplashKitSDK;
using System.Collections.Generic;


public class Player
{
  public Bitmap PlayerBitmap { get; set; }
  public double X { get; private set; }
  public double Y { get; private set; }
  public int BitmapWidth { get { return PlayerBitmap.Width; } }
  public int BitmapHeight { get { return PlayerBitmap.Height; } }
  public bool Quit { get; private set; }
  public int Score { get; set; }
  public int Lives { get; private set; }
  public List<Bullet> Bullets { get; set; }
  public SoundEffect FireSound {get;set;}
  // public bool Win {get;set;}
  public Player(Window gameWindow)
  {
    Bitmap playerPng = new Bitmap("playerPng", "Player.png");
    PlayerBitmap = playerPng;
    X = (gameWindow.Width - BitmapWidth) / 2;
    Y = gameWindow.Height - BitmapHeight - 20;
    Quit = false;
    Lives = 5;
    Score = 0;
    // Win = false;
    Bullets = new List<Bullet>();
    FireSound = new SoundEffect("fire", "fire.wav");
  }
  public void Draw(Window gameWindow)
  {

    gameWindow.DrawBitmap(PlayerBitmap, X, Y);
    for (int i = 0; i < Lives; i++)
    {
      gameWindow.FillCircle(Color.LightGray, 380 +30* i, 65, 10);
    }
    foreach (Bullet item in Bullets)
    {
      item.Draw();
    }
  }

  public void HandleInput()
  {
    const int SPEED = 5;
    if (SplashKit.KeyDown(KeyCode.LeftKey))
    {
      X -= SPEED;
    }
    if (SplashKit.KeyDown(KeyCode.RightKey))
    {
      X += SPEED;
    }


    if (SplashKit.MouseClicked(MouseButton.LeftButton))
    {
      Bullet bullet = new Bullet(this);
      Bullets.Add(bullet);
      FireSound.Play();
    }
  }
  public void StayOnWindow(Window gameWindow)
  {
    const int GAP = 50;
    if (X < GAP)
    {
      X = GAP;
    }
    if (X > gameWindow.Width - BitmapWidth - GAP)
    {
      X = gameWindow.Width - BitmapWidth - GAP;
    }
  }

  public bool CollidedWith(AlienBullet abullet)
  {
    return PlayerBitmap.RectangleCollision(X, Y, abullet.CollisionRec);
    // Circle circle1= SplashKit.CircleAt(X-20, Y-20, 50);
    // return SplashKit.CirclesIntersect(circle1, abullet.CollisionCircle);
  }

  
  public void LoseLives()
  {
    Lives -= 1;
  }

}
