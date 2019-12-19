using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameProject
{
    #region GAME KLASSE - Beschrijving

    //De game klasse doorloopt het game loop patroon namelijk:
    // 
    // -Load
    // -Update
    // -Draw
    //
    // Hier wordt voornamelijk gewerkt met states. VB: een menustate, een gamestate, een deathstate. Iedere state maakt onderdeel uit van deze methods.


    #endregion

    public class Game1 : Game //noodzakelijk voor het runnen van de game
    {
        GraphicsDeviceManager graphics; 
        SpriteBatch spriteBatch; 
        public static int ScreenHeight;
        public static int ScreenWidth;

        private State _currentState;
        private State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        protected override void Initialize()
        {
            ScreenHeight = graphics.PreferredBackBufferHeight;
            ScreenWidth = graphics.PreferredBackBufferWidth;
            base.Initialize();
        }
       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, graphics.GraphicsDevice, Content); //MENU state is de eerste state
        }
        
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
