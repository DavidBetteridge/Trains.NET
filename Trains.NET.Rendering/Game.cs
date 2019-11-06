﻿using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using Trains.NET.Engine;

namespace Trains.NET.Rendering
{
    public class Game
    {
        public const int CellSize = 40;

        private int _width;
        private int _height;

        private readonly GameBoard _gameBoard;
        private readonly IBoardRenderer _gridRenderer = new GridRenderer();

        public Game(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public void SetSize(int width, int height)
        {
            var columns = Math.Max(width / CellSize, 1);

            var rows = Math.Max(height / CellSize, 1);

            _width = columns * CellSize;
            _height = rows * CellSize;

            _gameBoard.Columns = columns;
            _gameBoard.Rows = rows;
        }

        public void Render(SKSurface surface)
        {
            if (surface is null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            SKCanvas canvas = surface.Canvas;

            canvas.Translate(1, 1);
            canvas.Clear(SKColors.White);
            canvas.ClipRect(new SKRect(0, 0, _width + 2, _height + 2), SKClipOperation.Intersect, false);

            _gridRenderer.Render(surface, _width, _height);
        }
    }
}