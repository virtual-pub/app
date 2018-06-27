using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour {
    public Text nome, IBU, ABV, SRM, EBC, descricao, copo, copo_descricao, estilo, estilo_descricao, cor, cor_hex, fabricante;
    public Texture2D imagem;
    public GameObject inter;
	
    public void buttonFechar()
    {
        inter.SetActive(false);
    }
}
