using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StringObjectDictionary : SerializableDictionary<string, GameObject> { }
[Serializable]
public class ObjectQueueDictionary : SerializableDictionary.Storage<Queue<GameObject>> { }
[Serializable]
public class StringObjectQueueDictionary : SerializableDictionary<string, Queue<GameObject>, ObjectQueueDictionary> { }
