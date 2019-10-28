using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> m_musicQueue = new List<AudioClip>();
    public bool m_smoothTransition;

    private GameObject audioSourceObject_A;
    private GameObject audioSourceObject_B;

    private AudioSource audioSource_A;
    private AudioSource audioSource_B;
    private AudioSource currentAudioSource;

    #region UnityFunctions
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //Creating the two audio source child objects
        audioSourceObject_A = new GameObject("audioSource_A");
        audioSourceObject_B = new GameObject("audioSource_B");

        audioSourceObject_A.transform.parent = this.gameObject.transform;
        audioSourceObject_B.transform.parent = this.gameObject.transform;

        audioSourceObject_A.AddComponent<AudioSource>();
        audioSourceObject_B.AddComponent<AudioSource>();

        audioSource_A = audioSourceObject_A.GetComponent<AudioSource>();
        audioSource_A = audioSourceObject_B.GetComponent<AudioSource>();

        audioSource_A.playOnAwake = false;
        audioSource_B.playOnAwake = false;

        currentAudioSource = audioSource_A;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }
    #endregion

    #region OwnFunctions
    /// <summary>
    /// Starts playing the music queue
    /// </summary>
    public void PlayMusic()
    {
        currentAudioSource.PlayOneShot(m_musicQueue[0]);
    }

    /// <summary>
    /// Pauses playing the music queue
    /// </summary>
    public void PauseMusic()
    {

    }

    /// <summary>
    /// Cancles playing the music and empties the queue
    /// </summary>
    public void CancleMusic()
    {

    }

    /// <summary>
    /// Plays the next audio clip in the queue
    /// </summary>
    public void PlayNext()
    {

    }

    /// <summary>
    /// Empties the queue
    /// </summary>
    public void EmptyQueue()
    {
        m_musicQueue.Clear();
    }

    /// <summary>
    /// Returns the index of specific audio clip
    /// </summary>
    /// <param name="_audioClip"></param>
    /// <returns></returns>
    public int GetIndex(AudioClip _audioClip)
    {
        return 0;
    }

    /// <summary>
    /// Returns the index of the currently playing audio clip
    /// </summary>
    /// <returns></returns>
    public int GetCurrentIndex()
    {
        return 0;
    }

    /// <summary>
    /// Adds audio file to queue
    /// </summary>
    /// <param name="_audioClip"></param>
    public void AddQueue(AudioClip _audioClip)
    {
        m_musicQueue.Add(_audioClip);
    }

    /// <summary>
    /// Adds audio file to the next place in the queue
    /// </summary>
    /// <param name="_audioClip"></param>
    public void AddNext(AudioClip _audioClip)
    {
        m_musicQueue.Insert(GetCurrentIndex() + 1, _audioClip);
    }

    /// <summary>
    /// Removes audio clip to queue
    /// </summary>
    /// <param name="_audioClip"></param>
    public void RemoveQueue(AudioClip _audioClip)
    {
        m_musicQueue.Remove(_audioClip);
    }

    /// <summary>
    /// Removes audio clip at specific index
    /// </summary>
    /// <param name="_index"></param>
    public void RemoveQueue(int _index)
    {
        m_musicQueue.RemoveAt(_index);
    }

    /// <summary>
    /// Removes the next audio clip from the queue
    /// </summary>
    public void RemoveNext()
    {
        m_musicQueue.RemoveAt(GetCurrentIndex() + 1);
    }
    #endregion
}
