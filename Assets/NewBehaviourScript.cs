using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 1f; // Vitesse de d�placement de la fourmi
    public float rotationSpeed = 720f; // Vitesse de rotation de la fourmi
    public Vector3 direction;

    public Transform cameraTransform; // R�f�rence � la cam�ra

    void Update()
    {
        // R�cup�re l'input de l'utilisateur (fl�ches ou WASD)
        float moveX = Input.GetAxis("Horizontal"); // Mouvement gauche/droite (A/D ou Gauche/Droite)
        float moveZ = Input.GetAxis("Vertical");   // Mouvement avant/arri�re (W/S ou Haut/Bas)

        // Calculer la direction relative � la cam�ra
        Vector3 forward = cameraTransform.forward; // Direction avant de la cam�ra
        Vector3 right = cameraTransform.right;     // Direction droite de la cam�ra

        // Assurer que l'axe Y soit toujours 0 (pour �viter de d�placer en hauteur)
        forward.y = 0f;
        right.y = 0f;

        // Normaliser les directions pour �viter des mouvements plus rapides en diagonale
        forward.Normalize();
        right.Normalize();

        // Calculer la direction du mouvement en fonction de la cam�ra
        direction = forward * moveZ + right * moveX;

        // Si une direction est donn�e (si l'utilisateur appuie sur une touche)
        if (direction != Vector3.zero)
        {
            // D�placer la fourmi
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Calculer la rotation cible bas�e sur la direction du mouvement
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Faire tourner la fourmi en douceur vers la direction cible
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
