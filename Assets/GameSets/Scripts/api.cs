using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Boomlagoon.JSON;
using System.Security.Cryptography;

public class api : MonoBehaviour {
    
    private string URLId = "https://virtualpub.herokuapp.com/cervejas/api/";
    private string URLImg = "https://virtualpub.herokuapp.com/fotos/";

    Dictionary<string, int> dicionario = new Dictionary<string, int>();

    
    public InputField input;
    public Interface ui;

    public Cerveja cerveja;

    public void Request()
    {     
         
        WWW request = new WWW(URLId);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW request)
    {
        yield return request;

  



        JSONObject json = JSONObject.Parse(request.text);

        cerveja = new Cerveja();

     
        cerveja = gameObject.AddComponent(typeof(Cerveja)) as Cerveja;
       

        
        cerveja.id = Convert.ToInt32( json.GetString("id"));
        cerveja.IBU = Convert.ToInt32(json.GetNumber("IBU"));
        cerveja.ABV = Convert.ToDouble(json.GetNumber("ABV"));
        cerveja.SRM = Convert.ToDouble(json.GetNumber("SRM"));
        cerveja.EBC = Convert.ToDouble(json.GetNumber("EBC"));
        cerveja.nome = json.GetString("nome");
        cerveja.estilo = json.GetString("estilo");
        cerveja.estilo_descricao = json.GetString("estilo_descricao");
        cerveja.copo = json.GetString("copo");
        cerveja.copo_id = Convert.ToInt32(json.GetString("copo_id"));
        cerveja.copo_descricao = json.GetString("copo_descricao");
        cerveja.cor = json.GetString("cor");
        cerveja.cor_hex = json.GetString("cor_hex");
        cerveja.fabricante = json.GetString("fabricante");
        cerveja.descricao = json.GetString("descricao");


        ui.IBU.text = cerveja.IBU.ToString();
        ui.ABV.text = cerveja.ABV.ToString() + "%";
        ui.SRM.text = cerveja.SRM.ToString();
        ui.EBC.text = cerveja.EBC.ToString();
        ui.nome.text = cerveja.nome;
        ui.estilo.text = cerveja.estilo;
        ui.estilo_descricao.text = cerveja.estilo_descricao;
        ui.copo.text = cerveja.copo;
        ui.copo_descricao.text = cerveja.copo_descricao;
        ui.cor.text = cerveja.cor;
        ui.cor.text = cerveja.cor;
        ui.fabricante.text = cerveja.fabricante;
        ui.descricao.text = cerveja.descricao;
        ui.inter.SetActive(true);

       
    }
    private IEnumerator OnResponseImg(WWW request)
    {
        yield return request;

        request.LoadImageIntoTexture(ui.imagem);
    }
    

    public void Search(string idcerveja)
    {

        string aux = URLId;


        aux = (URLId + idcerveja);
        print(aux);

        WWW img = new WWW(URLImg + idcerveja + ".jpg");
        print(URLImg + idcerveja + ".jpg");
        


        WWW request = new WWW(aux);
        StartCoroutine(OnResponse(request));
        StartCoroutine(OnResponseImg(img));
    }


}