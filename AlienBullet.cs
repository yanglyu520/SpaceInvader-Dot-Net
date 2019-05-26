using System;
using SplashKitSDK;

public class AlienBullet
{
  public double X { get; private set; }
  public double Y { get; private set; }
  public Rectangle CollisionRec { get{return SplashKit.RectangleFrom(X, Y, 8,20); } }
  public AlienBullet(Invader invader)
  {
    X = invader.X + 22;
    Y = invader.Y;
  }

  public void Draw()
  {
    SplashKit.FillRectangle(Color.Blue, X, Y, 8,20);
  }

  public void Update()
  {
    const int SPEED = 3;
    Y += SPEED;

  }

  public bool IsOffScreen(Window gameWindow)
  {
    return Y > gameWindow.Height;
  }

  // public bool CollidedWith(Player target)
  // {
  //   return AlienBulletBitmap.BitmapCollision(X, Y, target.PlayerBitmap,target.X, target.Y);
  // }

}
