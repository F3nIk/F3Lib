using UnityEngine;

namespace F3Lib.Math
{
    public struct Line
    {
        private Vector2 _startPoint;
        private Vector2 _endPoint;

        public float MinX => _startPoint.x < _endPoint.x ? _startPoint.x : _endPoint.x;
        public float MaxX => _startPoint.x > _endPoint.x ? _startPoint.x : _endPoint.x;

        public float MinY => _startPoint.y < _endPoint.y ? _startPoint.y : _endPoint.y;
        public float MaxY => _startPoint.y > _endPoint.y ? _startPoint.y : _endPoint.y;

        public Vector2 StartPoint => _startPoint;
        public Vector2 EndPoint => _endPoint;
        public Vector2 Direction => (_endPoint - _startPoint).normalized;
        public Vector2 Center => (_startPoint + _endPoint) / 2;
        public float Length => GetLength();

        public Line(Vector2 startPoint, Vector2 endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        public bool Contains(Vector2 point) => (point.x - _startPoint.x) / (_endPoint.x - _startPoint.x) ==
            (point.y - _startPoint.y) / (_endPoint.y - _startPoint.y);

        public bool IsParallel(Line line) => GetSlope() == line.GetSlope();

        public bool IsCross(Line line)
        {
            Vector2 p1 = StartPoint;
            Vector2 p2 = EndPoint;
            Vector2 p3 = line.StartPoint;
            Vector2 p4 = line.EndPoint;


            float v1 = VectorScale(p4.x - p3.x, p4.y - p3.y, p1.x - p3.x, p1.y - p3.y);
            float v2 = VectorScale(p4.x - p3.x, p4.y - p3.y, p2.x - p3.x, p2.y - p3.y);
            float v3 = VectorScale(p2.x - p1.x, p2.y - p1.y, p3.x - p1.x, p3.y - p1.y);
            float v4 = VectorScale(p2.x - p1.x, p2.y - p1.y, p4.x - p1.x, p4.y - p1.y);
            if ((v1 * v2) < 0 && (v3 * v4) < 0)
                return true;
            return false;

        }

        public Vector2 GetRandomPoint() => GetRandomPointIn();
        public Vector2 GetRandomPoint(float borderOffset) => GetRandomPointIn(borderOffset);

        public Vector2 GetIntersectionPoint(Line line)
        {
            Vector2 point = Vector2.zero;

            Vector3 selfValue = LineEquation();
            Vector3 lineValue = line.LineEquation();

            float d = (selfValue.x * lineValue.y - selfValue.y * lineValue.x);
            float dx = (-selfValue.z * lineValue.y + selfValue.y * lineValue.z);
            float dy = (-selfValue.x * lineValue.z + selfValue.z * lineValue.x);

            point.x = (dx / d);
            point.y = (dy / d);

            return point;
        }

        public float GetSlope() => GetSlopeInLine(this);
        public static float GetSlope(Line line) => GetSlopeInLine(line);

        private Vector2 GetRandomPointIn(float borderOffset = 0)
        {
            float dx = EndPoint.x - StartPoint.x;
            float dy = EndPoint.y - StartPoint.y;
            Vector2 vec = new Vector2(dx, dy);

            float r = Mathf.Sqrt(Mathf.Pow(vec.x, 2) + Mathf.Pow(vec.y, 2));

            float randLength = Random.Range(0 + borderOffset, Length - borderOffset);

            return new Vector2(StartPoint.x + dx * randLength / r, StartPoint.y + dy * randLength / r);
        }

        private float GetLength() => Mathf.Sqrt(Mathf.Pow(_endPoint.x - _startPoint.x, 2) +
            Mathf.Pow(_endPoint.y - _startPoint.y, 2));

        private static float GetSlopeInLine(Line line) => (line.MaxY - line.MinY) / (line.MaxX - line.MinX);

        private Vector3 LineEquation() => new Vector3(EndPoint.y - StartPoint.y, StartPoint.x - EndPoint.x, -StartPoint.x *
            (EndPoint.y - StartPoint.y) + StartPoint.y * (EndPoint.x - StartPoint.x));

        private float VectorScale(Vector2 a, Vector2 b) => a.x * b.y - b.x * a.y;

        private float VectorScale(float ax, float ay, float bx, float by) => ax * by - bx * ay;
    }
}