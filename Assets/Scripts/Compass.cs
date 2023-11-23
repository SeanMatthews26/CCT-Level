using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject collectableIconPrefab;
    List<Collectable> collectables= new List<Collectable>();

    public RawImage compassImage;
    public Transform player;

    public float maxDistance = 200f;

    float compassUnit;

    [SerializeField] Collectable col1;
    [SerializeField] Collectable col2;
    [SerializeField] Collectable col3;
    [SerializeField] Collectable col4;
    [SerializeField] Collectable col5;
    [SerializeField] Collectable col6;
    [SerializeField] Collectable col7;
    [SerializeField] Collectable col8;


    // Start is called before the first frame update
    void Start()
    {
        compassImage= GetComponent<RawImage>();

        compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddCollectableMarker(col1);
        AddCollectableMarker(col2);
        AddCollectableMarker(col3);
        AddCollectableMarker(col4);
        AddCollectableMarker(col5);
        AddCollectableMarker(col6);
        AddCollectableMarker(col7);
        AddCollectableMarker(col8);
    }

    // Update is called once per frame
    void Update()
    {
        //compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        if(collectables.Count > 0)
        {
            foreach (Collectable collectable in collectables)
            {
                collectable.image.rectTransform.anchoredPosition = GetPosOnCompass(collectable);

                float distance = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), collectable.GetPosition());
                float scale = 0f;

                if(distance < maxDistance)
                {
                    scale = 1f - (distance / maxDistance);
                }

                collectable.image.rectTransform.localScale = Vector3.one * scale;
            }
        }
    }

    public void AddCollectableMarker(Collectable marker)
    {
        GameObject newMarker = Instantiate(collectableIconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        collectables.Add(marker);
    }

    Vector2 GetPosOnCompass(Collectable marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFoward = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.GetPosition() - playerPos, playerFoward);

        return new Vector2(compassUnit * angle, 0f);
    }

    public void RemoveCollectable(Collectable collectable)
    {
        collectables.Remove(collectable);
        Destroy(collectable.image);
        Debug.Log(collectables.Count);
    }
}
