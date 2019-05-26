using System;
using SplashKitSDK;

public class CaveBlock
{
  public double X { get; private set; }
  public double Y { get; private set; }
  public double Width {get;set;}

  public SoundEffect CaveCollide {get;set;}
  public Rectangle CollisionRec { get{return SplashKit.RectangleFrom(X, Y, Width,Width); } }
  public CaveBlock(int x, int y)
  {
    X = x;
    Y = y;
    Width = 40;
    CaveCollide = new SoundEffect("ccollide", "ccollide.wav");
  }

  public void Draw()
  {
    SplashKit.FillRectangle(Color.LightGreen, X, Y, Width,Width);
  }

  public bool CollidedWith(AlienBullet target)
  {
    return SplashKit.RectanglesIntersect(CollisionRec,target.CollisionRec);
  }
    public bool CollidedWith(Bullet target)
  {
    return SplashKit.RectanglesIntersect(CollisionRec,target.CollisionRectangle);
  }

}
