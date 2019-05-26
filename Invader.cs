using System;
using SplashKitSDK;
using System.Collections.Generic;

public abstract class Invader
{
  public double X { get; set; }
  public double Y { get; set; }
  public virtual int Speed { get; set; }
  public bool MoveRight { get; set; }
  public bool MoveLeft { get; set; }
  public bool IsDead { get; set; }

  public Circle CollisionCirle
  {
    get { return SplashKit.CircleAt(X + 22, Y + 22, 22); }
    set { CollisionCirle = SplashKit.CircleAt(X + 22, Y + 22, 22); }
  }
  public Invader(int x, int y)
  {
    X = x;
    Y = y;
    IsDead = false;
    Speed = 1;
    MoveRight = true;
    MoveLeft = false;

  }


  public abstract void Draw();
  public bool IsOffScreenHeight()
  {
    return Y > 620;
  }


}


//Below are 4 child classes for invaders

public class InvaderSquare : Invader
{
  public Bitmap InvaderSquareBitM { get; set; }
  public InvaderSquare(int x, int y) : base(x, y)
  {
    InvaderSquareBitM = new Bitmap("invader2Png", "invader2.png");
    // CollisionCirle.Draw(Color.LightPink);
  }
  public override void Draw()
  {
    // CollisionCirle.Draw(Color.Blue);
    SplashKit.DrawBitmap(InvaderSquareBitM, X, Y);
  }
}

public class InvaderTriangle : Invader
{
  public Bitmap InvaderTriangleBitM { get; set; }

  public InvaderTriangle(int x, int y) : base(x, y)
  {
    InvaderTriangleBitM = new Bitmap("invader1Png", "invader1.png");
  }
  public override void Draw()
  {
    // CollisionCirle.Draw(Color.Blue);
    SplashKit.DrawBitmap(InvaderTriangleBitM, X, Y);
  }
}

public class InvaderRound : Invader
{
  private Bitmap InvaderRoundBitM { get; set; }
  public InvaderRound(int x, int y) : base(x, y)
  {
    InvaderRoundBitM = new Bitmap("invader3Png", "invader3.png");

  }
  public override void Draw()
  {
    SplashKit.DrawBitmap(InvaderRoundBitM, X, Y);
  }
}


