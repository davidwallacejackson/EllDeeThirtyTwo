using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace LD32
{
    public class MainMenu : MonoBehaviour
    {
        public void Start()
        {
            Button play = transform.Find("Panel/Play").GetComponent<Button>();
            play.onClick.AddListener(LoadLevel);
        }

        public void LoadLevel()
        {
            Application.LoadLevel("Simple");
        }
    }

}