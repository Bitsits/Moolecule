using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BitSits_Framework
{
    /// <summary>
    /// All the Contents of the Game is loaded and stored here
    /// so that all other screen can copy from here
    /// </summary>
    public class GameContent
    {
        public readonly ContentManager content;
        public readonly Viewport viewport;

        public readonly int scale = 30;

        public readonly Random random = new Random();

        public readonly string[] symbolStrings = { "Z", "H", "O", "N", "C", "X" };

        // Textures
        public readonly Texture2D blank;
        public readonly Texture2D gradient;
        public readonly Texture2D introBackground, instBackground, gameOver, levelBackground, background;

        public readonly Vector2 gameoverCenter;

        public readonly Vector2 elementCenter;
        public readonly Texture2D[] elements = new Texture2D[4];
        public readonly Texture2D shine;

        public readonly Vector2 eyeCenter;
        public readonly Texture2D[] eyes = new Texture2D[6];

        public readonly Texture2D[] bond = new Texture2D[3] ;
        public readonly Vector2[] bondCenter = new Vector2[3];

        // Fonts
        public readonly SpriteFont menufont;
        public readonly SpriteFont symbolfont;

        // Songs
        public readonly Song song;

        // Sound Effects
        public readonly SoundEffect[] broop = new SoundEffect[4];

        // Color Effect
        BasicEffect simpleColorEffect;
        VertexDeclaration vertexDecl;

        /// <summary>
        /// Load GameContents
        /// </summary>
        public GameContent(GameComponent screenManager)
        {
            content = new ContentManager(screenManager.Game.Services, "Content");
            viewport = screenManager.Game.GraphicsDevice.Viewport;

            blank = content.Load<Texture2D>("Graphics/blank");
            gradient = content.Load<Texture2D>("Graphics/gradient");
            introBackground = content.Load<Texture2D>("Graphics/introBackground");
            instBackground = content.Load<Texture2D>("Graphics/instBackground");
            levelBackground = content.Load<Texture2D>("Graphics/levelBackground");
            background = content.Load<Texture2D>("Graphics/background");


            gameOver = content.Load<Texture2D>("Graphics/gameOver");
            gameoverCenter = new Vector2(gameOver.Width, gameOver.Height) / 2;

            for (int i = 0; i < elements.Length; i++) 
                elements[i] = content.Load<Texture2D>("Graphics/element" + (i + 1));
            
            elementCenter = new Vector2(elements[0].Width, elements[0].Height) / 2;
            shine = content.Load<Texture2D>("Graphics/shine");

            for (int i = 0; i < eyes.Length; i++) 
                eyes[i] = content.Load<Texture2D>("Graphics/eye" + i);

            eyeCenter = new Vector2(eyes[0].Width, eyes[0].Height) / 2;

            for (int i = 0; i < bond.Length; i++)
            {
                bond[i] = content.Load<Texture2D>("Graphics/bond" + (i+1));
                bondCenter[i] = new Vector2(bond[i].Width, bond[i].Height) / 2;
            }

            menufont = content.Load<SpriteFont>("Fonts/menufont");
            symbolfont = content.Load<SpriteFont>("Fonts/font40");

            simpleColorEffect = new BasicEffect(screenManager.Game.GraphicsDevice, null);
            simpleColorEffect.VertexColorEnabled = true;
            vertexDecl = new VertexDeclaration(screenManager.Game.GraphicsDevice, VertexPositionColor.VertexElements);

            for (int i = 0; i < broop.Length; i++)
                broop[i] = content.Load<SoundEffect>("Audio/broop" + i);
                        
            song = content.Load<Song>("Audio/May - Alexander Blu");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.3f;

            //Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            screenManager.Game.ResetElapsedTime();
        }

        /// <summary>
        /// Unload GameContents
        /// </summary>
        public void UnloadContent() { content.Unload(); }
    }
}
