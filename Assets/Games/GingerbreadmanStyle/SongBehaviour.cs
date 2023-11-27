using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongBehaviour : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private float speedCoefficient;
    [SerializeField] private GameObject note;

    [SerializeField] private float startingHeight;
    
    public float leftLanePosition { get; private set; }
    public float upLanePosition { get; private set; }
    public float rightLanePosition { get; private set; }
    
    public float noteSpeed { get; private set; }
    
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        //int numberOfNotes = (int)(bpm * (audioSource.clip.length / 60));
        int numberOfNotes = 50;

        noteSpeed = (bpm / 120) * speedCoefficient;

        float timeBetweenNotes = 60 / bpm;
        float distanceBetweenNotes = noteSpeed * timeBetweenNotes;

        for (int i = 0; i < numberOfNotes; i++)
        {
            GameObject currentNote  = Instantiate(note, transform.parent);

            Vector3 currentPosition = currentNote.transform.position;
            currentPosition = new Vector3(currentPosition.x, startingHeight + (i * distanceBetweenNotes), 0);
            currentNote.transform.position = currentPosition;

            NoteBehaviour currentNoteBehaviour = currentNote.GetComponent<NoteBehaviour>();
            currentNoteBehaviour.songBehaviour = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
