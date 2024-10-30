using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

// This script manages the story of the game.

public class StoryManager : MonoBehaviour
{
    public PlayableDirector timeline;
    public Text dialogueText;
    private Queue<string> dialogueQueue;

    void Start()
    {
        dialogueQueue = new Queue<string>();
        timeline.stopped += OnTimelineEnd;
        LoadDialogue();
    }

    void LoadDialogue()
    {
        // Add dialogues to the queue
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        if (dialogueQueue.Count > 0)
        {
            dialogueText.text = dialogueQueue.Dequeue();
            timeline.Play();
        }
    }

    void OnTimelineEnd(PlayableDirector director)
    {
        ShowNextDialogue();
    }
}
