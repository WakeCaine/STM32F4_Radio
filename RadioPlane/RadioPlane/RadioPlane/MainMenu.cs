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

namespace RadioPlane
{
    class MainMenu
    {
        Texture2D bgmenu;
        List<Button> MainBtn;
        List<Button> ControlerBtn;

        public Button Play;
        public Button Exit;
        public Button Controler;
        public Button Score;
        public Button Arrows;
        public Button Signal;

        SpriteFont font;
        Score SCORE;

        public enum MenuState
        {
            main,
            controller,
            score
        }

        public MenuState CurentState;
        public MouseState presentMouse;
        public MouseState pastMouse;

        public void Init(ContentManager Content, Score S)
        {
            CurentState = MenuState.main;
            
            bgmenu = Content.Load<Texture2D>("mainmenu2");

            this.font = Content.Load<SpriteFont>("lightgamefont");

            this.SCORE = S;

            MainBtn = new List<Button>();
            ControlerBtn = new List<Button>();

            Play = new Button();
            Play.Init(new Vector2(350, 150), Content.Load<Texture2D>("btnplay"), 300, 50);
            MainBtn.Add(Play);

            Score = new Button();
            Score.Init(new Vector2(350, 250), Content.Load<Texture2D>("btnscore"), 300, 50);
            MainBtn.Add(Score);

            Controler = new Button();
            Controler.Init(new Vector2(350, 350), Content.Load<Texture2D>("btnster"), 300, 50);
            MainBtn.Add(Controler);

            Exit = new Button();
            Exit.Init(new Vector2(350, 450), Content.Load<Texture2D>("btnexit"), 300, 50);
            MainBtn.Add(Exit);

            Arrows = new Button();
            Arrows.Init(new Vector2(200, 250), Content.Load<Texture2D>("controlerkey"), 250, 250);
            Arrows.Set();
            ControlerBtn.Add(Arrows);

            Signal = new Button();
            Signal.Init(new Vector2(550, 250), Content.Load<Texture2D>("controlersignal"), 250, 250);
            ControlerBtn.Add(Signal);
        }

        public void Update(MouseState mouse)
        {
            presentMouse = mouse;
            switch (CurentState)
            {
                case MenuState.main:
                    {
                        Rectangle btn;
                        Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
                        
                        for (int i = 0; i < MainBtn.Count; i++)
                        {
                            btn = new Rectangle((int)MainBtn[i].Position.X, (int)MainBtn[i].Position.Y, (int)MainBtn[i].Size.X, (int)MainBtn[i].Size.Y);

                            if (btn.Intersects(mouseRectangle))
                            {
                                MainBtn[i].CurrentColor = MainBtn[i].colorOn;
                                if (presentMouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released ) 
                                    MainBtn[i].isClicked = true;
                               
                            }
                            else if (MainBtn[i].CurrentColor == MainBtn[i].colorOn )
                            {
                                MainBtn[i].CurrentColor = MainBtn[i].colorOff; 
                                MainBtn[i].isClicked = false;
                            }
                        }
                        
                        break;
                    }
                case MenuState.controller:
                    {
                        Rectangle btn;
                        Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
                        for (int i = 0; i < ControlerBtn.Count; i++)
                        {
                            btn = new Rectangle((int)ControlerBtn[i].Position.X, (int)ControlerBtn[i].Position.Y, (int)ControlerBtn[i].Size.X, (int)ControlerBtn[i].Size.Y);

                            if (btn.Intersects(mouseRectangle))
                            {
                                ControlerBtn[i].CurrentColor = ControlerBtn[i].colorOn;
                                if (presentMouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released) ControlerBtn[i].isClicked = true;
                            }
                            else if ((ControlerBtn[i].CurrentColor == ControlerBtn[i].colorOn) )
                            {
                                ControlerBtn[i].CurrentColor = ControlerBtn[i].colorOff;
                                ControlerBtn[i].isClicked = false;
                            }
                        }
                        break;
                    }
                case MenuState.score:
                    {
                        if (presentMouse.LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released) CurentState = MainMenu.MenuState.main;
                        break;
                    }
            }
            pastMouse = presentMouse;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgmenu, new Vector2(0, 0), Color.White);
            switch (CurentState)
            {
                case MenuState.main:
                    {
                        for (int i = 0; i < MainBtn.Count; i++)
                        {
                            MainBtn[i].Draw(spriteBatch);
                        }
                        break;
                    }
                case MenuState.controller:
                    {
                        for (int i = 0; i < ControlerBtn.Count; i++)
                        {
                            ControlerBtn[i].Draw(spriteBatch);
                        }
                        break;
                    }
                case MenuState.score:
                    {
                        SCORE.ReloadList();
                        spriteBatch.DrawString(this.font, "| WYNIKI - TOP 10 |", new Vector2(350, 110), Color.White);
                        int h = 160;
                        for (int i = 0; i < SCORE.Scoress.Count; i++, h+=35)
                        {
                            spriteBatch.DrawString(this.font, (i+1).ToString() + ". " + SCORE.Scoress[i], new Vector2(300, h), Color.White);
                        }

                        break;
                    }
            }
        }
    }
}
