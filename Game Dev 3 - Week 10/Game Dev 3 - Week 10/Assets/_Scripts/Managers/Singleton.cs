using UnityEngine;

// Abstract class for creating a Singleton pattern in Unity
//The where T part will allow us to use this on any script since T is a generic type and
//can accept anything.
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance; // Store the single instance of the derived class

    // Property to access the instance
    public static T Instance
    {
        get
        {
            if (instance == null) // If no instance exists
            {
                instance = FindObjectOfType<T>(); // Look for an existing instance in the scene

                if (instance == null) // If still no instance found
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name); // Create a new GameObject
                    instance = singletonObject.AddComponent<T>(); // Add the derived class component to the GameObject
                }
            }
            return instance; // Return the single instance
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance != this) // If an instance already exists and it's not this one
        {
            Destroy(gameObject); // Destroy the duplicate instance's GameObject
        }
        else
        {
            instance = this as T; // Set the instance to this (the current instance)
            DontDestroyOnLoad(gameObject); // Don't destroy the GameObject when loading new scenes
        }
    }
}