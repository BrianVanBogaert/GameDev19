using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class MenuState : State
    {
        private List<Component> _components;
       

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = content.Load<Texture2D>("Controls/start");
            var buttonFont = content.Load<SpriteFont>("Fonts/font");


            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Start game"
            };

            newGameButton.Click += NewGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                //nog buttons eventueel
            };
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

        }

      

        public override void Update(GameTime gametime)
        {
            foreach (var component in _components)
            {
                component.Update(gametime);
            }
        }

        public override void LoadContent()
        {
            throw new NotImplementedException();
        }
    }
}
