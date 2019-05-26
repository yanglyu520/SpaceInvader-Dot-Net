using System;
using SplashKitSDK;
using System.Collections.Generic;


public class Game
{
  private Bitmap Title { get; set; }
  public SoundEffect BackgroundSound { get; set; }
  public SoundEffect AlienShootSound { get; set; }
  public SoundEffect LoseLifeSound { get; set; }
  public SoundEffect WinSound { get; set; }
  public SoundEffect UFOSound { get; set; }
  private Window GameWindow { get; set; }
  public List<Invader> Invaders { get; set; }
  public List<SuperUFO> SuperUFOs { get; set; }
  public List<AlienBullet> AlienBullets { get; set; }
  public List<CaveBlock> CaveBlocks { get; set; }
  public Player Player { get; set; }
  public Timer myTimer = new Timer("My Timer");
  public bool Quit { get; set; }
  // public bool IsplayerWin { get; set; }
  public void AddAlienBullet()
  {
    int randomN = SplashKit.Rnd(Invaders.Count);
    if (Invaders.Count != 0)
    {
      if (AlienBullets.Count == 0)
      {
        AlienBullets.Add(new AlienBullet(Invaders[randomN]));
        AlienShootSound.Play();
      }
    }
  }
  public Game(Window gameWindow)
  {
    GameWindow = gameWindow;
    Player = new Player(gameWindow);
    Invaders = new List<Invader>();
    AlienBullets = new List<AlienBullet>();
    SuperUFOs = new List<SuperUFO>();
    CaveBlocks = new List<CaveBlock>();
    Title = new Bitmap("titlePng", "title.png");
    WinSound = new SoundEffect("winSound", "win.wav");
    UFOSound = new SoundEffect("ufo", "ufo.wav");
    Quit = false;
    // IsplayerWin = false;
    AlienShootSound = new SoundEffect("shoot", "ashoot.wav");
    LoseLifeSound = new SoundEffect("ouch", "ouch.wav");
    int iX, iY;
    iY = 180;

    //add the many invaders

    for (int i = 0; i < 6; i++)
    {
      iX = 50;
      iX = iX + i * 80;
      Invaders.Add(new InvaderRound(iX, iY));
    }
    for (int i = 0; i < 6; i++)
    {
      iX = 50;
      iX = iX + i * 80;
      iY = 230;
      Invaders.Add(new InvaderSquare(iX, iY));
    }
    for (int i = 0; i < 6; i++)
    {
      iX = 50;
      iX = iX + i * 80;
      iY = 270;
      Invaders.Add(new InvaderTriangle(iX, iY));
    }
    for (int i = 0; i < 6; i++)
    {
      iX = 50;
      iX = iX + i * 80;
      iY = 320;
      Invaders.Add(new InvaderTriangle(iX, iY));
    }

    //add the caves
    for (int i = 0; i < 2; i++)
    {
      CaveBlocks.Add(new CaveBlock(50 + 40 * (i + 1), 660));
      CaveBlocks.Add(new CaveBlock(430 + 40 * (i), 660));
    }
    CaveBlocks.Add(new CaveBlock(50 + 120, 700));
    CaveBlocks.Add(new CaveBlock(50, 700));
    CaveBlocks.Add(new CaveBlock(390, 700));
    CaveBlocks.Add(new CaveBlock(510, 700));


  }
  public void Draw()
  {
    GameWindow.Clear(Color.LightYellow);
    //draw invader, UFO, player plus bullet draws inside the player

    foreach (var item in SuperUFOs)
    {
      item.Draw();
    }
    foreach (var item in CaveBlocks)
    {
      item.Draw();
    }
    foreach (Invader item in Invaders)
    {
      item.Draw();
    }

    foreach (var item in AlienBullets)
    {
      item.Draw();
    }
    Player.Draw(GameWindow);

    SplashKit.DrawBitmap(Title, 50, 50);
    //Text appears on screen
    SplashKit.DrawText($"Lives: {Player.Lives} ", Color.Gray, "cool.ttf", 25, 280, 50);
    SplashKit.DrawText($"Score: {Player.Score}", Color.Gray, "cool.ttf", 25, 280, 85);
    SplashKit.DrawText($"Time: {myTimer.Ticks / 1000}", Color.Gray, "cool.ttf", 25, 200, 130);
    if (Invaders.Count == 0)
    {
      SplashKit.DrawText($"Congradulations! You Win!", Color.OrangeRed, "cool.ttf", 30, 50, 300);
      SplashKit.DrawText($"Your score is {Player.Score}", Color.OrangeRed, "cool.ttf", 30, 50, 260);
    }

    GameWindow.Refresh(60);
  }



