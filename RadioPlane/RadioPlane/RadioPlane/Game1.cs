using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO.Ports;
using System.Threading;

namespace RadioPlane
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        // general

        MainMenu Menu;
        Score SCORE;
        bool Play = true;
        bool GameOver = false;
        bool SetStop = false;
        bool Go;
        float rotationPlane;

        // obiects 

        Plane player;
        Vector2 playerPosition;
        Rectangle currentRect;
        Rectangle temp;
        Texture2D enemyTexture;
        List<Enemy> enemies;
        Texture2D explosionTexture;
        List<Animations> explosions;
        Texture2D tree1Texture;
        Texture2D tree2Texture;
        Texture2D tree3Texture;
        List<tree> tree;
        Texture2D lampaon;
        Texture2D lampaoff;
        Rectangle recLamp;


        // control

        KeyboardState presentKey;
        KeyboardState pastKey;
        MouseState mouse;
        _RadioControl Radio;

        // background

        Texture2D sky;
        AllBackground BACKGROUNDS;
        int ground = 80;

        // times 

        float elapsedTime;
        float countDuration = 0.05f;
        float currentTime = 0f;
        TimeSpan enemySpawnTime;
        TimeSpan previousSpawnTime;
        TimeSpan treeSpawnTime;
        TimeSpan previousTreeSpawnTime;

        // other 

        SpriteFont font;
        Random random;
        int score;
        int Score;

        // enum

        enum GameState
        {
            MainMenu,
            Play,
        }

        enum GameController
        {
            Arrow,
            Radio,
        }

        GameState CurrentGameState;
        GameController CurrentController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
        }


        protected override void Initialize()
        {
            font = Content.Load<SpriteFont>("gamefont");
            SCORE = new Score();

            Menu = new MainMenu();
            Menu.Init(this.Content, SCORE);
            

            player = new Plane();

            enemies = new List<Enemy>();
            explosions = new List<Animations>();
            tree = new List<tree>();

            random = new Random();
            this.rotationPlane = -0.3f;

            previousSpawnTime = TimeSpan.Zero;
            enemySpawnTime = TimeSpan.FromSeconds(3.0f);

            previousTreeSpawnTime = TimeSpan.Zero;
            treeSpawnTime = TimeSpan.FromSeconds(2.0f);

            score = 0;
            Score = 0;

            CurrentGameState = GameState.MainMenu;
            CurrentController = GameController.Arrow;
            IsMouseVisible = true;
            

            // RADIO
            
            Radio = new _RadioControl();
            if (Radio.CheckPorts().Length != 0)
            {
                Radio.CreatPort(Radio.CheckPorts()[0]);
                Thread oThread = new Thread(new ThreadStart(Radio.ListeningSignal));
                oThread.Start();
                Radio.SetMin();
            }

            this.Go = false;

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);


            Animations playerAnimation = new Animations();
            Texture2D playerTexture = Content.Load<Texture2D>("plane3");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 164, 55, 6, 20, Color.White, 1f, true, 1);
            playerPosition = new Vector2(170, 155);

            player.Initialize(playerAnimation, playerPosition);

            enemyTexture = Content.Load<Texture2D>("f16");

            explosionTexture = Content.Load<Texture2D>("explosion2");

            tree1Texture = Content.Load<Texture2D>("treeA");
            tree2Texture = Content.Load<Texture2D>("treeB");
            tree3Texture = Content.Load<Texture2D>("treeC");

            lampaon = Content.Load<Texture2D>("lampaon");
            lampaoff = Content.Load<Texture2D>("lampaoff");
            recLamp = new Rectangle(30, 500, 70, 70);

            sky = Content.Load<Texture2D>("sky");

            BACKGROUNDS = new AllBackground(this.Content, player);
        }

       
        protected override void UnloadContent()
        {
            
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            presentKey = Keyboard.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    {
                        mouse = Mouse.GetState();
                        Menu.Update(mouse);
                        if (Menu.Play.isClicked == true)
                        {
                            CurrentGameState = GameState.Play;
                            Menu.Play.isClicked = false;
                            Play = true;
                            previousSpawnTime = gameTime.TotalGameTime;
                            previousTreeSpawnTime = gameTime.TotalGameTime;
                        }
                        if (Menu.Exit.isClicked == true) this.Exit();

                        if (Menu.Controler.isClicked == true)
                        {
                            Menu.Controler.isClicked = false;
                            Menu.CurentState = MainMenu.MenuState.controller;
                        }

                        if (Menu.Arrows.isClicked == true)
                        {
                            Menu.Arrows.isClicked = false;
                            Menu.Arrows.Set();
                            Menu.Signal.unSet();
                            Menu.CurentState = MainMenu.MenuState.main;
                            CurrentController = GameController.Arrow;
                        }

                        if (Menu.Signal.isClicked == true)
                        {
                            Menu.Signal.isClicked = false;
                            Menu.Signal.Set();
                            Menu.Arrows.unSet();
                            Menu.CurentState = MainMenu.MenuState.main;
                            CurrentController = GameController.Radio;
                        }

                        if (Menu.Score.isClicked == true)
                        {
                            Menu.Score.isClicked = false;
                            Menu.CurentState = MainMenu.MenuState.score;
                        }
                        break;
                    }
                case GameState.Play:
                    {
                        if (presentKey.IsKeyDown(Keys.P) && pastKey.IsKeyUp(Keys.P))
                        {
                            if (Play) Play = false;
                            else
                            {
                                Play = true;
                                previousSpawnTime = gameTime.TotalGameTime;
                                previousTreeSpawnTime = gameTime.TotalGameTime;
                            }
                        }
                        if (presentKey.IsKeyDown(Keys.R) && pastKey.IsKeyUp(Keys.R))
                        {
                            GameOver = false;
                            Reset(gameTime);
                        }
                        if (presentKey.IsKeyDown(Keys.Escape) && pastKey.IsKeyUp(Keys.Escape))
                        {
                            Play = false;
                            CurrentGameState = GameState.MainMenu;
                        }
                        if (Play)
                        {
                            currentRect = new Rectangle((int)player.Position.X, (int)player.Position.Y, (int)player.Width, (int)player.Height);
                            temp = getBoundsWithRotation(currentRect, rotationPlane);
                            // CHANGE ROTATION
                            switch (CurrentController)
                            {
                                case GameController.Arrow:
                                    {
                                        if (Keyboard.GetState().IsKeyDown(Keys.Up))
                                        {
                                            if (this.rotationPlane >= -1.5f)
                                                this.rotationPlane -= 0.01f;
                                        }
                                        else if (this.rotationPlane <= 1.5f) this.rotationPlane += 0.01f;
                                        break;
                                    }
                                case GameController.Radio:
                                    {
                                        currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds; 

                                        if (currentTime >= countDuration)
                                        {
                                            currentTime -= countDuration;
                                            if (this.Radio.CheckSignal())
                                            {
                                                if (this.Go == false)
                                                {
                                                    this.Go = true;
                                                }
                                            }
                                            else
                                            {
                                                if (this.Go == true)
                                                {
                                                    this.Go = false;
                                                }
                                            }
                                        }

                                        if (Go)
                                        {
                                            if (this.rotationPlane >= -1.5f)
                                                this.rotationPlane -= 0.01f;
                                        }
                                        else if (this.rotationPlane <= 1.5f) this.rotationPlane += 0.01f;

                                        break;
                                    }
                            }
                            
                            player.rotation = rotationPlane;
                            player.speed = CountSpeed(player.StaticSpeed);

                            UpdateEnemies(gameTime);
                            UpdateTree(gameTime);
                            PlayerUpdate(gameTime);

                            // UploadingBackground();
                            BACKGROUNDS.UpdateAll();
                            for (int i = 0; i < BACKGROUNDS.Backgrounds.Count; i++)
                            {
                                if(i < 2) BACKGROUNDS.Backgrounds[i].Update(CountSpeed(BACKGROUNDS.Backgrounds[i].ObjectSpeed, 1));
                                else BACKGROUNDS.Backgrounds[i].Update(CountSpeed(BACKGROUNDS.Backgrounds[i].ObjectSpeed));
                            }

                            UpdateCollision(temp);

                            if (player.Alive) score++;
                            if (score >= 10) { Score += 10; score -= 10; }
                        }

                        if (SetStop)
                        {
                            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                            if (elapsedTime > 2f)
                            {
                                Play = false;
                            }
                        }

                        if (Score == 2000) enemySpawnTime = TimeSpan.FromSeconds(2.0f);
                        if (Score == 4000) enemySpawnTime = TimeSpan.FromSeconds(1.0f);
                        UpdateExplosions(gameTime);
                        break;
                    }
            }

            pastKey = presentKey;
            base.Update(gameTime);
        }

        private void Reset(GameTime gameTime)
        {
            enemies.RemoveRange(0, enemies.Count);
            tree.RemoveRange(0, tree.Count);
            player.Active = true;
            player.Alive = true;
            player.PlayerAnimation.Active = true;
            player.Position = new Vector2(player.Width, player.Height + 100);
            Score = 0;
            SetStop = false;
            Play = true;
            elapsedTime = 0f;
            this.rotationPlane = -0.3f;
            player.rotation = -0.3f;
            previousSpawnTime = gameTime.TotalGameTime;
            previousTreeSpawnTime = gameTime.TotalGameTime;
        }

        private float CountSpeed(float s, int scale = 2)
        {
            return (s - (Math.Abs(this.rotationPlane) * scale));
        }

        private void PlayerUpdate(GameTime gameTime)
        {

            if (player.Alive)
            {
                if ((player.Position.Y - player.Height / 2) <= 0)
                {
                    End();
                }
                if((player.Position.Y + player.Height / 2) >= (GraphicsDevice.Viewport.Height - ground))
                {
                    End();
                }
                
                player.Position.Y += (player.rotation * 3);    
                player.Update(gameTime);                       
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousSpawnTime > enemySpawnTime)
            {
                previousSpawnTime = gameTime.TotalGameTime;
                AddEnemy();
            }
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                enemies[i].Update(gameTime, CountSpeed(enemies[i].enemyMoveSpeed));
                if (enemies[i].Active == false)
                {
                    enemies.RemoveAt(i);
                }
            }
        }

        private void AddExplosion(Vector2 position)
        {
            Animations explosion = new Animations();
            explosion.Initialize(explosionTexture, position, 134, 134, 12, 60, Color.White, 1f, false, 1);
            explosions.Add(explosion);
        }

        private void UpdateExplosions(GameTime gameTime)
        {
            for (int i = explosions.Count - 1; i >= 0; i--)
            {
                explosions[i].Update(gameTime, 0);
                if (explosions[i].Active == false)
                {
                    explosions.RemoveAt(i);
                }
            }
        }

        private void AddEnemy()
        {
            Animations enemyAnimation = new Animations();
            enemyAnimation.Initialize(enemyTexture, Vector2.Zero, 178, 60, 1, 60, Color.White, 1f, true, 1);
            Vector2 position = new Vector2(GraphicsDevice.Viewport.Width + enemyTexture.Width, random.Next(50, GraphicsDevice.Viewport.Height - 350));
            Enemy enemy = new Enemy();
            enemy.Initialize(enemyAnimation, position);
            enemies.Add(enemy);
        }

        private void AddTree()
        {
            Animations treeAnimation = new Animations();
            Vector2 position;
            int r = random.Next(0, 3);
            if (r == 0)
            {
                treeAnimation.Initialize(tree1Texture, Vector2.Zero, 160, 227, 1, 60, Color.White, 1f, true, 1);
                position = new Vector2(GraphicsDevice.Viewport.Width + tree1Texture.Width + random.Next(0, 150), (GraphicsDevice.Viewport.Height - ground) - tree1Texture.Height / 2);
            }
            else if(r == 1)
            {
                treeAnimation.Initialize(tree2Texture, Vector2.Zero, 124, 220, 1, 60, Color.White, 1f, true, 1);
                position = new Vector2(GraphicsDevice.Viewport.Width + tree2Texture.Width + random.Next(0,150), (GraphicsDevice.Viewport.Height - ground) - tree2Texture.Height / 2);
            }
            else {
                treeAnimation.Initialize(tree3Texture, Vector2.Zero, 128, 250, 1, 60, Color.White, 1f, true, 1);
                position = new Vector2(GraphicsDevice.Viewport.Width + tree3Texture.Width + random.Next(0, 150), (GraphicsDevice.Viewport.Height - ground) - tree3Texture.Height / 2);
            }
            tree Tre = new tree();
            Tre.Initialize(treeAnimation, position);
            tree.Add(Tre);
        }

        private void UpdateTree(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - previousTreeSpawnTime > treeSpawnTime)
            {
                previousTreeSpawnTime = gameTime.TotalGameTime;
                AddTree();
            }
            for (int i = tree.Count - 1; i >= 0; i--)
            {
                tree[i].Update(gameTime, CountSpeed(player.StaticSpeed));
                if (tree[i].Active == false)
                {
                    tree.RemoveAt(i);
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            // ----------- RYSUJE -----------

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    {
                        Menu.Draw(spriteBatch);
                        break;
                    }
                case GameState.Play:
                    {
                        spriteBatch.Draw(sky, new Vector2(0, 0), Color.White);

                        BACKGROUNDS.AllDraw(spriteBatch);

                        player.Draw(spriteBatch);

                        for (int i = 0; i < enemies.Count; i++)
                        {
                            enemies[i].Draw(spriteBatch);
                        }

                        for (int i = 0; i < tree.Count; i++)
                        {
                            tree[i].Draw(spriteBatch);
                        }

                        for (int i = 0; i < explosions.Count; i++)
                        {
                            explosions[i].Draw(spriteBatch);
                        }

                        if(CurrentController == GameController.Radio){
                            if(Go){
                                spriteBatch.Draw(lampaon, recLamp, Color.White);
                            }
                            else {
                                spriteBatch.Draw(lampaoff, recLamp, Color.White);
                            }
                        }
                           
                        if (GameOver == true)
                        {
                            string[] teksty = { "KONIEC GRY", "Zdobyte punkty: ", "Naciœnij \"R\" aby zacz¹æ ponownie." };
                            Vector2 textSize = font.MeasureString(teksty[0]);

                            spriteBatch.DrawString(font, teksty[0], new Vector2(500 - (font.MeasureString(teksty[0]).X / 2), 150), Color.Red);
                            spriteBatch.DrawString(font, teksty[1] + Score, new Vector2(500 - (font.MeasureString(teksty[1] + Score.ToString()).X / 2), 250), Color.White);
                            spriteBatch.DrawString(font, teksty[2], new Vector2(500 - (font.MeasureString(teksty[2]).X / 2), 350), Color.White);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, "Punkty: " + Score, new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 25, GraphicsDevice.Viewport.TitleSafeArea.Y), Color.White);
                        }
                        break;
                    }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected Rectangle getBoundsWithRotation(Rectangle rect, float angle)
        {

            Vector2 origin = new Vector2((float)rect.X, (float)rect.Y);
            float rot = angle % (float)Math.PI / 2.0f;  // Rotate between 0 and 2pi

            float dx = (float)Math.Abs(Math.Cos(angle)) * (rect.Width / 2.0f) + (float)Math.Abs(Math.Sin(angle)) * (rect.Height / 2.0f);
            float dy = (float)Math.Abs(Math.Sin(angle)) * (rect.Width / 2.0f) + (float)Math.Abs(Math.Cos(angle)) * (rect.Height / 2.0f);

            int x = (int)Math.Round(origin.X - dx);
            int y = (int)Math.Round(origin.Y - dy);
            int w = (int)Math.Round(dx * 2.0f);
            int h = (int)Math.Round(dy * 2.0f);

            return new Rectangle(x, y, w, h);
        }

        private void UpdateCollision(Rectangle temp)
        {
            if (player.Alive)
            {
                Rectangle rectangle1;
                Rectangle rectangle2;

                rectangle1 = temp;

                for (int i = 0; i < enemies.Count; i++)
                {
                    rectangle2 = new Rectangle((int)enemies[i].Position.X - (enemies[i].Width / 2), (int)enemies[i].Position.Y - (enemies[i].Height / 2), enemies[i].Width, enemies[i].Height);

                    if (rectangle1.Intersects(rectangle2))
                    {
                        if(IntersectPixels(player.transform, player.Width, player.Height, player.PlayerAnimation.colorData,
                        enemies[i].transform, enemies[i].Width, enemies[i].Height, enemies[i].EnemyAnimation.colorData))
                        {
                            End();

                            enemies[i].Health = 0;
                            AddExplosion(enemies[i].Position);
                        }
                    }
                }

                for (int i = 0; i < tree.Count; i++)
                {
                    rectangle2 = new Rectangle((int)tree[i].Position.X - (tree[i].Width / 2), (int)tree[i].Position.Y - (tree[i].Height / 2), tree[i].Width, tree[i].Height);

                    if (rectangle1.Intersects(rectangle2))
                    {
                        if (IntersectPixels(player.transform, player.Width, player.Height, player.PlayerAnimation.colorData,
                        tree[i].transform, tree[i].Width, tree[i].Height, tree[i].EnemyAnimation.colorData))
                        {
                            End();

                            tree[i].Active = false;
                        }
                    }
                }
            }
        }

        private void End()
        {
            player.Alive = false;
            player.PlayerAnimation.Active = false;
            AddExplosion(player.Position);
            SetStop = true;
            SCORE.AddScore(Score.ToString());
            GameOver = true;
        }

        static bool IntersectPixels(
        Matrix transformA, int widthA, int heightA, Color[] dataA,
        Matrix transformB, int widthB, int heightB, Color[] dataB)
        {
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            for (int yA = 0; yA < heightA; yA++)
            {
                for (int xA = 0; xA < widthA; xA++)
                {
                    Vector2 positionInB =
                        Vector2.Transform(new Vector2(xA, yA), transformAToB);

                    int xB = (int)Math.Round(positionInB.X);
                    int yB = (int)Math.Round(positionInB.Y);

                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        Color colorA = dataA[xA + yA * widthA];
                        Color colorB = dataB[xB + yB * widthB];

                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
