using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomainParameters
{
    public const int MAX_IMAGES_TO_SAVE = 10000;
    public const int OFFSET = 0;
    public const int REFRESH_SCENE_PER_FRAME = 3000;

    public static readonly Vector3 MIN_POS_CONFIG = new Vector3(-340.0f, 40.0f, -265.0f);
    public static readonly Vector3 MAX_POS_CONFIG = new Vector3(350.0f, 80.0f, 105.0f);

    public const float MIN_ROT_CONFIG = 0.0f;
    public const float MAX_ROT_CONFIG = 90.0f;
}