  public void CheckGameIsQuit()
  {
    if (Invaders.Count != 0)
    {
      foreach (Invader item in Invaders)
      {
        if (item.IsOffScreenHeight())
        {
          Quit = true;
        }
      }
    }
    if (SplashKit.KeyDown(KeyCode.EscapeKey) || SplashKit.QuitRequested())
    {
      Quit = true;
    }
    if (Player.Lives == 0)
    {
      Quit = true;
    }
  }

  // public void CheckIsPlayerWin()
  // {
  //   if(Invaders.Count<=1)
  //   {
  //     IsplayerWin = true;
  //   }
  // }


  public void HandleInput()
  {
    // Console.WriteLine(IsplayerWin);
    Player.HandleInput();
    Player.StayOnWindow(GameWindow);
    CheckGameIsQuit();
  }
  // public void WinEffect(Window win)
  // {
  //   if (IsplayerWin)
  //   {
  //     // WinSound.Play();
  //     SplashKit.DrawText($"Congradulations! You Win!", Color.OrangeRed, "cool.ttf", 30, 50, 300);
  //     SplashKit.DrawText($"Your score is {Player.Score}", Color.OrangeRed, "cool.ttf", 30, 50, 260);
  //     win.Refresh(60);
  //   }
  // }
  public void GameOverEffect()
  {
    if (Quit)
    {
      SplashKit.FillRectangle(Color.LightYellow, 0, 200, 600, 700);
      SplashKit.DrawText($"Game Over", Color.OrangeRed, "cool.ttf", 30, 50, 400);
      SplashKit.DrawText($"Your score is {Player.Score}", Color.OrangeRed, "cool.ttf", 30, 50, 260);
      GameWindow.Refresh(60);
      SplashKit.Delay(8000);
    }
  }
  public void Update()
  {
    ChangeInvaderDirection();
    UpdateInvaders();
    // add bullet to allien
    AddAlienBullet();
    //add the super UFO

    int timeControl = Convert.ToInt32(myTimer.Ticks / 40) % 100;
    if (!Quit && SuperUFOs.Count < 1 && timeControl == 0)
    {
      SuperUFOs.Add(new SuperUFO(50, 120));
      UFOSound.Play();
    }

    foreach (var item in SuperUFOs)
    {
      item.SuperUFOUpdate();
    }

    foreach (Bullet item in Player.Bullets)
    {
      item.Update();
    }

    foreach (var item in AlienBullets)
    {
      item.Update();
    }
    CheckCollision();
    // CheckIsPlayerWin();
  }

  public void UpdateInvaders()
  {
    if (Invaders.Count != 0)
    {
      foreach (Invader item in Invaders)
      {
        if (item.MoveLeft)
        {
          item.X -= item.Speed;
        }
        if (item.MoveRight)
        {
          item.X += item.Speed;
        }
      }
    }


  }

  public void ChangeInvaderDirection()
  {
    const int GAP = 50;
    if (Invaders.Count != 0)
    {
      foreach (Invader item in Invaders)
      {
        double change = 5;
        if (item.X > GameWindow.Width - GAP)
        {

          foreach (Invader j in Invaders)
          {
            j.MoveLeft = true;
            j.MoveRight = false;
            j.Y += change;
          }
        }
        if (item.X < GAP)
        {
          foreach (Invader j in Invaders)
          {
            j.MoveLeft = false;
            j.MoveRight = true;
            j.Y += change;
          }
        }
      }
    }

  }

