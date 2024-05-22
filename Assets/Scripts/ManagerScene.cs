using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    private int puntos = 0;

    public void CambioScenea()
    {
        SceneManager.LoadScene("Nivel1");
    }
    public void IncrementarPuntos()
    {
        puntos++;

        if (puntos >= 6)
        {
            ScenaGanaste();
        }
    }
    public void ScenaGanaste()
    {
        SceneManager.LoadScene("Ganaste");
    }
    public void CambioScenea2D()
    {
        SceneManager.LoadScene("Nivel2D");
    }
}
