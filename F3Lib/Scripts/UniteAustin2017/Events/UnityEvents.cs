using System;

using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class IntEvent : UnityEvent<int> { }

[Serializable]
public class FloatEvent : UnityEvent<float> { }

[Serializable]
public class StringEvent : UnityEvent<string> { }

[Serializable]
public class BoolEvent : UnityEvent<bool> { }


[Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { }
[Serializable]
public class TransformEvent : UnityEvent<Transform> { }

[Serializable]
public class ColliderEvent : UnityEvent<Collider> { }



[Serializable]
public class Vector2Event : UnityEvent<Vector2> { }

[Serializable]
public class Vector2IntEvent : UnityEvent<Vector2Int> { }

[Serializable]
public class Vector3Event : UnityEvent<Vector3> { }

[Serializable]
public class Vector3IntEvent : UnityEvent<Vector3Int> { }



[Serializable]
public class ColorEvent : UnityEvent<Color> { }
[Serializable]
public class SpriteEvent : UnityEvent<Sprite> { }

[Serializable]
public class MaterialEvent : UnityEvent<Material> { }

[Serializable]
public class LayerEvent : UnityEvent<LayerMask> { }

