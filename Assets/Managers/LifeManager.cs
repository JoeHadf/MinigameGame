using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager
{
    public const int maxLives = 4;

    private const float lifeWidth = 3.0f;

    public int lifeCount { get; private set; }

    private GameObject[] lives;

    public LifeManager()
    {
        lifeCount = maxLives;
        lives = new GameObject[maxLives];
        GameObject livesParent = new GameObject("LivesParent");

        float livesLength = maxLives * lifeWidth;
        float startingOffset = - ((livesLength / 2) + (lifeWidth / 2));


        for (int i = 0; i < maxLives; i++)
        {
            GameObject currentLife = new GameObject("Life " + (i + 1));
            currentLife.transform.parent = livesParent.transform;
            SpriteRenderer spriteRenderer = currentLife.AddComponent<SpriteRenderer>();
            Texture2D lifeTexture = Resources.Load<Texture2D>("Life");
            Sprite lifeSprite = Sprite.Create(lifeTexture, new Rect(0, 0, lifeTexture.width, lifeTexture.height), new Vector2(0.5f, 0.5f));
            spriteRenderer.sprite = lifeSprite;
            lives[i] = currentLife;

            Vector3 currentPos = currentLife.transform.position;
            float lifeXPos = startingOffset + (i * lifeWidth);
            Vector3 newPos = new Vector3(lifeXPos, currentPos.y, currentPos.z);
            currentLife.transform.position = newPos;
        }
    }

    public void LoseLife()
    {
        lifeCount--;
    }

    public void ShowLives()
    {
        for(int i = 0; i < maxLives; i++)
        {
            GameObject currentLife = lives[i];
            if(i < lifeCount)
            {
                currentLife.SetActive(true);
            }
            else
            {
                currentLife.SetActive(false);
            }
        }
    }

    public void HideLives()
    {
        for(int i = 0; i < maxLives; i++)
        {
            lives[i].SetActive(false);
        }
    }
}
