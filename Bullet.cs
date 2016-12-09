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

namespace Defender
{
    class Bullet
    {
        private Rectangle bulletRect;
        private Texture2D bulletTex;
        private bool goingLeft;
        public Bullet(Texture2D bulletTex, Rectangle bulletRect, bool left)
        {
            this.bulletRect = bulletRect;
            this.bulletTex = bulletTex;
            goingLeft = left;
        }
        public Rectangle getRect()
        {
            return bulletRect;
        }
        public Texture2D getTex()
        {
            return bulletTex;
        }
        public bool getGoingLeft()
        {
            return goingLeft;
        }
        public void moveLeft()
        {
            bulletRect.X -= 7;
        }
        public void moveRight()
        {
            bulletRect.X += 7;
        }
    }
}