  public void CheckCollision()
  {
    CheckPlayerABulletCollision();
    CheckBulletCollisions();
  }
  public void CheckPlayerABulletCollision()
  {
    List<AlienBullet> ABulletstoRemove = new List<AlienBullet>();
    List<CaveBlock> CaveBlocksToRemove = new List<CaveBlock>();

    foreach (var aBullet in AlienBullets)
    {
      // Console.WriteLine(Player.CollidedWith(aBullet));
      // Console.WriteLine(AlienBullets.Count);
      if (aBullet.IsOffScreen(GameWindow))
      {
        ABulletstoRemove.Add(aBullet);
      }

      if (CaveBlocks.Count != 0)
      {
        foreach (var cBlock in CaveBlocks)
        {
          if (cBlock.CollidedWith(aBullet))
          {
            ABulletstoRemove.Add(aBullet);
            CaveBlocksToRemove.Add(cBlock);
            cBlock.CaveCollide.Play();
          }
        }
      }

      if (Player.CollidedWith(aBullet))
      {
        ABulletstoRemove.Add(aBullet);
        Player.LoseLives();
        LoseLifeSound.Play();
      }
    }
    foreach (var aBullet in ABulletstoRemove)
    {
      AlienBullets.Remove(aBullet);
    }
    foreach (var cBlock in CaveBlocksToRemove)
    {
      CaveBlocks.Remove(cBlock);
    }
    ABulletstoRemove.Clear();
    CaveBlocksToRemove.Clear();
  }

  public void CheckBulletCollisions()
  {
    List<Bullet> bulletsToRemove = new List<Bullet>();
    List<Invader> invadersToRemove = new List<Invader>();
    List<SuperUFO> UFOtoRemove = new List<SuperUFO>();
    List<CaveBlock> CaveBlocksToRemove = new List<CaveBlock>();

    foreach (var bullet in Player.Bullets)
    {
      if (bullet.IsOffScreen(GameWindow))
      {
        bulletsToRemove.Add(bullet);
      }
      if (Invaders.Count != 0)
      {
        foreach (Invader invader in Invaders)
        {

          if (bullet.CollidedWith(invader))
          {

            bulletsToRemove.Add(bullet);
            invadersToRemove.Add(invader);
            // invader.IsDead = true;
            int addScore = 100;
            Player.Score = Player.Score + addScore;
            bullet.CollisionSound.Play();
          }
        }

      }

      foreach (var UFO in SuperUFOs)
      {
        if (UFO.IsOffScreenWidth(GameWindow))
        {
          UFOtoRemove.Add(UFO);
        }
        if (bullet.CollidedWith(UFO))
        {

          bulletsToRemove.Add(bullet);
          UFOtoRemove.Add(UFO);
          UFO.IsDead = true;
          Player.Score = Player.Score + 1000;
          bullet.CollisionSound.Play();
        }
      }
      foreach (var cBlock in CaveBlocks)
      {
        if (cBlock.CollidedWith(bullet))
        {
          bulletsToRemove.Add(bullet);
          CaveBlocksToRemove.Add(cBlock);
          Player.Score -= 500;
          cBlock.CaveCollide.Play();
        }

      }
    }

    foreach (var bullet in bulletsToRemove)
    {
      Player.Bullets.Remove(bullet);
    }

    foreach (var invader in invadersToRemove)
    {
      Invaders.Remove(invader);
    }
    foreach (var UFO in UFOtoRemove)
    {
      SuperUFOs.Remove(UFO);
    }
    foreach (var cBlock in CaveBlocksToRemove)
    {
      CaveBlocks.Remove(cBlock);
    }
    CaveBlocksToRemove.Clear();
    invadersToRemove.Clear();
    UFOtoRemove.Clear();
    CaveBlocksToRemove.Clear();
  }
}
