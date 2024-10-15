using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 1f; // Vitesse de déplacement de la fourmi
    public float rotationSpeed = 720f; // Vitesse de rotation de la fourmi
    public Vector3 direction;

    public Transform cameraTransform; // Référence à la caméra

    void Update()
    {
        // Récupère l'input de l'utilisateur (flèches ou WASD)
        float moveX = Input.GetAxis("Horizontal"); // Mouvement gauche/droite (A/D ou Gauche/Droite)
        float moveZ = Input.GetAxis("Vertical");   // Mouvement avant/arrière (W/S ou Haut/Bas)

        // Calculer la direction relative à la caméra
        Vector3 forward = cameraTransform.forward; // Direction avant de la caméra
        Vector3 right = cameraTransform.right;     // Direction droite de la caméra

        // Assurer que l'axe Y soit toujours 0 (pour éviter de déplacer en hauteur)
        forward.y = 0f;
        right.y = 0f;

        // Normaliser les directions pour éviter des mouvements plus rapides en diagonale
        forward.Normalize();
        right.Normalize();

        // Calculer la direction du mouvement en fonction de la caméra
        direction = forward * moveZ + right * moveX;

        // Si une direction est donnée (si l'utilisateur appuie sur une touche)
        if (direction != Vector3.zero)
        {
            // Déplacer la fourmi
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Calculer la rotation cible basée sur la direction du mouvement
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Faire tourner la fourmi en douceur vers la direction cible
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
