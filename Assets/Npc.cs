using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class Npc : ScriptableObject
{
    // Use the new keyword to hide the inherited 'name' property from Object
    new public string name { get; set; }

    [TextArea(3,15)]
    public string[] dialogue;
    [TextArea(3,15)]
    public string[] playerdialogue;
}