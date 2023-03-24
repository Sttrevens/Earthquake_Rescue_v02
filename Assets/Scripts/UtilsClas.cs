using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClas {

    private static Camera mainCamera;

    public static Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0; // Set the z position to 0, so it aligns correctly with your 2D world
        return mouseWorldPosition;
    }

}
