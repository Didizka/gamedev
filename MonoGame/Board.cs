using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class Board
    {
        public Tile[,] Tiles { get; set; }
        private int columns;
        public int Columns
        {
            get { return columns; }
            set { if (value >= 0) { columns = value; } }
        }
        private int rows;

        public int Rows
        {
            get { return rows; }
            set { if (value >= 0) { rows = value; } }
        }



        public Texture2D TileTexture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        private Random random = new Random();

        public Board(SpriteBatch batch, Texture2D texture, int _columns, int _rows)
        {
            Columns = _columns;
            Rows = _rows;
            TileTexture = texture;
            SpriteBatch = batch;
            createTiles();

            blockAllBorderTiles();
        }
        
        
        // Create tiles and block 20% of them randomly
        private void createTiles()
        {
            Tiles = new Tile[Columns, Rows];
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Vector2 tilePosition = new Vector2(x * TileTexture.Width, y * TileTexture.Height);
                    Tiles[x, y] = new Tile(TileTexture, tilePosition, SpriteBatch, random.Next(5) == 0);
                }
            }
        }

        private void blockAllBorderTiles()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    if (x == 0 || x == Columns -1 || y == 0 || y == Rows - 1)
                    {
                        Tiles[x, y].IsBlocked = true;
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (var tile in Tiles)
            {
                tile.Draw();
            }
        }

        
    }
}
