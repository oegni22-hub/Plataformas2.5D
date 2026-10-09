using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource musicSource, ambientSource;
    private AudioSource[] sfxSource;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource = gameObject.AddComponent<AudioSource>();
            ambientSource = gameObject.AddComponent<AudioSource>();
            sfxSource = new AudioSource[4];
            
            //for //segun un indice numerico que se va incrementando
            for (int i = 0; i < sfxSource.Length; i++)
            {
                sfxSource[i] = gameObject.AddComponent<AudioSource>();
                sfxSource[i].volume = 0.75f;
            }
            
            //foreach //repasa un array o lista entera con duplicados de su contenido (gasta más memoria ram que el for)
            /*foreach (AudioSource source in sfxSource)
            {
                source = gameObject.AddComponent<AudioSource>();
            }*/
            
            //while //ejecuta su notenido hasta que se cumple una condicion (cuidado bucles infinitos)
            /*int j = 0;
            while (j<sfxSource.Length)
            {
                sfxSource[j] = gameObject.AddComponent<AudioSource>();
                j++;
            }*/
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMusic(AudioClip _clip)
    {
        musicSource.clip = _clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayAmbient(AudioClip _clip)
    {
        ambientSource.clip = _clip;
        ambientSource.loop = true;
        ambientSource.Play();
    }

    public void StopAmbient()
    {
        ambientSource.Stop();
    }

    public void PlaySFX(AudioClip _clip)
    {
        for (int i = 0; i < sfxSource.Length; i++)
        {
            if (sfxSource[i].isPlaying == false)
            {
                sfxSource[i].clip = _clip;
                sfxSource[i].Play();
                break;
            }
        }
    }

    public void StopSFX()
    {
        for (int i = 0; i < sfxSource.Length; i++)
        {
            sfxSource[i].Stop();
        }
    }
}
