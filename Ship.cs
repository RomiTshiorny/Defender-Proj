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
    class Ship
    {
        private int xV;
        private int yV;
        private bool pointsLeft;
        private bool pointsRight;
        private bool goingUp;
        private bool goingDown;
        private int bulletTimer;
        private Rectangle shipRect;
        private Texture2D shipTex;
        private int health;
        public Ship(Texture2D image, Rectangle rect)
        {
            shipTex = image;
            shipRect = rect;
            xV = 1;
            yV = 1;
            pointsLeft = true;
            pointsRight = false;
            goingDown = false;
            goingUp = false;
            bulletTimer = 0;
        }
        public bool getGoingDown()
        {
            return goingDown;
        }
        public void changeGoingDown(bool newBool)
        {
            goingDown = newBool;
        }
        public bool getGoingUp()
        {
            return goingUp;
        }
        public void changeGoingUp(bool newBool)
        {
            goingUp = newBool;
        }
        public bool getPointsLeft()
        {
            return pointsLeft;
        }
        public void changePointsLeft(bool newBool)
        {
            pointsLeft = newBool;
        }
        public bool getPointsRight()
        {
            return pointsRight;
        }
        public void changePointsRight(bool newBool)
        {
            pointsRight = newBool;
        }
        public void incrementxV()
        {
            xV++;
        }
        public int getxV()
        {
            return xV;
        }
        public void onexV()
        {
            xV = 1;
        }
        public void incrementyV()
        {
            yV++;
        }
        public int getyV()
        {
            return yV;
        }
        public void oneyV()
        {
            yV = 1;
        }
        public void changeYPos(int yV)
        {
            shipRect.Y += yV;
        }
        public void changeXPos(int xV)
        {
            shipRect.X += xV;
        }
        public int getBulletTimer()
        {
            return bulletTimer;
        }
        public void incrementBulletTimer()
        {
            bulletTimer++;
        }
        public Rectangle getShipRect()
        {
            return shipRect;
        }
        public void moveUp()
        {
            if (!getGoingUp())
                oneyV();
            changeGoingUp(true);
            changeGoingDown(!getGoingUp());
            changeYPos(getyV() * -1);

        }
        public void moveLeft()
        {
            if (!getPointsLeft())
                onexV();
            changePointsLeft(true);
            changePointsRight(!getPointsLeft());
            if (getShipRect().X < 650 - getShipRect().Width)
                changeXPos(getxV());
        }
        public void moveRight()
        {
            if (!getPointsRight())
                onexV();
            changePointsRight(true);
            changePointsLeft(!getPointsRight());
            if (getShipRect().X > 150)
                changeXPos(-getxV());
        }
        public void moveDown()
        {
            if (!getGoingDown())
                oneyV();
            changeGoingDown(true);
            changeGoingUp(!getGoingDown());
            changeYPos(getyV());
        }
        public void shoot()
        {
            
        }
        public void reduceHealth(int hp)
        {
            health -= hp;
        }
    }
}
