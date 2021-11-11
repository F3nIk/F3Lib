using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace F3Lib.Math
{

    public struct Rect
    {
        private float _x;
        private float _y;

        private float _xMin;
        private float _yMin;

        private float _width;
        private float _height;

        private Line _topEdge;
        private Line _bottomEdge;
        private Line _leftEdge;
        private Line _rightEdge;
        private List<Line> _edges;

        public float X => _x;
        public float Y => _y;
        public float MinX => _xMin;
        public float MaxX => _xMin + _width;
        public float MinY => _yMin;
        public float MaxY => _yMin + _height;
        public float Width => _width;
        public float Height => _height;

        public Vector2 Size => new Vector2(_width, _height);
        public Vector2 Position => new Vector2(_x, _y);
        public Vector2 Center => Position + Size / 2;
        public Line Top => _topEdge;
        public Line Bottom => _bottomEdge;
        public Line Left => _leftEdge;
        public Line Right => _rightEdge;
        public IEnumerable Edges => _edges;


        public Rect(Vector2 position, Vector2 size)
        {
            _x = position.x;
            _y = position.y;

            _width = size.x;
            _height = size.y;

            _xMin = _x;
            _yMin = _y;


            _topEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin + _width, _yMin + _height));
            _bottomEdge = new Line(new Vector2(_xMin, _yMin), new Vector2(_xMin + _width, _yMin));
            _leftEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin, _yMin));
            _rightEdge = new Line(new Vector2(_xMin + _width, _yMin + _height), new Vector2(_xMin + _width, _yMin));

            _edges = new List<Line>();
            _edges.AddUniqueItem(_topEdge);
            _edges.AddUniqueItem(_bottomEdge);
            _edges.AddUniqueItem(_leftEdge);
            _edges.AddUniqueItem(_rightEdge);
        }

        public Rect(Vector2 position, float width, float height)
        {
            _x = position.x;
            _y = position.y;

            _width = width;
            _height = height;

            _xMin = _x;
            _yMin = _y;

            _topEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin + _width, _yMin + _height));
            _bottomEdge = new Line(new Vector2(_xMin, _yMin), new Vector2(_xMin + _width, _yMin));
            _leftEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin, _yMin));
            _rightEdge = new Line(new Vector2(_xMin + _width, _yMin + _height), new Vector2(_xMin + _width, _yMin));

            _edges = new List<Line>();
            _edges.AddUniqueItem(_topEdge);
            _edges.AddUniqueItem(_bottomEdge);
            _edges.AddUniqueItem(_leftEdge);
            _edges.AddUniqueItem(_rightEdge);
        }

        public Rect(float x, float y, float width, float height)
        {
            _x = x;
            _y = y;

            _width = width;
            _height = height;

            _xMin = _x;
            _yMin = _y;

            _topEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin + _width, _yMin + _height));
            _bottomEdge = new Line(new Vector2(_xMin, _yMin), new Vector2(_xMin + _width, _yMin));
            _leftEdge = new Line(new Vector2(_xMin, _yMin + _height), new Vector2(_xMin, _yMin));
            _rightEdge = new Line(new Vector2(_xMin + _width, _yMin + _height), new Vector2(_xMin + _width, _yMin));

            _edges = new List<Line>();
            _edges.AddUniqueItem(_topEdge);
            _edges.AddUniqueItem(_bottomEdge);
            _edges.AddUniqueItem(_leftEdge);
            _edges.AddUniqueItem(_rightEdge);
        }

        public bool Contains(Vector2 point) => MinX <= point.x && MaxX >= point.x &&
        MinY <= point.y && MaxY >= point.y;

        public bool ContainsInside(Vector2 point) => MinX < point.x && MaxX > point.x &&
        MinY < point.y && MaxY > point.y;

        public bool ContainsPerimeter(Vector2 point) => (MinX == point.x || MaxX == point.x) && MinY <= point.y && MaxY >= point.y ||
            (MinY == point.y || MaxY == point.y) && MinX <= point.x && MaxX >= point.x;


        public static bool operator ==(Rect a, Rect b) => a.Position == b.Position && a.Size == b.Size;
        public static bool operator !=(Rect a, Rect b) => a.Position != b.Position || a.Size != b.Size;
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}