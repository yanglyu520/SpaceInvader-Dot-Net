using System;
using SplashKitSDK;

public class Bullet
{
  public double X { get; private set; }
  public double Y { get; private set; }
  private int Radius { get { return 10; } set { Radius = 10; } }

  public SoundEffect CollisionSound { get; set; }
  public Circle CollisionCircle { get { return SplashKit.CircleAt(X, Y, Radius); } }
  public Rectangle CollisionRectangle { get { return SplashKit.RectangleFrom(X, Y, Radius, Radius); } }


  public Bullet(Player player)
  {
    X = player.X + (player.BitmapWidth - Radius) / 2;
    Y = player.Y - Radius / 2;
    CollisionSound = new SoundEffect("hit", "hit.wav");
  }

  public void Draw()
  {
    SplashKit.FillCircle(Color.Orange, X, Y, Radius);
  }

  public void Update()
  {
    const int SPEED = 12;
    Y -= SPEED;
  }

  public bool IsOffScreen(Window gameWindow)
  {
    return Y < 0;
  }

  public bool CollidedWith(Invader target)
  {
    return SplashKit.CirclesIntersect(CollisionCircle, target.CollisionCirle);
  }
  public bool CollidedWith(SuperUFO target)
  {
    return SplashKit.CirclesIntersect(CollisionCircle, target.CollisionCirle);
  }
}
