using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestCameraShake
{
    [MenuItem("Test/Camera/Shake 0.1f")]
    public static void shakeCamera0_1f() {
        SystemsController.systemInstance.cc.cameraShake();
    }

    [MenuItem("Test/Camera/Shake 0.2f")]
    public static void shakeCamera0_2f() {
        SystemsController.systemInstance.cc.cameraShake(0.2f);
    }

    [MenuItem("Test/Camera/Shake 0.5f")]
    public static void shakeCamera0_5f() {
        SystemsController.systemInstance.cc.cameraShake(0.5f);
    }

}
