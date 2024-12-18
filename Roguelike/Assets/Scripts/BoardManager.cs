using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;


public class BoardManager : MonoBehaviour
{

    private Tilemap _tilemap;

    [SerializeField] private float width;
    [SerializeField] private float height;
    public Tile[] GroundTiles;


    // Start is called before the first frame update
    void Start()
    {
        // aqui o _tilemap está acessando o "tilemap" da componente filho ou seja
        // BoargaManager > Ground > tilemap
        _tilemap = GetComponentInChildren<Tilemap>();

        // laço for para gerar o boasr"tabuleiro" com as medidas passadas de altura e largura
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //tilenumber recebe um valor aleatorio dos tiles que estao dentro do array "groundtiles"
                //cada numero é que vale a uma posição dentro do array
                int tileNumber = Random.Range(0, GroundTiles.Length);

                // aqui estamos setando no mapa o tile escolhido aleatorio no tilenumber , nas posiçoes i e j
                _tilemap.SetTile(new Vector3Int(i,j,0),GroundTiles[tileNumber]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
