using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RadioPlane
{
    class Enemy
    {
        public Animations EnemyAnimation;
        public Vector2 Position;
        public bool Active;
        public int Health;
        public int Damage;
        public int Value;
        public float enemyMoveSpeed;
        public Matrix transform;

        public int Width
        {
            get { return EnemyAnimation.FrameWidth; }
        }
        public int Height
        {
            get { return EnemyAnimation.FrameHeight; }
        }

        public void Initialize(Animations animation, Vector2 position)
        {
            EnemyAnimation = animation;
            Position = position;
            Active = true;
            Health = 10;
            Damage = 10;
            enemyMoveSpeed = 7f;
            Value = 100;
            UpdateTransform();
        }

        public void UpdateTransform()
        {
            this.transform = Matrix.CreateTranslation(new Vector3(-(this.EnemyAnimation.spriteOrigin), 0.0f)) *
                        Matrix.CreateScale(this.EnemyAnimation.scale) *
                        Matrix.CreateRotationZ(0f) *
                        Matrix.CreateTranslation(new Vector3(this.Position, 0.0f));
        }
        public void Update(GameTime gameTime, float speed)
        {
            Position.X -= speed;
            EnemyAnimation.Position = Position;
            EnemyAnimation.Update(gameTime, 0f);
            UpdateTransform();
            if (Position.X < -Width || Health <= 0)
            {
                Active = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            EnemyAnimation.Draw(spriteBatch);
        }


    }
}
