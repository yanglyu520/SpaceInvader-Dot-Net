using System;
using SplashKitSDK;


public class SuperUFO:Invader
{
  private Bitmap SuperUFOBitM { get; set; }
  public SuperUFO(int x, int y): base(x,y)
  {
    SuperUFOBitM = new Bitmap("superufo", "superufo.png");
    Speed = 5;
  }
  
  public void SuperUFOUpdate()
  {
    X += Speed;
  }
  public override void Draw()
  {
    SplashKit.DrawBitmap(SuperUFOBitM, X, Y);
  }
  public bool IsOffScreenWidth(Window gameWindow)
  {
    return X > gameWindow.Width - SuperUFOBitM.Width;
  }
}


