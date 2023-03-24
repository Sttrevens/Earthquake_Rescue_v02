using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitGhost : MonoBehaviour
{
    private GameObject spriteGameObject;

    private void Awake()
    {
        spriteGameObject = transform.Find("sprite").gameObject;

        Hide();
    }

    private void Start()
    {
        SpawnManager.Instance.OnActiveSpawnTypeChanged += SpawnManager_OnActiveSpawnTypeChanged;
    }

    private void SpawnManager_OnActiveSpawnTypeChanged(object sender, SpawnManager.OnActiveSpawnTypeChangedEventArgs e)
    {
        if (e.activeSpawnType == null)
        {
            Hide();
        }
        else
        {
            Show(e.activeSpawnType.ghostSprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsClas.GetMouseWorldPosition(); 
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }
}
